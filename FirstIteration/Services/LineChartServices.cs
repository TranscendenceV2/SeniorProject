using System;
using System.Collections.Generic;
using FirstIteration.Models;
using System.Linq;
using System.Web;

namespace FirstIteration.Services
{
    public class LineChartServices
    {
        public IEnumerable<Transaction> GetTransactionsByDeptID(int id)
        {
            IEnumerable<Transaction> transactions;

            using (var context = new transcendenceEntities())
            {
                transactions = context.Transactions.Where(t => t.DeptID == id).ToList();
            }
            transactions.Select(m => new { value = m.FundMasterID, text = m.Funding_Sources.FundCodeName }).GroupBy(m => m.text);
            return transactions;
        }
        

    }

}
