using System.ComponentModel.DataAnnotations;

namespace Fixxo.Models.Dtos
{
    public class ProductOptionResponse
    {
        public Dictionary<int,List<ProductCollectionItemModel>> Result { get; set; } = null!;
    }
}
