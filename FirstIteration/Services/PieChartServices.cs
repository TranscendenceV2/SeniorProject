using System;
using System.Collections.Generic;
using FirstIteration.Models;
using System.Linq;
using System.Web;

namespace FirstIteration.Services
{
    public class PieChartServices
    {
        public Dictionary<string, List<decimal?>> GetAllTransactions()
        {
            Dictionary<string, List<decimal?>> byFundSource;
            using (var context = new transcendenceEntities())
            {
                var allTransactions = context.Transactions.OrderBy(m => m.TransDate).ToList();
                var sum = allTransactions.Sum(g => g.TransAmount);
                var getPercentages = allTransactions.GroupBy(m => m.Funding_Sources.FundCategory).Select(l => new DateObject() { fundName = l.Key, transAmount = ((l.Sum(k => k.TransAmount) / sum ) * 100) });
                byFundSource = getPercentages.OrderBy(v => v.transAmount).GroupBy(m => m.fundName).ToDictionary(t => t.Key, t => t.Select(g => g.transAmount).ToList());
            }
            return byFundSource;
        }

        public Dictionary<string, List<decimal?>> GetTransactionsByDeptID(int? id)
        {
            
            Dictionary<string, List<decimal?>> byFundSource;
            using (var context = new transcendenceEntities())
            {
                var allTransactions = context.Transactions.Where(t => t.DeptID == id).OrderBy(m => m.TransDate).ToList();
                var sum = allTransactions.Sum(g => g.TransAmount);
                var getPercentages = allTransactions.GroupBy(m => m.Funding_Sources.FundCategory).Select(l => new DateObject() { fundName = l.Key, transAmount = ((l.Sum(k => k.TransAmount) / sum) * 100) });
                byFundSource = getPercentages.OrderBy(v => v.transAmount).GroupBy(m => m.fundName).ToDictionary(t => t.Key, t => t.Select(g => g.transAmount).ToList());

            }
            return byFundSource;
        }

        public class DateObject
        {
            public string fundName;
            public decimal? transAmount;
        }

        public class PieObject
        {
            public string name;
            public Dictionary<string, List<decimal?>> data;
        }
    }
}