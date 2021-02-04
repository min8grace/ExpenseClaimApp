using PointOfSales.Basic.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PointOfSales.Basic.Domain.Entities
{
    public class LineItem : AuditableBaseEntity
    {   
        public int ClaimId { get; set; }
        public int CategoryId { get; set; }
        public string Payee { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }

        public Decimal Amount { get; set; } //= 300.5m;
        public string CurrencyCode { get; set; }
        public Decimal USDAmount { get; set; } //= 300.5m;

        //public byte[] Receipt { get; set; }//image

        //public virtual Claim Claim { get; set; }
        public virtual Category Category { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
