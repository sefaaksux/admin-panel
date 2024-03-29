﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using admin_panel.Models;
using admin_panel.Data;
using admin_panel.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace admin_panel.Controllers;

public class HomeController : Controller
{
    private readonly MyContext _context;
    public HomeController(MyContext context)
    {
        _context = context;
    }
    public IActionResult AdminIndex()
    {
        return View();
    }
    public IActionResult login()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {   
        var product =await _context.urunler
                    .Include(x => x.Tablo)
                    .Include(x => x.Kategori)
                    .FirstOrDefaultAsync(x => x.Id == id);

        ViewBag.Tablolar = new SelectList(_context.tablolar.ToList(),"tabloId","tabloName");
        ViewBag.Kategoriler = new SelectList(_context.kategoriler.ToList(),"kategoriId","kategoriName"); 
        if (product == null)
        {
            return NotFound(); // Ürün bulunamazsa hata sayfasına yönlendirme yapabilirsiniz
        }

        
       return View(product);
    }

    public async Task<IActionResult> Menu(string category)
    {
        ViewBag.category = category;

        var filteredProduct = await _context.urunler
                            .Include(x => x.Tablo)
                            .Where(x => x.Tablo.tabloName == category)
                            .ToListAsync();

        return View(filteredProduct);
    }  

    [HttpPost]
    public async Task<IActionResult> Update(Urun model, int id)
    {
            if(id != model.Id)
            {
               return NotFound();
            }

                try
                {
                    
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    
                }
                catch (System.Exception)
                {              
                    throw;
                }
            
            
            return RedirectToAction("AdminIndex");
    }

}
