using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public JsonResult GetSalesData()
        {
            List<Table> sd = new List<Table>();
            using (MyDatabaseEntities5 dc = new MyDatabaseEntities5())
            {
                sd = dc.Tables.OrderBy(a=>a.Year).ToList();
            }

            var chartData = new object[sd.Count + 1];
            chartData[0] = new object[]{
                "Year",
                "State",
                "Medicade",
                "Commercial"
            };

            int j = 0;
            foreach( var i in sd)
            {
                j++;
                chartData[j] = new object[] {i.Year, i.State, i.Medicade, i.Commercial };
            }

            return new JsonResult {Data = chartData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}