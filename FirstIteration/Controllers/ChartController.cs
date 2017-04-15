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
        private static DropDownServices DropDownService = new DropDownServices();
        private static BarChartServices BarService = new BarChartServices();
        private static PieChartServices PieService = new PieChartServices();

        public ActionResult Dashboard()
        {
            ViewBag.Department = DropDownService.GetAllDepartments();
            ViewBag.Year = DropDownService.GetAllYears();
            return View();
        }

        public PartialViewResult _FundingSourceDropDowns()
        {
            ViewBag.Department = DropDownService.GetAllDepartments();
            ViewBag.Year = DropDownService.GetAllYears();
            return PartialView();
        }

        public PartialViewResult _EmployeeDropDowns()
        {
            ViewBag.Department = DropDownService.GetAllDepartments();
            ViewBag.Year = DropDownService.GetAllYears();
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

        public JsonResult StaffList(int Id, int? Year)
        {
            var staffList = StaffService.GetStaffList(Id);
            var list = staffList.Select(m => new { value = m.StaffID, text = m.StaffName });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FundingCategoryList(int Id, int? Year)
        {
            var fundCategoryList = FundService.GetFundingCategoryList(Id);
            return Json(fundCategoryList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FundingCodeNameList(int Id, string text, int? Year)
        {
            var fundCodeNameList = FundService.GetFundCodeNameList(Id, text);
            return Json(fundCodeNameList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LineData(int? Id, string Source, int? employee, int? Year)
        {
            if(Id == null)
            {
                var allData = LineService.GetAllTransactions().Select(m => new { name = m.Key, data = m.Value });
                return Json(allData, JsonRequestBehavior.AllowGet);
            }else
            {
                if (employee == null)
                {
                    //var list = LineService.GetTransactionsByDeptID(Id, Source).Select(m => new { name = m.Key, data = m.Value });
                    //return Json(list, JsonRequestBehavior.AllowGet);
                    var categories = LineService.GetCategories(Id).GroupBy(m => m.Category).Select(l => new { name = l.Key, data = l.Select(g => g.Amount).ToList()});
                    return Json(categories, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var employeeData = LineService.GetEmployeeTransactions(Id, employee).Select(m => new { name = m.Key, data = m.Value });
                    return Json(employeeData, JsonRequestBehavior.AllowGet);
                }
                
            }
            
        }

        public JsonResult BarData(int? Id, string Source, int? employee, int? Year)
        {
            if (Id == null)
            {
                var allData = BarService.GetAllTransactions().Select(m => new { name = m.Key, data = m.Value });
                return Json(allData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (employee == null)
                {
                    //var list = BarService.GetTransactionsByDeptID(Id, Source).Select(m => new { name = m.Key, data = m.Value });
                    //return Json(list, JsonRequestBehavior.AllowGet);
                    var categories = LineService.GetCategories(Id).GroupBy(m => m.Category).Select(l => new { name = l.Key, data = l.Select(g => g.Amount).ToList() });
                    return Json(categories, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var employeeData = BarService.GetEmployeeTransactions(Id, employee).Select(m => new { name = m.Key, data = m.Value });
                    return Json(employeeData, JsonRequestBehavior.AllowGet);
                }
                
            }
        }

        public JsonResult PieData(int? Id, string Source, int? employee, int? Year)
        {
            if (employee == null)
            {
                //var allData = PieService.GetAllTransactions();
                //var test = new { name = "Clay Revenue", data = allData.Select(j => new { name = j.Key, y = j.Value.Single() } ) };
                
                var categories = PieService.GetCategoriesForPie(Id, Source);
                var test = new { name = "Clay Revenue", data = categories.Select(l => new { name = l.Category, y = l.Amount }) };
                return Json(test, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var employeeData = PieService.GetEmployeeTransactions(Id, employee);
                var test = new { name = "Clay Revenue", data = employeeData.Select(j => new { name = j.Key, y = j.Value.Single() }) };
                return Json(test, JsonRequestBehavior.AllowGet);
            }
                
        }
    }
}
