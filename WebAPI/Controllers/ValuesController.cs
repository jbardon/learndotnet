using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new [] {"value1", "value2"});
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var a = new Toto()
            {
                Hello = "World"
            };
            // When returning object, ASP chooses automaticcaly the JsonFormatter
            // The formatter depends on accept header and returned body
            return Request.CreateResponse(HttpStatusCode.OK, a/*, Configuration.Formatters.JsonFormatter*/);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    class Toto
    {
        public String Hello;
    }
}
