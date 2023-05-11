namespace Fixxo.Models
{
    public class ProductCollectionModel
    {
        public string Title { get; set; }

        public List<ProductCollectionItemModel> ProductCollectionItemModels { get; set; } = null!;
    }
}
