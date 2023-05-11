using Fixxo.Models;

namespace Fixxo.ViewModels
{
    public class HomeViewModel
    {
        public ProductCollectionModel FeaturedProductCollection { get; set; } = null!;
        public ProductCollectionModel NewProductCollection { get; set; } = null!;
        public ProductCollectionModel PopularProductCollection { get; set; } = null!;

        public TagShowcaseModel NewShowcase { get; set; } = null!;
        public TagShowcaseModel PopularShowcase { get; set; } = null!;

    }
}
