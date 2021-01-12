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
            List<PhuongTien_NTGGTViewModel> listPhuongTien = new List<PhuongTien_NTGGTViewModel>();            
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/PhuongTien"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listPhuongTien = JsonConvert.DeserializeObject<List<PhuongTien_NTGGTViewModel>>(apiResponse);                    
                }           
            }          
            return View(listPhuongTien);
        }
       // public ViewResult GetBYUserName() => View();

        //[HttpPost]
        //public async Task<IActionResult> GetBYUserName(string username)
        //{
        //    PhuongTien_NTGGTViewModel phuongtien = new PhuongTien_NTGGTViewModel();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("https://localhost:5001/api/phuongtien/" + username))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            phuongtien = JsonConvert.DeserializeObject<PhuongTien_NTGGTViewModel>(apiResponse);
        //        }
        //    }
        //    return View(phuongtien);
        //}
        //PHẦN XÓA DANH SÁCH ĐĂNG KÍ PHƯƠNG TIỆN       
        public ActionResult DeletePT_NTGGT(int id)
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

        //PHẦN ĐĂNG KÍ PHƯƠNG TIỆN_ĐĂNG KÍ MỚI GỒM CHỦ XE VÀ PHƯƠNG TIỆN
        public async Task<IActionResult> AddPhuongTienNTGGT()
        {
            List<LoaiPhuongTienViewModel> listLoaiPhuongTien = new List<LoaiPhuongTienViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/LoaiPhuongTien"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listLoaiPhuongTien = JsonConvert.DeserializeObject<List<LoaiPhuongTienViewModel>>(apiResponse);
                }
            }
            ViewData["MaLoaiPhuongTien"] = new SelectList(listLoaiPhuongTien, "ID", "TenLoai");
            return View();
        }

        [HttpPost]
        public IActionResult AddPhuongTienNTGGT(PhuongTien_NTGGTViewModel phuongTienViewModel)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            var postTask = client.PostAsJsonAsync<PhuongTien_NTGGTViewModel>("api/PhuongTien", phuongTienViewModel);
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

        // PHẦN ĐĂNG KÍ PHƯƠNG TIỆN_ĐĂNG KÍ MỚI GỒM CHỦ XE VÀ PHƯƠNG TIỆN
        public async Task<IActionResult> AddPhuongTien()
        {
            List<LoaiPhuongTienViewModel> listLoaiPhuongTien = new List<LoaiPhuongTienViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/LoaiPhuongTien"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listLoaiPhuongTien = JsonConvert.DeserializeObject<List<LoaiPhuongTienViewModel>>(apiResponse);
                }
            }
            ViewData["MaLoaiPhuongTien"] = new SelectList(listLoaiPhuongTien, "ID", "TenLoai");
            return View();
        }

        [HttpPost]
        public IActionResult AddPhuongTien(PhuongTienViewModel ViewModel)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            var postTask = client.PostAsJsonAsync<PhuongTienViewModel>("api/PhuongTien/phuongtien", ViewModel);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                TempData["result"] = "Đăng kí phương tiện thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Đăng kí phương tiện thất bại");
            return View(ViewModel);
        }



    }
}
