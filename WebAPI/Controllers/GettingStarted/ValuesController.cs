using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers.GettingStarted
{
    // This controller uses Convention based routing
    // See WebApiConfig: config.Routes.MapHttpRoute
    // api/values (values is controller name)
    public class ValuesController : ApiController
    {
        // GET api/values
        // Add id to avoid collision with GetActionName and ActionName
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Action with http verb as method name");
        }
        
        // Because of configured api/{controller}/{action} route
        // GET api/values/GetActionName
        public HttpResponseMessage GetActionName()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Action with method name defining url param and http verb");
        }
        
        // GET api/values/ActionName
        [HttpGet]
        public HttpResponseMessage ActionName()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Action with method name defining url param and annotation defining http verb");
        }
        
        // GET api/values/CustomActionName
        [HttpGet]
        [ActionName("CustomActionName")]
        public HttpResponseMessage NotCustomActionName()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Action with custom name from annotation");
        }
        
        // Disable this action, not an endpoint
        // GET api/values/GetNotAnAction
        [NonAction]
        public HttpResponseMessage GetNotAnAction()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Not map this method as an action");
        }
    }
}
