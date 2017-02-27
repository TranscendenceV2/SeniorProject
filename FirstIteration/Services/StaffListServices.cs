using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstIteration.Models;

namespace FirstIteration.Services
{
    public class StaffListServices
    {
        public IEnumerable<Staff> GetStaffList(int id)
        {
            IEnumerable<Staff> staffList;
            using (var context = new transcendenceEntities())
            {
                staffList = context.Staffs.Where(t => t.DeptID == id).ToList();
            }
            staffList.Select(m => new { value = m.StaffID, text = m.StaffName });
            return staffList;
        }
    }
}