using Fixxo.Extenstions;
using Fixxo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace Fixxo.Controllers
{
    public class ContactController : Controller
    {
        private readonly string _url = "https://localhost:7091/api/";
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactViewModel viewModel)
        {
            if(ModelState.IsValid)
            {

                using(HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("XApiKey", "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp");
                    var result = await client.PostAsJsonAsync(_url + "contact", viewModel);
                    
                    Console.WriteLine((int)result.StatusCode);

                    if((int)result.StatusCode != 201)
                    {
                        viewModel.Result = "Ooops something went wrong, please try again.";
                        return View(viewModel);
                    }
                }


                viewModel.Result = "We have received your message and we will contact your shortly.";
                return View(viewModel);
            }


            ModelState.DisplayErrors();

            return View(viewModel);
        }
    }
}
