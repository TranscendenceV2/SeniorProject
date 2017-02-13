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

        public JsonResult GetSalesData()
        {
            List<Table> sd = new List<Table>();
            using (TranscendenceEntities2 dc = new TranscendenceEntities2())
            {
                sd = dc.Tables.OrderBy(a=>a.Year).ToList();
            }

            var chartData = new object[sd.Count + 1];
            chartData[0] = new object[]{
                "Year",
                "State",
                "Medicaid",
                "Commercial"
            };

            int j = 0;
            foreach( var i in sd)
            {
                j++;
                chartData[j] = new object[] {i.Year, i.State, i.Medicaid, i.Commercial };
            }

            return new JsonResult {Data = chartData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}