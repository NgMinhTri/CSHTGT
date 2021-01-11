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
    public class BienBanViPhamController : ControllerBase
    {

        private readonly IBienBanViPhamService _bienBanViPhamService;

        public BienBanViPhamController(IBienBanViPhamService bienBanViPhamService)
        {
            _bienBanViPhamService = bienBanViPhamService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllBienBanViPham()
        {
            var bienban = await _bienBanViPhamService.getAll();
            return Ok(bienban);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BienBanViPhamViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _bienBanViPhamService.create(model);
            return Ok(result);
        }
        [HttpDelete("{mabienban}")]
        public async Task<IActionResult> Delete(int ngtggiaothongid)
        {
            var result = await _bienBanViPhamService.delete(ngtggiaothongid);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

       
    }
}
