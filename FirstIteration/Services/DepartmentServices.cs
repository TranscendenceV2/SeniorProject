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
        public SelectList GetAllDepartments()
        {
            var departments = new List<Department>();
            using (var db = new transcendenceEntities())
            {
                departments = db.Departments.ToList();
            }
            return new SelectList(departments, "DeptID", "DeptName");
        }
    }
}