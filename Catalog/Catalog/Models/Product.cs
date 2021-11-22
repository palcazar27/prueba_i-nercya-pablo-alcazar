using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
