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
    public class PhieuDangKyThuTucController : ControllerBase
    {
        private readonly IPhieuDangKyThuTucService _phieuDangKyThuTucService;

        public PhieuDangKyThuTucController(IPhieuDangKyThuTucService phieuDangKyThuTucService)
        {
            _phieuDangKyThuTucService = phieuDangKyThuTucService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllPhieuDangKyThuTuc()
        {
            var phieu = await _phieuDangKyThuTucService.GetAll();
            return Ok(phieu);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PhieuDangKyThuTucViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _phieuDangKyThuTucService.CreatePDK(model);
            return Ok(result);
        }
    }
}
