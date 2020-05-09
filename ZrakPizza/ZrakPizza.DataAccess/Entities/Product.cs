﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ZrakPizza.DataAccess.Entities
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }

        public ICollection<VariantOptions> VariantOptions { get; set; } = new List<VariantOptions>();
    }
}
