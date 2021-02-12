using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using HargaSaham.Models;

namespace HargaSaham.Controllers
{
    public class HomeController : Controller
    {
         

        private SahamContext context { get; set; }


        public HomeController(SahamContext ctx)
        {
            context = ctx;

        }


        public IActionResult Index()
        {
            // var sahams = context.Sahams.OrderBy(m => m.NamaSaham).ToList();
            var sahams = context.Sahams.Include(m=>m.Sektor).OrderBy(m=>m.NamaSaham).ToList();
            return View(sahams);
        }

       
    }
}
