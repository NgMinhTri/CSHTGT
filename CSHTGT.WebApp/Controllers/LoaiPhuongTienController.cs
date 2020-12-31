using CSHTGT.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSHTGT.WebApp.Controllers
{
    public class LoaiPhuongTienController : Controller
    {
        
            public IActionResult GetAll()
            {
                //return View();
                IEnumerable<LoaiPhuongTienViewModel> phuongtien = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5001/api/");
                    //HTTP GET
                    var responseTask = client.GetAsync("LoaiPhuongTien");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<LoaiPhuongTienViewModel>>();
                        readTask.Wait();

                        phuongtien = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        phuongtien = Enumerable.Empty<LoaiPhuongTienViewModel>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                return View(phuongtien);
            }
        
    }
}
