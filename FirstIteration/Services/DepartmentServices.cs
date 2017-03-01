using System;
using System.Collections.Generic;
using System.Linq;
using FirstIteration.Models;
using System.Web;
using System.Web.Mvc;

namespace FirstIteration.Services
{
    public class DepartmentServices
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
    }
}