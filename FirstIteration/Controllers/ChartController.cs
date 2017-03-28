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
        private static BarChartServices BarService = new BarChartServices();
        private static PieChartServices PieService = new PieChartServices();

        public ActionResult Dashboard()
        {
            ViewBag.Department = DeptService.GetAllDepartments();
            return View();
        }

        public PartialViewResult _FundingSourceDropDowns()
        {
            ViewBag.Department = DeptService.GetAllDepartments();
            return PartialView();
        }

        public PartialViewResult _EmployeeDropDowns()
        {
            ViewBag.Department = DeptService.GetAllDepartments();
            return PartialView();
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

        public JsonResult StaffList(int Id)
        {
            var staffList = StaffService.GetStaffList(Id);
            var list = staffList.Select(m => new { value = m.StaffID, text = m.StaffName });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FundingCategoryList(int Id)
        {
            var fundCategoryList = FundService.GetFundingCategoryList(Id);
            return Json(fundCategoryList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FundingCodeNameList(int Id, string text)
        {
            var fundCodeNameList = FundService.GetFundCodeNameList(Id, text);
            return Json(fundCodeNameList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LineData(int? Id, string Source)
        {
            if(Id == null)
            {
                var allData = LineService.GetAllTransactions().Select(m => new { name = m.Key, data = m.Value });
                return Json(allData, JsonRequestBehavior.AllowGet);
            }else
            {
                var list = LineService.GetTransactionsByDeptID(Id, Source).Select(m => new { name = m.Key, data = m.Value });
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            
        }

        public JsonResult BarData(int? Id, string Source)
        {
            if (Id == null)
            {
                var allData = BarService.GetAllTransactions().Select(m => new { name = m.Key, data = m.Value });
                return Json(allData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var list = BarService.GetTransactionsByDeptID(Id, Source).Select(m => new { name = m.Key, data = m.Value });
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult PieData(int? Id, string Source)
        {
            if (Id == null)
            {
                var allData = PieService.GetAllTransactions();

                var test = new { name = "Clay Revenue", data = allData.Select(j => new { name = j.Key, y = j.Value.Single() } ) };

                return Json(test, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allData = PieService.GetTransactionsByDeptID(Id, Source);
                var test = new { name = "Clay Revenue", data = allData.Select(j => new { name = j.Key, y = j.Value.Single() }) };
                return Json(test, JsonRequestBehavior.AllowGet);
            }
        }
    }
}