namespace Fixxo.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public int Rating { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string ImagePath { get; set; } = null!;

    }
}
