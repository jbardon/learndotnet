using System.Web.Http;
using WebAPI.Models.CriteriaDto;
using WebAPI.Models.Dto;
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
        public IHttpActionResult FindOne(int id){
            var product = _service.FindOne(id);
            return Ok(product);
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult FindAll()
        {
            var products = _service.FindAll();
            return Ok(products);
        }
        
        // GET api/product/search?name=a&name=b&maxprice=3 (no name=a,b)
        // Can implement comma
        // - with ActionFilter: https://stackoverflow.com/questions/9981330/pass-an-array-of-integers-to-asp-net-web-api
        // - with CustomTypeConverter: TypeConverter(typeof(NullableIntListConverter))
        [HttpGet]
        [Route("search")]        
        public IHttpActionResult Search([FromUri] ProductSearchCriteria criteria){
            var products = _service.Search(criteria);
            return Ok(products);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] ProductDto product)
        {
            var id = _service.Create(product);
            return Ok(id);
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Update([FromBody] ProductDto product)
        {
            _service.Update(product);
            return Ok();
        }
        
        [HttpDelete]
        [Route("")]
        public IHttpActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}