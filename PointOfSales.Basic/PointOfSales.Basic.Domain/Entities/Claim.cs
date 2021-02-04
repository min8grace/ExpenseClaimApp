using PointOfSales.Basic.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PointOfSales.Basic.Domain.Entities
{
    public enum Status
    {
        Requested =1 , Approved =2 , Rejected =3, Queried=4, Finance=5, RejectedByFinance=7, Ended=8
    }
    public class Claim : AuditableBaseEntity
    {
        [Required(ErrorMessage = "Custom Validation : Title must be provided")]
        [MinLength(5)]
        public string Title { get; set; }
        public int Requester { get; set; }
        public int Approver { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SubmitDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public Decimal TotalAmount { get; set; } //= 300.5m;
        public Status Status { get; set; }
        public string RequesterComments { get; set; }
        public string ApproverComments { get; set; }
        public string FinanceComments { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}

