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
        //private static LineChartServices LineService = new LineChartServices();
        private readonly StaffListServices StaffService = new StaffListServices();
        private readonly FundingSourceServices FundService = new FundingSourceServices();
        private readonly DropDownServices DropDownService = new DropDownServices();
        private readonly BarAndLineServices BarService = new BarAndLineServices();
        private readonly PieChartServices PieService = new PieChartServices();
        private readonly ImportServices ImportService = new ImportServices();

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

        [HttpGet]
        public ActionResult UploadModal(string id)
        {
            ViewBag.UploadType = id;
            return PartialView();
        }

        [HttpPost]
        public ActionResult UploadCsv()
        {
            HttpPostedFile file = System.Web.HttpContext.Current.Request.Files["CsvUpload"];
            string targetTable = System.Web.HttpContext.Current.Request.Form["UploadType"];
            return ImportService.Import(file, targetTable);
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

        public JsonResult LineData(int? Year, int? Id, string Source, int? Employee)
        {
            var allData = BarService.GetDataForBarAndLine(Year, Id, Source, Employee).GroupBy(g => g.Category).Select(m => new { name = m.Key, data = m.Select(l => l.Amount).ToList() });
            return Json(allData, JsonRequestBehavior.AllowGet);

            //if (Id == null)
            //{
            //    var allData = BarService.GetDataForBarAndLine(Id, Source, Employee).GroupBy(g => g.Category).Select(m => new { name = m.Key, data = m.Select(l => l.Amount).ToList()});
            //    return Json(allData, JsonRequestBehavior.AllowGet);
            //}else
            //{
            //    if (Employee == null)
            //    {
            //        //var list = LineService.GetTransactionsByDeptID(Id, Source).Select(m => new { name = m.Key, data = m.Value });
            //        //return Json(list, JsonRequestBehavior.AllowGet);
            //        var categories = BarService.GetDataForBarAndLine(Id, Source, Employee).GroupBy(m => m.Category).Select(l => new { name = l.Key, data = l.Select(g => g.Amount).ToList()});
            //        return Json(categories, JsonRequestBehavior.AllowGet);
            //    }
            //    else
            //    {
            //        var employeeData = BarService.GetDataForBarAndLine(Id, Source, Employee).GroupBy(j => j.Category).Select(m => new { name = m.Key, data = m.Select(j => j.Amount).ToList()});
            //        return Json(employeeData, JsonRequestBehavior.AllowGet);
            //    }
                
            //}
            
        }

        public JsonResult BarData(int? Year, int? Id, string Source, int? Employee)
        {
            var allData = BarService.GetDataForBarAndLine(Year, Id, Source, Employee).GroupBy(m => m.Category).Select(m => new { name = m.Key, data = m.Select(j => j.Amount).ToList() });
            return Json(allData, JsonRequestBehavior.AllowGet);

            //if (Id == null)
            //{
            //    var allData = BarService.GetDataForBarAndLine(Id, Source, Employee).GroupBy(m => m.Category).Select(m => new { name = m.Key, data = m.Select(j => j.Amount).ToList()});
            //    return Json(allData, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    if (Employee == null)
            //    {                  
            //        var categories = BarService.GetDataForBarAndLine(Id, Source, Employee).GroupBy(m => m.Category).Select(l => new { name = l.Key, data = l.Select(g => g.Amount).ToList()});
            //        return Json(categories, JsonRequestBehavior.AllowGet);
            //    }
            //    else
            //    {
            //        var employeeData = BarService.GetDataForBarAndLine(Id, Source, Employee).GroupBy(m => m.Category).Select(m => new { name = m.Key, data = m.Select(j => j.Amount).ToList()});
            //        return Json(employeeData, JsonRequestBehavior.AllowGet);
            //    }
                
            //}
        }

        public JsonResult PieData(int? Year, int? Id, string Source, int? Employee)
        {                                                    
            var categories = PieService.GetCategoriesForPie(Year, Id, Source, Employee);
            var test = new { name = "Clay Revenue", data = categories.Select(l => new { name = l.Category, y = l.Amount }) };
            return Json(test, JsonRequestBehavior.AllowGet);

            //if (Employee == null)
            //{
            //    //var allData = PieService.GetAllTransactions();
            //    //var test = new { name = "Clay Revenue", data = allData.Select(j => new { name = j.Key, y = j.Value.Single() } ) };
                
            //    var categories = PieService.GetCategoriesForPie(Id, Source);
            //    var test = new { name = "Clay Revenue", data = categories.Select(l => new { name = l.Category, y = l.Amount }) };
            //    return Json(test, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    var employeeData = PieService.GetEmployeeTransactions(Id, employee);
            //    var test = new { name = "Clay Revenue", data = employeeData.Select(j => new { name = j.Key, y = j.Value.Single() }) };
            //    return Json(test, JsonRequestBehavior.AllowGet);
            //}
                
        }
    }
}
