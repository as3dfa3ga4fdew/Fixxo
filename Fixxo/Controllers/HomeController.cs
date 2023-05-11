using Fixxo.Models;
using Fixxo.ViewModels;
using FixxoApi2.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Fixxo.Models.Dtos;

namespace Fixxo.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _url = "https://localhost:7091/api/";

        public async Task<IActionResult> Index()
        {
            HomeViewModel viewModel = new HomeViewModel();

            viewModel.PopularShowcase = new TagShowcaseModel()
            {
                Title = "2 FOR 39$",
                ButtonText = "To Popular",
                TagName = "Popular"
            };

            viewModel.NewShowcase = new TagShowcaseModel()
            {
                Title = "2 FOR 29$",
                ButtonText = "New Products",
                TagName = "New"
            };

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("XApiKey", "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp");

                var request = new ProductOptionRequest();
                request.Options = new List<ProductOption>()
                {
                    new ProductOption() { TagId = 1, Count = 8 },
                    new ProductOption() { TagId = 2, Count = 6 },
                    new ProductOption() { TagId = 3, Count = 6 }
                };

                var response = await client.PostAsJsonAsync(_url + "product/tag", request);
                var content = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<ProductOptionResponse>(content);

               
                viewModel.FeaturedProductCollection = new ProductCollectionModel()
                {
                    Title = "Featured Products",
                    ProductCollectionItemModels = json.Result[1]
                };

               
                viewModel.NewProductCollection = new ProductCollectionModel()
                {
                    ProductCollectionItemModels = json.Result[2]
                };

                
                viewModel.PopularProductCollection = new ProductCollectionModel()
                {
                    ProductCollectionItemModels = json.Result[3]
                };
            }


            return View(viewModel);
        }
    }
}
