using CSHTGT.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSHTGT.WebApp.Controllers
{
    public class PhuongTienController : Controller
    {
                                     //LẤY RA DANH SÁCH PHƯƠNG TIEENH ĐÃ ĐÁNG KÍ
        public async Task<IActionResult> Index()
        {
            List<PhuongTienViewModel> listPhuongTien = new List<PhuongTienViewModel>();            
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/PhuongTien"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listPhuongTien = JsonConvert.DeserializeObject<List<PhuongTienViewModel>>(apiResponse);                    
                }           
            }          
            return View(listPhuongTien);
        }

        //PHẦN XÓA DANH SÁCH ĐĂNG KÍ PHƯƠNG TIỆN       
        public ActionResult DeletePT(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("PhuongTien/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        //PHẦN ĐĂNG KÍ PHƯƠNG TIỆN_ĐĂNG KÍ MỚI
        public async Task<IActionResult> AddPhuongTien()
        {
            List<LoaiPhuongTienViewModel> listLoaiPhuongTien = new List<LoaiPhuongTienViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response =await httpClient.GetAsync("https://localhost:5001/api/LoaiPhuongTien"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listLoaiPhuongTien = JsonConvert.DeserializeObject<List<LoaiPhuongTienViewModel>>(apiResponse);
                }
            }
            ViewData["MaLoaiPhuongTien"] = new SelectList(listLoaiPhuongTien, "ID", "TenLoai");
            return View();
        }
        
        [HttpPost]
        public IActionResult AddPhuongTien(PhuongTienViewModel phuongTienViewModel)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            var postTask = client.PostAsJsonAsync<PhuongTienViewModel>("api/phuongtien", phuongTienViewModel);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                TempData["result"] = "Đăng kí phương tiện thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Đăng kí phương tiện thất bại");
            return View(phuongTienViewModel);
        }

       

    }
}
