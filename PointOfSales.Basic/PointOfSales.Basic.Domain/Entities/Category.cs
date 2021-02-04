using PointOfSales.Basic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSales.Basic.Domain.Entities
{
    public class Category 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<LineItem> LineItems { get; set; }
    }
}
