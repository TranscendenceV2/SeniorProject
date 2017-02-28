using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstIteration.Models;

namespace FirstIteration.Services
{
    public class FundingSourceServices
    {
        public IEnumerable<Object> GetFundingSourceList(int id)
        {
            
            using (var context = new transcendenceEntities())
            {
                var fundSource = (from s in context.Transactions
                         where s.DeptID == id
                         select s).ToList();
                var fundList = fundSource.Select(m => new { value = m.FundMasterID, text = m.Funding_Sources.FundCodeName });
                return fundList;
            }
            

        }
    }
}