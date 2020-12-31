using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSHTGT.WebApp.Controllers
{
    public class LoaiPhuongTienController : Controller
    {
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
