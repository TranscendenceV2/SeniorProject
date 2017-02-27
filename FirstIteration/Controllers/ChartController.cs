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

        public ActionResult Dashboard()
        {
            using(var context = new transcendenceEntities())
            {
                ViewBag.Department = new SelectList(context.Departments, "DeptID", "DeptName");
            }
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
            /*var staff = (from s in db.Staffs
                         where s.DeptID == Id
                         select s).ToList();
            var list = staff.Select(m => new { value = m.StaffID, text = m.StaffName });*/
            
            return Json(StaffService.GetStaffList(Id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FundingSourceList(int Id)
        {
            /*var transactions = (from t in db.Transactions
                                where t.DeptID == Id
                                select t).ToList();
            var list = transactions.Select(m => new { value = m.FundMasterID, text = m.Funding_Sources.FundCodeName });*/
            
            return Json(FundService.GetFundingSourceList(Id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult LineData(int Id)
        {

            /*var lineData = (from t in db.Transactions
                     where t.DeptID == Id
                     select t).OrderBy(x => x.Funding_Sources.FundCodeName).ToList();*/
            /*String temp = null;
            List<RootObject> dataSet  = new List<RootObject>();
            foreach(var i in lineData)
            {
                if (i.Funding_Sources.FundCodeName != temp)
                {
                    temp = i.Funding_Sources.FundCodeName;
                    dataSet.Add(new RootObject
                    {
                        name = i.Funding_Sources.FundCodeName.Replace("\r\n", string.Empty),
                        data = new List<decimal>()
                    });
                    decimal v = i.TransAmount.GetValueOrDefault();
                    dataSet.Last<RootObject>().data.Add(v);                        
                }
                else
                {
                    decimal d = i.TransAmount.GetValueOrDefault();
                    dataSet.Last<RootObject>().data.Add(d);           
                }
               // Console.WriteLine("Name: {0} Value: {1}", i.Funding_Sources.FundCodeName, i.TransAmount);
            }
            var list = l.Select(m => new { name = m.Funding_Sources.FundCodeName, value = m.TransAmount  });*/
            
            
                return Json(LineService.GetTransactionsByDeptID(Id), JsonRequestBehavior.AllowGet);
        }


        /*public class RootObject
        {
            public string name { get; set; }
            public List<decimal> data { get; set; }
        }*/


    }
}