namespace ZrakPizza.DataAccess.Entities
{
    public class ProductVariant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string VariantDescription { get; set; }
        public decimal Price { get; set; }
    }
}
