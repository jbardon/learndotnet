using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    // For Attribute routing
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new [] {"value1", "value2"});
        }

        // FromUri optional for convention based routing
        // GET api/values/5
        public HttpResponseMessage Get([FromUri] int id)
        {            
            var a = new Toto()
            {
                Hello = "World",
                Id = id
            };
            
            // When returning object, ASP.NET chooses automatically the Formatter (serializer)
            // The formatter depends on Request Accept Header and returned payload type (serializable or not ?)
            return Request.CreateResponse(HttpStatusCode.OK, a/*, Configuration.Formatters.JsonFormatter*/);
        }

        // For Attribute routing
        // With PathParam and QueryParams
        // GET api/values/{name}/details?lang=fr
        [Route("{name}/details")]
        public HttpResponseMessage GetDetails([FromUri] string name, string lang)
        {
            // Install System.ValueTuple
            var tuple = (name: name, lang: lang);
            return Request.CreateResponse(HttpStatusCode.OK, tuple);
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

    //[DataContract] (optional for XML formatter)
    public class Toto
    {
        //[DataMember] (optional for XML formatter)
        public string Hello;
        public int Id;
    }
}
