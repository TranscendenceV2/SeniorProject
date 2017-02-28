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
using FirstIteration.Services;


namespace FirstIteration.Controllers
{
    public class ChartController : Controller
    {
        private static LineChartServices LineService = new LineChartServices();
        private static StaffListServices StaffService = new StaffListServices();
        private static FundingSourceServices FundService = new FundingSourceServices();
        private static DepartmentServices DeptService = new DepartmentServices();

        public ActionResult Dashboard()
        {
            ViewBag.Department = DeptService.GetAllDepartments();
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
            var staffList = StaffService.GetStaffList(Id);
            var list = staffList.Select(m => new { value = m.StaffID, text = m.StaffName });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /*public JsonResult FundingSourceList(int Id)
        {
            var transactions = (from t in db.Transactions
                                where t.DeptID == Id
                                select t).ToList();
            var list = transactions.Select(m => new { value = m.FundMasterID, text = m.Funding_Sources.FundCodeName });

            var fundList = FundService.GetFundingSourceList(Id);
            return Json(fundList, JsonRequestBehavior.AllowGet);
        }*/

        public JsonResult LineData(int Id)
        {
            var list = LineService.GetTransactionsByDeptID(Id).Select(m => new { name = m.Key, data = m.Value });
            //var data = list.Select(m => new { name = m.Key, value = m.Value });
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}