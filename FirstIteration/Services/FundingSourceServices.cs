using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstIteration.Models;

// populates drop down list categories that are related to funding source
// this is based upon selected department
namespace FirstIteration.Services
{
    public class FundingSourceServices
    {
        /* returns all funding categories that match dept ID */
        public List<FundingCategoryObject> GetFundingCategoryList(int id)
        {

            var fundCategoryList = new List<FundingCategoryObject>();
            using (var context = new transcendenceEntities())
            {
                var allFundSources = (from s in context.Transactions
                         where s.DeptID == id
                         select s).ToList();
                fundCategoryList = allFundSources.GroupBy(g => new { text = g.Funding_Sources.FundCategory}).Select(m => new FundingCategoryObject { value = m.Key.text, text = m.Key.text } ).ToList();
            }
            return fundCategoryList;

        }

        /* returns all fund code names that match funding categories*/
        public List<FundingCategoryObject> GetFundCodeNameList(int id, string text)
        {
            string compare = string.Concat(text.Take(3));
            var fundCodeNameList = new List<FundingCategoryObject>();
            using (var context = new transcendenceEntities())
            {
                var allFundSources = (from s in context.Transactions
                                      where s.DeptID == id && s.Funding_Sources.FundCategory.Contains(compare)
                                      select s).ToList();
                fundCodeNameList = allFundSources.GroupBy(g => new { value = g.FundMasterID, text = g.Funding_Sources.FundCodeName }).Select(m => new FundingCategoryObject { value = m.Key.value, text = m.Key.text }).ToList();
            }
            return fundCodeNameList;
        }

        public class FundingCategoryObject
        {
            public string value;
            public string text;
        }
    }
}