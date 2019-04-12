using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using WebAPI.Models.CriteriaDto;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly IProductApiService _service;

        public ProductController(IProductApiService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Route("{id:int:min(1)}")]
        public HttpResponseMessage FindOne(int id){
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
        
        // GET api/product/search?name=a&name=b&maxprice=3 (no name=a,b)
        // Can implement comma
        // - with ActionFilter: https://stackoverflow.com/questions/9981330/pass-an-array-of-integers-to-asp-net-web-api
        // - with CustomTypeConverter: TypeConverter(typeof(NullableIntListConverter))
        [HttpGet]
        [Route("search")]        
        public HttpResponseMessage Search([FromUri] ProductSearchCriteria criteria){
            var products = _service.Search(criteria);
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }
    }
}