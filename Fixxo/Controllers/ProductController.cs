using Fixxo.Models;
using Fixxo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fixxo.Controllers
{
    public class ProductController : Controller
    {
        private readonly string _url = "https://localhost:7091/api/";
        public async Task<IActionResult> Index(int id)
        {
            if(ModelState.IsValid) 
            { 
                ProductViewModel model = new ProductViewModel();

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("XApiKey", "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp");

                    model.Product = await client.GetFromJsonAsync<ProductModel>(_url + "product/id/" + id);


                    model.RelatedProductCollection = new ProductCollectionModel()
                    {
                        Title = "Related Products",
                        ProductCollectionItemModels = await client.GetFromJsonAsync<List<ProductCollectionItemModel>>(_url + "product/tag/name/Related")
                    };
                    

                }

                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
