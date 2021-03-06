﻿using System.Web.Http;
using System.Web.Http.ValueProviders;
using System.Web.Http.ValueProviders.Providers;

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
        public IHttpActionResult Get()
        {
            return Ok("Empty route for controller root route");
        }

        // GET /api/manual/action/name
        [Route("action/name")]
        public IHttpActionResult GetSpecifiedName()
        {
            return Ok("Specified route name with http verb in method name");
        }

        // POST /api/manual/action/name
        [HttpPost]
        [Route("action/name")]
        public IHttpActionResult SpecifiedNameNoHttpVerb()
        {
            return Ok("Specified route name with http verb annotation");
        }
        
        // PathParam only
        // Parameters from url are mapped from method param names
        // [FromUri] is optional
        // Possibility to add check in URL in addition to method params types
        // GET api/manual/path-param/{id}
        [HttpGet]
        [Route("path-param/{id:int}/{name}")]
        public IHttpActionResult PathParams([FromUri] int id, string name)
        {
            // Install System.ValueTuple
            var tuple = (id: id, name: name);
            return Ok(tuple);
        }
     
        // QueryParam only
        // GET api/manual/query-param?id=4&name=test
        [HttpGet]
        [Route("query-param")]
        public IHttpActionResult QueryParams(int id, string name)
        {
            var tuple = (id: id, name: name);
            return Ok(tuple);
        }
        
        // PathParam and QueryParams
        // Base on name so order in method params doesn't matter
        // GET api/manual/both-params/{id}?name=fr
        [HttpGet]
        [Route("both-params/{id}")]
        public IHttpActionResult PathAndQueryParams(string name, int id)
        {
            var tuple = (id: id, name: name);
            return Ok(tuple);
        }
        
        // If id appears in both RouteDictionary and QueryString (with ?), the QueryString overloads
        // Except by defining the Value Provider (RouteDataValueProviderFactory or QueryStringValueProvider)
        // https://www.strathweb.com/2013/04/asp-net-web-api-and-greedy-query-string-parameter-binding/
        // GET api/manual/both-params/{id}?name=fr?id=1
        [HttpGet]
        [Route("both-params/no-overwrite/{id}")]
        public IHttpActionResult PathAndQueryParamsNoOverwrite(string name, [ValueProvider(typeof(RouteDataValueProviderFactory))] int id)
        {
            var tuple = (id: id, name: name);
            return Ok(tuple);
        }
        
    }
}
