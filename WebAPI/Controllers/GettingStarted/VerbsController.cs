using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers.GettingStarted
{
    public class VerbsController : ApiController
    {
        
        // GET api/verbs
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Default behavior");
        }
        
        // GET api/verbs/5
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
        
        // POST api/verbs
        public HttpResponseMessage Post([FromBody] Toto value)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ("POST", value));
        }

        // PUT api/verbs/5
        public HttpResponseMessage Put(int id, [FromBody] Toto value)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ("PUT", id, value));
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ("DELETE", id));
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
