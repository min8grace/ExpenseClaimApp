using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Model
{
    public class EditLineItemModel
    {
        public int ClaimId { get; set; }
        public int CategoryId { get; set; }
        public string Payee { get; set; }
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Custom Validation : Description must be provided")]
        [MinLength(5)]
        public string Description { get; set; }

        public Decimal Amount { get; set; } //= 300.5m;
        public string CurrencyCode { get; set; }
        public Decimal USDAmount { get; set; } //= 300.5m;
    }
}
