using System;
using System.Collections.Generic;

namespace EntityFrameworkWebAPTemplate.Models.DBModels
{
    public partial class OrderSubtotals
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
