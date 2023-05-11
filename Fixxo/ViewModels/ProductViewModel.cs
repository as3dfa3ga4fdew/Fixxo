using Fixxo.Models;

namespace Fixxo.ViewModels
{
    public class ProductViewModel
    {
        public ProductModel Product {get;set;} = null!;
        public ProductCollectionModel RelatedProductCollection { get; set; } = null!;
    }
}
