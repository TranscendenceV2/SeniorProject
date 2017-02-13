using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstIteration.Models;

namespace FirstIteration.Controllers
{
    public class ChartController : Controller
    {
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult _BarChart()
        {
            return View();
        }

        public ActionResult _LineChart()
        {
            return View();
        }

        public ActionResult _PieChart()
        {
            return View();
        }

        public ActionResult _Table()
        {
            return View();
        }

        public ActionResult _Stats()
        {
            return View();
        }
    }
}