using System;
using System.Collections.Generic;
using FirstIteration.Models;
using System.Linq;
using System.Web;
using FirstIteration.DataTransferObjects;


//returns data from Stored Procedure for the pie chart
namespace FirstIteration.Services
{
    public class PieChartServices
    {        
        public IList<CategoryAmount> GetCategoriesForPie(int? year, int? id, string source, int? staff)
        {
            using (var context = new transcendenceEntities())
            {
                return context.getCategoryPercents(year, id, source, staff);
            }
        }  
    }
}