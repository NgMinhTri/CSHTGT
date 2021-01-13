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

    public class GPLXController:ControllerBase
    {
        private readonly IGPLXService _gplxService;

        public GPLXController(IGPLXService gplxService)
        {
            _gplxService = gplxService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGPLX()
        {
            var gplx = await _gplxService.GetAll();
            return Ok(gplx);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GPLXViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _gplxService.Create(model);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] GPLXViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _gplxService.Edit(model);
            return Ok(result);
        }

        [HttpDelete("{idgplx}")]
        public async Task<IActionResult> Delete(int idgplx)
        {
            var result = await _gplxService.Delete(idgplx);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

    }
}
