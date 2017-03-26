using System;
using System.Collections.Generic;
using FirstIteration.Models;
using System.Linq;
using System.Web;

namespace FirstIteration.Services
{
    public class BarChartServices
    {
        public Dictionary<string, List<decimal?>> GetAllTransactions()
        {
            Dictionary<string, List<decimal?>> byFundSource;
            using (var context = new transcendenceEntities())
            {
                var allTransactions = context.Transactions.OrderBy(m => m.TransDate).ToList();
                var byMonth = allTransactions.GroupBy(m => new { m.Funding_Sources.FundCategory, m.TransDate.Month }).Select(m => new DateObject() { fundName = m.Key.FundCategory, transAmount = m.Sum(k => k.TransAmount) });
                byFundSource = byMonth.OrderBy(v => v.transAmount).GroupBy(m => m.fundName).ToDictionary(t => t.Key, t => t.Select(g => g.transAmount).ToList());
            }            
            return byFundSource;
        }

        public Dictionary<string, List<decimal?>> GetTransactionsByDeptID(int? id)
        {

            Dictionary<string, List<decimal?>> byFundSource;
            using (var context = new transcendenceEntities())
            {
                var allTransactions = context.Transactions.Where(t => t.DeptID == id).OrderBy(m => m.TransDate).ToList();
                var byMonth = allTransactions.GroupBy(m => new { m.Funding_Sources.FundCodeName, m.TransDate.Month }).Select(m => new DateObject() { fundName = m.Key.FundCodeName, transAmount = m.Sum(k => k.TransAmount) });
                byFundSource = byMonth.GroupBy(m => m.fundName).ToDictionary(t => t.Key, t => t.Select(g => g.transAmount).ToList());
                
            }           
            return byFundSource;
        }

        public class DateObject
        {
            public string fundName;
            public decimal? transAmount;
        }
    }
}