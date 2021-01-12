using CSHTGT.Service.IService;
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
    public class LoaiPhuongTienController : ControllerBase
    {
        private readonly ILoaiPhuongTienService _loaiPhuongTienService;

        public LoaiPhuongTienController(ILoaiPhuongTienService loaiPhuongTienService)
        {
            _loaiPhuongTienService = loaiPhuongTienService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoaiPhuongTien()
        {
            var loaiPhuongTien = await _loaiPhuongTienService.GetAll();
            return Ok(loaiPhuongTien);
        }


    }
}
