using System;
using System.Collections.Generic;
using FirstIteration.Models;
using System.Linq;
using System.Web;
using FirstIteration.Models;
using FirstIteration.DataTransferObjects;

namespace FirstIteration.Services
{
    public class LineChartServices
    {

        public Dictionary<string, List<decimal?>> GetAllTransactions()
        {
            Dictionary<string, List<decimal?>> test;
            using (var context = new transcendenceEntities())
            {
                var allTransactions = context.Transactions.OrderBy(m => m.TransDate).ToList();
                var byFundSource = allTransactions.GroupBy(m => new { m.Funding_Sources.FundCategory, m.TransDate.Month }).Select(m => new DateObject() { fundName = m.Key.FundCategory, transAmount = m.Sum(k => k.TransAmount) });
                test = byFundSource.GroupBy(m => m.fundName).ToDictionary(t => t.Key, t => t.Select(g => g.transAmount).ToList());
            }
            //var t = transactions.Select(m => new { value = m.FundMasterID, text = m.Funding_Sources.FundCodeName }).GroupBy(m => m.text);
            return test;
        }
        /* collects all transactions associated with the department ID
         * Groups these transactions by funding source, and returns a dictionary containing
         * funding source name and transaction amount */
        public Dictionary<string, List<decimal?>> GetTransactionsByDeptID(int? id, string Source)
        {
            string str = string.Concat(Source.Take(3));
            Dictionary<string, List<decimal?>> test;
            using (var context = new transcendenceEntities())
            {
                List<Transaction> allTransactions;
                if (Source.Contains("--S"))
                {
                    allTransactions = context.Transactions.Where(t => t.DeptID == id).OrderBy(m => m.TransDate).ToList();
                    var byFundSource = allTransactions.GroupBy(m => new { m.Funding_Sources.FundCategory, m.TransDate.Month }).Select(m => new DateObject() { fundName = m.Key.FundCategory, transAmount = m.Sum(k => k.TransAmount) });
                    test = byFundSource.GroupBy(m => m.fundName).ToDictionary(t => t.Key, t => t.Select(g => g.transAmount).ToList());
                    return test;
                }
                else
                {                    
                    allTransactions = context.Transactions.Where(t => t.DeptID == id && t.Funding_Sources.FundCategory.Contains(str)).OrderBy(m => m.TransDate).ToList();
                    var byFundSource = allTransactions.GroupBy(m => new { m.Funding_Sources.FundCodeName, m.TransDate.Month }).Select(m => new DateObject() { fundName = m.Key.FundCodeName, transAmount = m.Sum(k => k.TransAmount) });
                    test = byFundSource.GroupBy(m => m.fundName).ToDictionary(t => t.Key, t => t.Select(g => g.transAmount).ToList());
                    return test;
                }
                
                              
                
            }
            //var t = transactions.Select(m => new { value = m.FundMasterID, text = m.Funding_Sources.FundCodeName }).GroupBy(m => m.text);
            
        }

        public IList<CategoryAmount> GetCategories(int? id)
        {
            using (var context = new transcendenceEntities())
            {
                return context.getCategoryAmounts(id);
            }
        }

        public Dictionary<string, List<decimal?>> GetEmployeeTransactions(int? id, int? empl)
        {
            Dictionary<string, List<decimal?>> test;
            using (var context = new transcendenceEntities())
            {
                var allTransactions = context.Transactions.Where(g => g.DeptID == id && g.StaffID == empl).OrderBy(m => m.TransDate).ToList();
                var byFundSource = allTransactions.GroupBy(m => new { m.Funding_Sources.FundCategory, m.TransDate.Month }).Select(m => new DateObject() { fundName = m.Key.FundCategory, transAmount = m.Sum(k => k.TransAmount) });
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
