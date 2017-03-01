using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstIteration.Models;

namespace FirstIteration.Services
{
    public class FundingSourceServices
    {
        /* returns all funding sources that match dept ID */
        public IEnumerable<Object> GetFundingSourceList(int id)
        {
            
            using (var context = new transcendenceEntities())
            {
                var allFundSources = (from s in context.Transactions
                         where s.DeptID == id
                         select s).ToList();
                var formattedFundList = allFundSources.Select(m => new { value = m.FundMasterID, text = m.Funding_Sources.FundCodeName });
                return formattedFundList;
            }
            

        }
    }
}