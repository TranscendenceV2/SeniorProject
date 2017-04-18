using System;
using System.Collections.Generic;
using System.Linq;
using FirstIteration.Models;
using System.Web;
using System.Web.Mvc;

namespace FirstIteration.Services
{
    public class DropDownServices
    {
        /* returns list of all departments by DeptID, and DeptName*/
        public SelectList GetAllDepartments()
        {
            var allDepartments = new List<Department>();
            using (var db = new transcendenceEntities())
            {
                allDepartments = db.Departments.ToList();
            }
            return new SelectList(allDepartments, "DeptID", "DeptName");
        }

        public SelectList GetAllYears()
        {        
            using (var db = new transcendenceEntities())
            {
                var allYears = db.Transactions.Select(m => new { value = m.TransDate.Year, id = m.TransDate.Year }).Distinct().ToList();
                return new SelectList(allYears, "id", "value", db.Transactions.Max(m => m.TransDate.Year));
            }
            
        }
    }
}