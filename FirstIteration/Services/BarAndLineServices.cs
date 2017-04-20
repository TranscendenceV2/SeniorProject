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
        public IList<CategoryAmount> GetDataForBarAndLine(int? year, int? id, string source, int? staff)
        {
            using (var context = new transcendenceEntities())
            {
                return context.getCategoryAmounts(year, id, source, staff);
            }
        }
    }
}
