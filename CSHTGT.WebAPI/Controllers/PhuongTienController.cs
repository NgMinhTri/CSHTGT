using CSHTGT.Service.IService;
using CSHTGT.ViewModels;
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
        private readonly ILoaiPhuongTienService _loaiphuongtienService;

        public PhuongTienController(IPhuongTienService phuongTienService, 
            ILoaiPhuongTienService loaiphuongtienService)
        {
            _phuongTienService = phuongTienService;
            _loaiphuongtienService = loaiphuongtienService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllPhuongTien()
        {
            var phuongtien = await _phuongTienService.GetAll();
            return Ok(phuongtien);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PhuongTienViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _phuongTienService.Create(model);
            return Ok(result);
        }
        [HttpDelete("{ngtggiaothongid}")]
        public async Task<IActionResult> Delete(int ngtggiaothongid)
        {
            var result = await _phuongTienService.Delete(ngtggiaothongid);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
       
    }
}
