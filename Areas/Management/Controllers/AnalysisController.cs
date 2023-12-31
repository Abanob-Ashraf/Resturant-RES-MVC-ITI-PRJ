﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Analysis;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Management.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    [Area("Management")]
    public class AnalysisController : Controller
    {
        public IOrderAnalysis OrderAnalysis { get; }
        public ICustomerAnalysis CustomerAnalysis { get; }

        public AnalysisController(IOrderAnalysis orderAnalysis, ICustomerAnalysis customerAnalysis)
        {
            OrderAnalysis = orderAnalysis;
            CustomerAnalysis = customerAnalysis;
        }

        public IActionResult orderAnalysis()
        {
            ViewBag.MostDishesOrdered = OrderAnalysis.GetMostOrderedDishes();

            ViewBag.GetOrderByType = OrderAnalysis.GetOrderByType();

            ViewBag.OrdersPer2Day = OrderAnalysis.OrdersPer2Day();

            return View();
        }

        public IActionResult customerAnalysis()
        {
            ViewBag.NoCustomerOrdered = CustomerAnalysis.GetNoCustomerOrdered();

            ViewBag.MostCustomersOrdered = CustomerAnalysis.GetMostCustomersOrderedMoreOne();

            ViewBag.NoOfRegisteredCustomers = CustomerAnalysis.NoOfRegisteredCustomers();

            ViewBag.LeastCustomersSignUps = CustomerAnalysis.LeastCustomersSignUps();

            return View();
        }

        public IActionResult DishAnalysis()
        {
            ViewBag.LeastOrderedDishes = OrderAnalysis.LeastOrderedDishes();

            return View();
        }
    }
}
