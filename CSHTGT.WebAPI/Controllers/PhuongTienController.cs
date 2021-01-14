﻿using CSHTGT.Service.IService;
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
        
       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PhuongTienCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _phuongTienService.CreatePT(model);
            return Ok(result);
        }
        

        [HttpDelete]
        public async Task<IActionResult> Delete(int MaPT)
        {
            var result = await _phuongTienService.Delete(MaPT);
            if (result == 0)
                return BadRequest();
            return Ok();
        }


        //[HttpPut]
        //public async Task<IActionResult> Edit([FromBody] PhuongTien_NTGGTViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    var result = await _phuongTienService.Edit(model);
        //    return Ok(result);
        //}

        //[HttpGet("UserName")]
        //public async Task<IActionResult> getNguoiThamGiaGiaoThongByUserName(string username)
        //{
        //    var phuongtien = await _phuongTienService.GetNgTGGTByUserName(username);
        //    return Ok(phuongtien);
        //}

    }
}
