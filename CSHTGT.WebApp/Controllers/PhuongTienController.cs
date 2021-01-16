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
            List<PhuongTienGetViewModel> listPhuongTien = new List<PhuongTienGetViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/PhuongTien"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listPhuongTien = JsonConvert.DeserializeObject<List<PhuongTienGetViewModel>>(apiResponse);
                }
            }
            return View(listPhuongTien);
        }

        //PHẦN XÓA DANH SÁCH ĐĂNG KÍ PHƯƠNG TIỆN       




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
        public IActionResult AddPhuongTien(PhuongTienCreateViewModel ViewModel)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            var postTask = client.PostAsJsonAsync<PhuongTienCreateViewModel>("api/PhuongTien", ViewModel);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                TempData["result"] = "Đăng kí phương tiện thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", " CMND không tồn tại hoặc biển số trùng");
            return View(ViewModel);
        }


        public ActionResult DeletePT(int id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);
            
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var deleteTask = client.DeleteAsync("PhuongTien/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["result"] = "Đã xóa hồ sơ đăng kí";
                    return RedirectToAction("Index");

                }
            
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdatePT(int id)
        {
            PhuongTienUpdateViewModel phuongtien = new PhuongTienUpdateViewModel();
            List<LoaiPhuongTienViewModel> listLoaiPhuongTien = new List<LoaiPhuongTienViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/LoaiPhuongTien"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listLoaiPhuongTien = JsonConvert.DeserializeObject<List<LoaiPhuongTienViewModel>>(apiResponse);
                }
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/PhuongTien/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    phuongtien = JsonConvert.DeserializeObject<PhuongTienUpdateViewModel>(apiResponse);
                }
            }
            ViewData["MaLoaiPhuongTien"] = new SelectList(listLoaiPhuongTien, "ID", "TenLoai");
            return View(phuongtien);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePT(PhuongTienUpdateViewModel phuongtien)
        {
            PhuongTienUpdateViewModel receivedPhuongTien= new PhuongTienUpdateViewModel();
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(phuongtien.TenPT), "TenPT");
                content.Add(new StringContent(phuongtien.BienSo), "BienSo");
                content.Add(new StringContent(phuongtien.SoChoNgoi.ToString()), "SoChoNgoi");
                content.Add(new StringContent(phuongtien.SoKhung), "SoKhung");
                content.Add(new StringContent(phuongtien.NhanHieu), "NhanHieu");
                content.Add(new StringContent(phuongtien.SoMay), "SoMay");
                content.Add(new StringContent(phuongtien.TaiTrong), "SoKhung");
                content.Add(new StringContent(phuongtien.TrangThai), "TrangThai");
               
                content.Add(new StringContent(phuongtien.MaLoaiPhuongTien.ToString()), "MaLoaiPhuongTien");
                using (var response = await httpClient.PutAsync("https://localhost:5001/api/PhuongTien", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    
                    receivedPhuongTien = JsonConvert.DeserializeObject<PhuongTienUpdateViewModel>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
