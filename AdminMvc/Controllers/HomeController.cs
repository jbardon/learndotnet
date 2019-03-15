using System.Web.Mvc;
using AdminMvc.Models;

namespace AdminMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Sample()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        
        // The parameter is a query parameter
        // Mvc/WithQueryParam?param=String
        public ActionResult WithQueryParam(string param)
        {
            /**
             * Instanciate the model and pass it to the view
             */
            WithQueryParamModel model = new WithQueryParamModel(param);
            return View(model);
        }
    }
}