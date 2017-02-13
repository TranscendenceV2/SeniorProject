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
        private transcendenceEntities db = new transcendenceEntities();

        public ActionResult Dashboard()
        {
            ViewBag.Department = new SelectList(db.Departments, "DeptID", "DeptName");
            ViewBag.FundingSource = new SelectList(db.Funding_Sources, "FundMasterID", "FundCodeName");
            ViewBag.Staff = new SelectList(db.Staffs, "StaffID", "StaffName");
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}