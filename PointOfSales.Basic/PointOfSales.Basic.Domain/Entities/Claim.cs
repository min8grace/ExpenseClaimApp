using PointOfSales.Basic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSales.Basic.Domain.Entities
{
    public class Claim : AuditableBaseEntity
    {
        public string Title { get; set; }
        public int Requester { get; set; }
        public int Approver { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        public int TotalAmount { get; set; }
        public string Status { get; set; }
        public string RequesterComments { get; set; }
        public string ApproverComments { get; set; }
        public string FinanceComments { get; set; }

        public virtual ICollection<ClaimLineItem> ClaimLineItem { get; set; }
    }
}

