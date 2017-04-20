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
        public IList<CategoryAmount> getCategoryAmountsForLine(int? year, int? deptid, string source, int? staff)
        {
            year = year ?? this.Transactions.Max(m => m.TransDate.Year);
            var parameters = new[]
            {
                new SqlParameter("@year", year),
                new SqlParameter("@deptid", deptid ?? (object)DBNull.Value),
                new SqlParameter("@fundcategory", source ?? (object)DBNull.Value),
                new SqlParameter("@staffid", staff ?? (object)DBNull.Value)
            };

            IList<CategoryAmount> categoryAmounts = this.Database.SqlQuery<CategoryAmount>
                ("dbo.GetTransCategoriesByDept @year, @deptid, @fundcategory, @staffid",
                parameters).ToList();

            return categoryAmounts;
        }
        public IList<CategoryAmount> getCategoryPercents(int? year, int? deptid, string source, int? staff)
        {

            year = year ?? this.Transactions.Max(m => m.TransDate.Year);
            var parameters = new[]
            {
                new SqlParameter("@year", year),
                new SqlParameter("@deptid", deptid ?? (object)DBNull.Value),
                new SqlParameter("@fundcategory", source ?? (object)DBNull.Value),
                new SqlParameter("@staffid", staff ?? (object)DBNull.Value)
            };

            IList<CategoryAmount> categoryAmounts = this.Database.SqlQuery<CategoryAmount>
            ("dbo.GetTransCategoriesForPie @year, @deptid, @fundcategory, @staffid",
            parameters).ToList();


            return categoryAmounts;


        }

        public IList<CategoryAmount> getCategoryAmountsForBar(int? year, int? deptid, string source, int? staff)
        {
            year = year ?? this.Transactions.Max(m => m.TransDate.Year);
            var parameters = new[]
            {
                new SqlParameter("@year", year),
                new SqlParameter("@deptid", deptid ?? (object)DBNull.Value),
                new SqlParameter("@fundcategory", source ?? (object)DBNull.Value),
                new SqlParameter("@staffid", staff ?? (object)DBNull.Value)
            };

            IList<CategoryAmount> categoryAmounts = this.Database.SqlQuery<CategoryAmount>
                ("dbo.GetTransCategoriesByTotal @year, @deptid, @fundcategory, @staffid",
                parameters).ToList();

            return categoryAmounts;
        }


    }
}