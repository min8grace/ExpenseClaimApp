using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSales.Basic.Application.Features.LineItems.Queries.GetAllLineItems
{
    public class GetAllLineItemsViewModel
    {
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public int CategoryId { get; set; }
        public string Payee { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public Decimal USDAmount { get; set; }

        //public byte[] Receipt { get; set; }//image

        //public virtual Claim Claim { get; set; }
        //public virtual Category Category { get; set; }
        //public virtual Currency Currency { get; set; }
    }
}
