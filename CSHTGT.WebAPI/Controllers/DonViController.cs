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
    public class DonViController:ControllerBase
    {
        private readonly IDonViService _DonViService;
        public DonViController(IDonViService donviService)
        {
            _DonViService = donviService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDonVi()
        {
            var donvi = await _DonViService.GetAll();
            return Ok(donvi);
        }
    }
}
