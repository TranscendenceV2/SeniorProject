using System;
using System.Collections.Generic;
using FirstIteration.Models;
using System.Linq;
using System.Web;

namespace FirstIteration.Services
{
    public class LineChartServices
    {
        /* collects all transactions associated with the department ID
         * Groups these transactions by funding source, and returns a dictionary containing
         * funding source name and transaction amount */
        public Dictionary<string, List<decimal?>> GetTransactionsByDeptID(int id)
        {

            Dictionary<string, List<decimal?>> byFundSource;
            using (var context = new transcendenceEntities())
            {
                var allTransactions = context.Transactions.Where(t => t.DeptID == id).ToList();
                byFundSource = allTransactions.GroupBy(m => m.Funding_Sources.FundCodeName).ToDictionary(t => t.Key, t => t.Select(g => g.TransAmount).ToList());                
            }
            //var t = transactions.Select(m => new { value = m.FundMasterID, text = m.Funding_Sources.FundCodeName }).GroupBy(m => m.text);
            return byFundSource;
        }


    }

}
