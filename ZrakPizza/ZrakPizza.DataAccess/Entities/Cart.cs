using System;
using System.Collections.Generic;
using System.Text;

namespace ZrakPizza.DataAccess.Entities
{
    public class Cart
    {
        public string Id { get; set; }
        public int ItemsCount { get; set; }
        public decimal ItemsTotalPrice { get; set; }

        public ICollection<Variant> Items { get; set; } = new List<Variant>();
    }
}
