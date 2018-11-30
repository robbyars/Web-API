using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootcamp20.Client.Controllers
{
    public class SuppliersController : Controller
    {
        // GET: Suppliers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

    }
}