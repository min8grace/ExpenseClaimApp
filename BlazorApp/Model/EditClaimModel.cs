using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Model
{
    public class EditClaimModel
    {
        [Required(ErrorMessage = "Custom Validation : Title must be provided")]
        [MinLength(5)]
        public string Title { get; set; }
        public int Requester { get; set; }
        public int Approver { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        public Decimal TotalAmount { get; set; } = 300.5m;
        public Status Status { get; set; }
        public string RequesterComments { get; set; }
        public string ApproverComments { get; set; }
        public string FinanceComments { get; set; }

        [ValidateComplexType]
        public virtual ICollection<LineItem> LineItems { get; set; } = new Collection<LineItem>();
    }
}
