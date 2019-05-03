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
        public IHttpActionResult Get(int id)
        {
            return Ok("Action with http verb as method name");
        }
        
        // Because of configured api/{controller}/{action} route
        // GET api/values/GetActionName
        public IHttpActionResult GetActionName()
        {
            return Ok("Action with method name defining url param and http verb");
        }
        
        // GET api/values/ActionName
        [HttpGet]
        public IHttpActionResult ActionName()
        {
            return Ok("Action with method name defining url param and annotation defining http verb");
        }
        
        // GET api/values/CustomActionName
        [HttpGet]
        [ActionName("CustomActionName")]
        public IHttpActionResult NotCustomActionName()
        {
            return Ok("Action with custom name from annotation");
        }
        
        // Disable this action, not an endpoint
        // GET api/values/GetNotAnAction
        [NonAction]
        public IHttpActionResult GetNotAnAction()
        {
            return Ok("Not map this method as an action");
        }
    }
}
