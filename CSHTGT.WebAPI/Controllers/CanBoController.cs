using CSHTGT.Service.IService;
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
    public class CanBoController : ControllerBase
    {
        private readonly ICanBoService _canboService;
        public CanBoController(ICanBoService canboService)
        {
            _canboService =canboService;           
        }
        //----------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> getAllCanBo()
        {
            var canbo = await _canboService.GetAll();
            return Ok(canbo);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CanBoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _canboService.Create(model);
            return Ok(result);
        }
        [HttpDelete("{canboid}")]
        public async Task<IActionResult> Delete(int canboid)
        {
            var result = await _canboService.Delete(canboid);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]CanBoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _canboService.Edit(model);
            return Ok(result);
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> getCanBoById(int id)
        {
            var category = await _canboService.getById(id);
            return Ok(category);
        }
    }
}
