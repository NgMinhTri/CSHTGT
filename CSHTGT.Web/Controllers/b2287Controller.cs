using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSHTGT.Data.Models;
using CSHTGT.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CSHTGT.Web.Controllers
{
    public class b2287Controller : Controller
    {
        private readonly CSHTGTDbContext _context;

        public b2287Controller(CSHTGTDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StringModel()
        {
            ViewData.Model = "Hello world from Home-Index action";
            var view = new ViewResult();
            view.ViewName = "/Views/Home/StringModel.cshtml";
            view.ViewData = ViewData;
            return view;
        }
        public IActionResult TupleModel()
        {
            ViewData.Model = ("Donald", "Trump", new DateTime(1900, 12, 31));
            var view = new ViewResult();
            view.ViewData = ViewData;
            return view;
        }
        public async Task<IActionResult> DoanhNghiepVantai()
        {
            return View(await _context.DoanhNghiepVanTais.ToListAsync());
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.DoanhNghiepVanTais.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
    }
}
