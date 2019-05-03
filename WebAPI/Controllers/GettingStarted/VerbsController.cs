using System.Web.Http;

namespace WebAPI.Controllers.GettingStarted
{
    public class VerbsController : ApiController
    {
        
        // GET api/verbs
        public IHttpActionResult Get()
        {
            return Ok("Default behavior");
        }
        
        // GET api/verbs/5
        public IHttpActionResult Get([FromUri] int id)
        {            
            var a = new Toto()
            {
                Hello = "World",
                Id = id
            };
            
            // When returning object, ASP.NET chooses automatically the Formatter (serializer)
            // The formatter depends on Request Accept Header and returned payload type (serializable or not ?)
            return Ok(a/*, Configuration.Formatters.JsonFormatter*/);
        }
        
        // POST api/verbs
        public IHttpActionResult Post([FromBody] Toto value)
        {
            return Ok(("POST", value));
        }

        // PUT api/verbs/5
        public IHttpActionResult Put(int id, [FromBody] Toto value)
        {
            return Ok(("PUT", id, value));
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            return Ok(("DELETE", id));
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
