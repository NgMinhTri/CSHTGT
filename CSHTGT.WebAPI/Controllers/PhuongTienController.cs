using CSHTGT.Service.IService;
using CSHTGT.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSHTGT.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhuongTienController : ControllerBase
    {
        private readonly IPhuongTienService _phuongTienService;      
        public PhuongTienController(IPhuongTienService phuongTienService)
        {
            _phuongTienService = phuongTienService;          
        }

        [HttpGet]
        public async Task<IActionResult> getAllPhuongTien()
        {
            var phuongtien = await _phuongTienService.GetAll();
            return Ok(phuongtien);
        }
        //[HttpGet("id")]
        //public async Task<IActionResult> getPhuongTienById(int id)
        //{
        //    var phuongtien = await _phuongTienService.GetById(id);
        //    return Ok(phuongtien);
        //}
        //tạo mới hồ sơ đăng kí MỚI bao gồm NTGGT VÀ PHƯƠNG TIỆN
        [HttpPost]
        public async Task<IActionResult> CreateNTGGT_PT([FromBody] PhuongTien_NTGGTViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _phuongTienService.Create_NTGGT_PT(model);
            return Ok(result);
        }
        //TẠO HỒ SƠ ĐĂNG KÍ KHI ĐÃ CÓ NTGGT, CHỈ CẦN NHẬP PHƯƠNG TIỆN
        [HttpPost("phuongtien")]
        [Authorize]
        public async Task<IActionResult> CreatePT([FromBody]PhuongTienViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _phuongTienService.CreatePT(model);
            return Ok(result);
        }

        [HttpDelete("phuongtienid")]
        public async Task<IActionResult> Delete(int phuongtienid)
        {
            var result = await _phuongTienService.Delete(phuongtienid);
            if (result == 0)
                return BadRequest();
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] PhuongTien_NTGGTViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _phuongTienService.Edit(model);
            return Ok(result);
        }

        //[HttpGet("UserName")]
        //public async Task<IActionResult> getNguoiThamGiaGiaoThongByUserName(string username)
        //{
        //    var phuongtien = await _phuongTienService.GetNgTGGTByUserName(username);
        //    return Ok(phuongtien);
        //}

    }
}
