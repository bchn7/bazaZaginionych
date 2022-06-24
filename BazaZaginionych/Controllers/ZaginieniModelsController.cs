using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BazaZaginionych.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BazaZaginionych.Controllers
{
    public class ZaginieniModelsController : Controller
    {
        private readonly ZaginieniDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ZaginieniModelsController(ZaginieniDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: ZaginieniModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zaginieni.ToListAsync());
        }

        // GET: ZaginieniModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaginieniModel = await _context.Zaginieni
                .FirstOrDefaultAsync(m => m.id == id);
            if (zaginieniModel == null)
            {
                return NotFound();
            }

            return View(zaginieniModel);
        }

        // GET: ZaginieniModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZaginieniModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Imie,Nazwisko,Opis,imageFile")] ZaginieniModel zaginieniModel)
        {
            if (ModelState.IsValid)
            {
                // To zapisze do folderu img
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(zaginieniModel.imageFile.FileName);
                string extension = Path.GetExtension(zaginieniModel.imageFile.FileName);
                zaginieniModel.ImageName=fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/img/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await zaginieniModel.imageFile.CopyToAsync(fileStream);
                }


                _context.Add(zaginieniModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zaginieniModel);
        }

        // GET: ZaginieniModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaginieniModel = await _context.Zaginieni.FindAsync(id);
            if (zaginieniModel == null)
            {
                return NotFound();
            }
            return View(zaginieniModel);
        }

        // POST: ZaginieniModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Imie,Nazwisko,Opis,ImageName")] ZaginieniModel zaginieniModel)
        {
            if (id != zaginieniModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zaginieniModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZaginieniModelExists(zaginieniModel.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(zaginieniModel);
        }

        // GET: ZaginieniModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaginieniModel = await _context.Zaginieni
                .FirstOrDefaultAsync(m => m.id == id);
            if (zaginieniModel == null)
            {
                return NotFound();
            }

            return View(zaginieniModel);
        }

        // POST: ZaginieniModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zaginieniModel = await _context.Zaginieni.FindAsync(id);

            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "img", zaginieniModel.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);


            _context.Zaginieni.Remove(zaginieniModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZaginieniModelExists(int id)
        {
            return _context.Zaginieni.Any(e => e.id == id);
        }
    }
}
