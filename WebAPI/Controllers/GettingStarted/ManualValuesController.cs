using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers.GettingStarted
{
    // This controller uses Attribute routing
    // See WebApiConfig: config.Routes.MapHttpAttributeRoutes();
    [RoutePrefix("api/manual")]
    public class ManualValuesController : ApiController
    {
        // Not necessary to set [HttpGet] because of action name
        // GET /api/manual
        [Route("")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Empty route for controller root route");
        }

        // GET /api/manual/action/name
        [Route("action/name")]
        public HttpResponseMessage GetSpecifiedName()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Specified route name with http verb in method name");
        }

        // POST /api/manual/action/name
        [HttpPost]
        [Route("action/name")]
        public HttpResponseMessage SpecifiedNameNoHttpVerb()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Specified route name with http verb annotation");
        }
        
        // PathParam only
        // Parameters from url are mapped from method param names
        // [FromUri] is optional
        // Possibility to add check in URL in addition to method params types
        // GET api/manual/path-param/{id}
        [HttpGet]
        [Route("path-param/{id:int}/{name}")]
        public HttpResponseMessage PathParams([FromUri] int id, string name)
        {
            // Install System.ValueTuple
            var tuple = (id: id, name: name);
            return Request.CreateResponse(HttpStatusCode.OK, tuple);
        }
     
        // QueryParam only
        // GET api/manual/query-param?id=4&name=test
        [HttpGet]
        [Route("query-param")]
        public HttpResponseMessage QueryParams(int id, string name)
        {
            var tuple = (id: id, name: name);
            return Request.CreateResponse(HttpStatusCode.OK, tuple);
        }
        
        // PathParam and QueryParams
        // Base on name so order in method params doesn't matter
        // GET api/manual/both-params/{id}?name=fr
        [HttpGet]
        [Route("both-params/{id}")]
        public HttpResponseMessage PathAndQueryParams(string name, int id)
        {
            var tuple = (id: id, name: name);
            return Request.CreateResponse(HttpStatusCode.OK, tuple);
        }
        
    }
}
