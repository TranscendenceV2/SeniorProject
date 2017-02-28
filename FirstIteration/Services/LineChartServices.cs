﻿using System;
using System.Collections.Generic;
using FirstIteration.Models;
using System.Linq;
using System.Web;

namespace FirstIteration.Services
{
    public class LineChartServices
    {
        public Dictionary<string, List<decimal?>> GetTransactionsByDeptID(int id)
        {

            Dictionary<string, List<decimal?>> dic;
            using (var context = new transcendenceEntities())
            {
                var transactions = context.Transactions.Where(t => t.DeptID == id).ToList();
                dic = transactions.GroupBy(m => m.Funding_Sources.FundCodeName).ToDictionary(t => t.Key, t => t.Select(g => g.TransAmount).ToList());
            }
            //var t = transactions.Select(m => new { value = m.FundMasterID, text = m.Funding_Sources.FundCodeName }).GroupBy(m => m.text);
            return dic;
        }


    }

}