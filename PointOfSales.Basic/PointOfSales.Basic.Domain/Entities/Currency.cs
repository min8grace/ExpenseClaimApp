using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PointOfSales.Basic.Domain.Entities
{
    public class Currency
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }

        public ICollection<ClaimLineItem> ClaimLineItems { get; set; }
    }
}
