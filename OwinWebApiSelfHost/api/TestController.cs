namespace OwinWebApiSelfHost.api
{
    using OwinWebApiSelfHost.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Http;

    [RoutePrefix("api")]
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("test")]
        public async Task<IHttpActionResult> Get()
        {
            IList<string> values = new List<string>();

            values.Add("value1");

            // Long running task goes here
            Task<IList<string>> t = new Task<IList<string>>(() =>
            {
                IList<string> otherValues = new List<string>();
                otherValues.Add("value2");
                otherValues.Add("value3");
                return (otherValues);
            });
            t.Start();
            await t;

            foreach (var value in t.Result)
            {
                values.Add(value);
            }

            return Ok(values);
        }

        [HttpGet]
        [Route("exception")]
        public async Task<IHttpActionResult> Exception()
        {
            string name = "Alberto";

            // Long running task goes here
            Task<string> t = new Task<string>(() =>
            {
                string sayHello = string.Format("Hello {0}", name);
                return sayHello;
            });
            t.Start();
            await t;

            throw new Exception("Something bad must have happened!");

            return Ok(t.Result);
        }

        [HttpPost]
        [Route("exception")]
        public async Task<IHttpActionResult> Exception(Authentication auth)
        {
            string name = "Alberto";

            // Long running task goes here
            Task<string> t = new Task<string>(() =>
            {
                string sayHello = string.Format("Hello {0}", name);
                return sayHello;
            });
            t.Start();
            await t;

            throw new Exception("Something bad must have happened!");

            return Ok(t.Result);
        }

    }
}
