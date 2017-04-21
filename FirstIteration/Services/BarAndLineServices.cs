using System;
using System.Collections.Generic;
using FirstIteration.Models;
using System.Linq;
using System.Web;
using FirstIteration.DataTransferObjects;

// Calls the stored procedure and returns resultset for both bar and line charts
namespace FirstIteration.Services
{
    public class BarAndLineServices
    {
        public IList<CategoryAmount> GetDataForLine(int? year, int? id, string source, int? staff)
        {
            using (var context = new transcendenceEntities())
            {
                return context.getCategoryAmountsForLine(year, id, source, staff);
            }
        }
        public IList<CategoryAmount> GetDataForBar(int? year, int? id, string source, int? staff)
        {
            using (var context = new transcendenceEntities())
            {
                return context.getCategoryAmountsForBar(year, id, source, staff);
            }
        }
    }
}
