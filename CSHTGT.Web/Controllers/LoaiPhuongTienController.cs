using CSHTGT.Data.Context;
using CSHTGT.Service.IService;
using CSHTGT.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        //localhost:port/api/LoaiPhuongTien
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var loaiphuongtien = await _loaiPhuongTienService.GetAll();
            return Ok(loaiphuongtien);
        }
    }
}
