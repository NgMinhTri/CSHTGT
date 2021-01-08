using CSHTGT.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSHTGT.WebApp.Controllers
{
    public class PhuongTienController : Controller
    {
        public IActionResult Index()
        {
            

            return View();
        }

       

        public ViewResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(PhuongTienViewModel phuongTienViewModel)
        {
            PhuongTienViewModel receivedPhuongTien = new PhuongTienViewModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(phuongTienViewModel), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:5001/api/PhuongTien", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    receivedPhuongTien = JsonConvert.DeserializeObject<PhuongTienViewModel>(apiResponse);
                }
            }
            return View(receivedPhuongTien);
        }
    }
}
