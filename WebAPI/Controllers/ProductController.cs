using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models.CriteriaDto;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Route("{id:int:min(1)}")]
        public HttpResponseMessage FindOne([FromUri] int id)
        {
            var product = _service.FindOne(id);
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage FindAll()
        {
            var products = _service.FindAll();
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }
        
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Search([FromBody] ProductSearchCriteria criteria)
        {
            var products = _service.Search(criteria);
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }
    }
}