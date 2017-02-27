using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstIteration.Models;

namespace FirstIteration.Services
{
    public class FundingSourceServices
    {
        public IEnumerable<Transaction> GetFundingSourceList(int id)
        {
            IEnumerable<Transaction> transactionsList;
            using (var context = new transcendenceEntities())
            {
                transactionsList = context.Transactions.Where(t => t.DeptID == id).ToList();
            }
            transactionsList.Select(m => new { value = m.FundMasterID, text = m.Funding_Sources.FundCodeName });
            return transactionsList;
        }
    }
}