using CSHTGT.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace CSHTGT.WebApp.Controllers
{
    public class LoaiPhuongTienController : Controller
    {                 
        public ActionResult Index()
        {
            IEnumerable<LoaiPhuongTienViewModel> loaiphuongtien = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                //HTTP GET
                var responseTask = client.GetAsync("loaiphuongtien");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<LoaiPhuongTienViewModel>>();
                    readTask.Wait();

                    loaiphuongtien = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    loaiphuongtien = Enumerable.Empty<LoaiPhuongTienViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(loaiphuongtien);
        }        
    }
}
