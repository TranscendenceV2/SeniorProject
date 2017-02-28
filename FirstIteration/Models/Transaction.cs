//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FirstIteration.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int DeptID { get; set; }
        public string FundMasterID { get; set; }
        public string TransType { get; set; }
        public System.DateTime TransDate { get; set; }
        public decimal TransTransfer { get; set; }
        public decimal TransAdjustment { get; set; }
        public decimal TransCredit { get; set; }
        public decimal TransCharge { get; set; }
        public Nullable<decimal> TransAmount { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Funding_Sources Funding_Sources { get; set; }
    }
}