using CSHTGT.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSHTGT.WebApp.Controllers
{
    public class CanBoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<CanBoViewModel> listCanBo = new List<CanBoViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/CanBo"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listCanBo = JsonConvert.DeserializeObject<List<CanBoViewModel>>(apiResponse);
                }
            }
            return View(listCanBo);
        }
        public IActionResult AddCanBo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCanBo(CanBoViewModel CanBoViewModel)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            var postTask = client.PostAsJsonAsync<CanBoViewModel>("api/CanBo", CanBoViewModel);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                TempData["result"] = "Đã thêm Cán bộ vào hệ thống";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Đã có lỗi khi thêm cán bộ");
            return View(CanBoViewModel);
        }

        public ActionResult DeleteCB(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var deleteTask = client.DeleteAsync("CanBo/" + id);
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["result"] = "Đã xóa Cán bộ khỏi hệ thống";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
