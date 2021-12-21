using System;
using System.Collections.Generic;
using System.Text;

namespace Stressies.Domain
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int QuantityInStock { get; set; }
        public decimal ProductPrice { get; set; }

    }
}
