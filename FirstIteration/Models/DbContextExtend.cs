using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FirstIteration.DataTransferObjects;
using System.Data.SqlClient;

namespace FirstIteration.Models
{
    public partial class transcendenceEntities : DbContext
    {
        public IList<CategoryAmount> getCategoryAmounts(int? deptid)
        {
            var parameters = new[]
            {
                new SqlParameter("@deptid", deptid)
            };

            IList<CategoryAmount> categoryAmounts = this.Database.SqlQuery<CategoryAmount>
                ("dbo.GetTransCategoriesByDept @deptid",
                parameters).ToList();

            return categoryAmounts;
        }
        public IList<CategoryAmount> getCategoryPercents(int? deptid, string source)
        {
            var parameters = new[]
            {
                new SqlParameter("@deptid", deptid ?? (object)DBNull.Value),
                new SqlParameter("@fundcategory", source ?? (object)DBNull.Value)
            };
            IList<CategoryAmount> categoryAmounts;
            //if (deptid != null){
                categoryAmounts = this.Database.SqlQuery<CategoryAmount>
                ("dbo.GetTransCategoriesForPie @deptid, @fundcategory",
                parameters).ToList();                
            //}
            //else if (deptid != null && source.Length > 2) {
            //   categoryAmounts = this.Database.SqlQuery<CategoryAmount>
            //   ("dbo.GetTransCategoriesForPie @deptId, @fundcategory").ToList();
            //}else
            //{

            //}

            return categoryAmounts;


        }
    }
}