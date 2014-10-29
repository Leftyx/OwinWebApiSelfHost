using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace OwinWebApiSelfHost.Infrastructure.ExceptionHandling
{
    public class SerilogRequestMessage
    {
        public string HostName { get; set; }
        public string Url { get; set; }
        public string HttpMethod { get; set; }
        public string RawData { get; set; }
        // public NameValueCollection FormData { get; set; }
        public IDictionary Headers { get; set; }

        public SerilogRequestMessage(HttpRequestMessage request)
        {
            this.HostName = request.RequestUri.Host;
            this.Url = request.RequestUri.AbsolutePath;
            this.HttpMethod = request.Method.ToString();
            this.Headers = new Dictionary<string, string>();

            foreach (var header in request.Headers)
            {
                this.Headers.Add(header.Key, string.Join(",", header.Value));
            }

            if (request.Content.Headers.ContentLength.HasValue && request.Content.Headers.ContentLength.Value > 0)
            {

                foreach (var header in request.Content.Headers)
                {
                    this.Headers.Add(header.Key, string.Join(",", header.Value));
                }

                try
                {
                    this.RawData = request.Content.ReadAsStringAsync().Result;
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
