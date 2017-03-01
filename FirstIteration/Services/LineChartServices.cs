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

            Dictionary<string, List<decimal?>> test;
            using (var context = new transcendenceEntities())
            {
                var allTransactions = context.Transactions.Where(t => t.DeptID == id).ToList();
                var byFundSource = allTransactions.GroupBy(m => new { m.Funding_Sources.FundCodeName, m.TransDate.Month, m.TransAmount}).Select(m => new DateObject() { fundName = m.Key.FundCodeName, transAmount = m.Sum(k => k.TransAmount) });//.ToDictionary(t => t.fundName, t => t.Select(g => g.TransAmount).ToList());                
                test = byFundSource.GroupBy(m => m.fundName).ToDictionary(t => t.Key, t => t.Select(g => g.transAmount).ToList());
            }
            //var t = transactions.Select(m => new { value = m.FundMasterID, text = m.Funding_Sources.FundCodeName }).GroupBy(m => m.text);
            return test;
        }

        public class DateObject
        {
            public string fundName;
            public decimal? transAmount;
        }


    }

}
