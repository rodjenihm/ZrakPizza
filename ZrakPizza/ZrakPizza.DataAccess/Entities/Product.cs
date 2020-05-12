using System.Collections.Generic;

namespace ZrakPizza.DataAccess.Entities
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }

        public ICollection<ProductOption> ProductOptions { get; set; } = new List<ProductOption>();
    }
}
