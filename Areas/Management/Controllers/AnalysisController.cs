using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Analysis;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Management.Controllers
{
    [Area("Management")]
    public class AnalysisController : Controller
    {
        public IOrderAnalysis OrderAnalysis { get; }

        public AnalysisController(IOrderAnalysis orderAnalysis)
        {
            OrderAnalysis = orderAnalysis;
        }

        public IActionResult orderAnalysis()
        {
            ViewBag.MostDishesOrdered = OrderAnalysis.GetMostOrderedDishes();
            ViewBag.NoCustomerOrdered = OrderAnalysis.GetNoCustomerOrdered();
            //ViewBag.GetOrderByType = OrderAnalysis.GetOrderByType();
            
            return View();
        }
    }
}
