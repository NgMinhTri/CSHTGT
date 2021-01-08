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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PhuongTienViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _phuongTienService.Create(model);
            return Ok(result);
        }
    }
}
