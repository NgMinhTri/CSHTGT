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
        [HttpPost]       
        public async Task<IActionResult> Create([FromBody]PhuongTienViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _phuongTienService.Create(model);
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
        public async Task<IActionResult> Edit([FromBody] PhuongTienViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _phuongTienService.Edit(model);
            return Ok(result);
        }
       
    }
}
