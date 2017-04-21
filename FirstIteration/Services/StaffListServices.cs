using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstIteration.Models;
using System.Web.Mvc;

//This service is used to populate dropdownlist with staff names based upon selected Department
namespace FirstIteration.Services
{
    public class StaffListServices
    {
        /* returns all staff that match deptID */
        public List<Staff> GetStaffList(int id)
        {

            var allStaff = new List<Staff>();
            using (var context = new transcendenceEntities())
            {
                allStaff = (from s in context.Staffs
                            join staffdept in context.StaffDepts on s.StaffID equals staffdept.StaffID
                            where staffdept.DeptID == id
                            select s).ToList();

            }
            return allStaff;
        }
    }
}