using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Exercise.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Exercise.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration Configuration;
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetSample()
        {

            try
            {
                using (var client = new HttpClient())
                {
                    var url = Configuration["SampleDataUrl"];
                    var result = await client.GetAsync(url);

                    if (result != null && result.IsSuccessStatusCode)
                    {
                        var data = await result.Content.ReadAsStringAsync();

                        var model = JsonConvert.DeserializeObject<SampleModel>(data);

                        return View(model);
                    }

                    return Error();
                }

            }
            catch (Exception e)
            {
                //do something
                var msg = e.Message;
                return Error();
            }

        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
