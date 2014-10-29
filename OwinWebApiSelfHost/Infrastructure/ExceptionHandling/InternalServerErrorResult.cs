﻿namespace OwinWebApiSelfHost.Infrastructure.ExceptionHandling
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class InternalServerErrorResult : IHttpActionResult
    {
        public string Content { get; private set; }
        public Encoding Encoding { get; private set; }
        public HttpRequestMessage Request { get; private set; }

        public InternalServerErrorResult(string content, Encoding encoding, HttpRequestMessage request)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }

            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            this.Content = content;
            this.Encoding = encoding;
            this.Request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            response.RequestMessage = Request;
            response.Content = new StringContent(Content, Encoding);
            return (response);
        }
    }
}