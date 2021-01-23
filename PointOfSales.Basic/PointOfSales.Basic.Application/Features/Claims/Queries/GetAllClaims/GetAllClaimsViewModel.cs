using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSales.Basic.Application.Features.Claims.Queries.GetAllClaims
{
    public class GetAllClaimsViewModel
    {
        public int Id { get; set; }
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
    }
}
