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
    public class BienBanViPhamController : ControllerBase
    {
        public readonly IBienBanViPhamService _bienbanservice;

        public BienBanViPhamController(IBienBanViPhamService service)
        {
            _bienbanservice = service;
        }

        [HttpGet]
        public async Task<IActionResult> getAllBBVP()
        {
            var phuongtien = await _bienbanservice.getAll();
            return Ok(phuongtien);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BienBanViPhamViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _bienbanservice.create(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int ngtggiaothongid)
        {
            var result = await _bienbanservice.delete(ngtggiaothongid);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
