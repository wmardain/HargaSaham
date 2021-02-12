using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HargaSaham.Models;

namespace HargaSaham.Controllers
{
    public class SahamController : Controller
    {
      
        private SahamContext context { get; set; }

        public SahamController(SahamContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Sektor = context.Sektors.OrderBy(m => m.Nama).ToList();
            return View("Edit",new Saham());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var saham = context.Sahams.Find(id);
            ViewBag.Sektor = context.Sektors.OrderBy(m => m.Nama).ToList();
            return View(saham);
        }
        
        [HttpPost]
        public IActionResult Edit(Saham saham)
        {
            if(ModelState.IsValid)
            { 
                if(saham.SahamID == 0)
                     context.Sahams.Add(saham);
                else
                     context.Sahams.Update(saham);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }    
            else
            {
                ViewBag.Action = saham.SahamID == 0 ? "Add" : "Edit";
                ViewBag.Sektor = context.Sektors.OrderBy(m => m.Nama).ToList();
                return View(saham);
            }
            
        }


    }
}
