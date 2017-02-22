using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstIteration.Models;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Helpers;
using System.Collections;
using System.Data;

namespace FirstIteration.Controllers
{
    public class ChartController : Controller
    {
        public transcendenceEntities db = new transcendenceEntities();

        public ActionResult Dashboard()
        {
            ViewBag.Department = new SelectList(db.Departments, "DeptID", "DeptName");
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

        public JsonResult StaffList(int Id)
        {
            var staff = (from s in db.Staffs
                         where s.DeptID == Id
                         select s).ToList();
            var list = staff.Select(m => new { value = m.StaffID, text = m.StaffName });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FundingSourceList(int Id)
        {
            var transactions = (from t in db.Transactions
                                where t.DeptID == Id
                                select t).ToList();
            var list = transactions.Select(m => new { value = m.FundMasterID, text = m.Funding_Sources.FundCodeName });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LineData(int Id)
        {

            var l = (from t in db.Transactions
                     where t.DeptID == Id
                     select t).OrderBy(x => x.Funding_Sources.FundCodeName).ToList();
  
            var list = l.Select(m => new { name = m.Funding_Sources.FundCodeName, value = m.TransAmount  });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public class RootObject
        {
            public string name { get; set; }
            public List<double> data { get; set; }
        }


    }
}