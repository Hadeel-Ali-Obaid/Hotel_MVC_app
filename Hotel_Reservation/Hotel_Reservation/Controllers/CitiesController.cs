using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_Reservation.Models;
using Microsoft.Extensions.Hosting;

namespace Hotel_Reservation.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _environment;

        public CitiesController(ModelContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Cities
        public async Task<IActionResult> Index()
        {
              return _context.Cities != null ? 
                          View(await _context.Cities.ToListAsync()) :
                          Problem("Entity set 'ModelContext.Cities'  is null.");
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Cities == null)
            {
                return NotFound();
            }

            var city = await _context.Cities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CityName,ImageFile")] City city)
        {
            if (ModelState.IsValid)
            {
                if (city.ImageFile != null)
                {
                    //path 
                    string wwwRootPath = _environment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString()+"_"+city.ImageFile.FileName;
                    //GUID ==> global unique identefier
                    string path = Path.Combine(wwwRootPath+"/NewFolder/",fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await city.ImageFile.CopyToAsync(fileStream);
                    }

                    city.CityImagePath = fileName;
                }

                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Cities == null)
            {
                return NotFound();
            }

            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,CityName,ImageFile")] City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     if (city.ImageFile != null)
                {
                    //path 
                    string wwwRootPath = _environment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString()+"_"+city.ImageFile.FileName;
                    //GUID ==> global unique identefier
                    string path = Path.Combine(wwwRootPath+"/NewFolder/",fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await city.ImageFile.CopyToAsync(fileStream);
                    }

                    city.CityImagePath = fileName;
                }
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
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
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Cities == null)
            {
                return NotFound();
            }

            var city = await _context.Cities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Cities == null)
            {
                return Problem("Entity set 'ModelContext.Cities'  is null.");
            }
            var city = await _context.Cities.FindAsync(id);
            if (city != null)
            {
                _context.Cities.Remove(city);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(decimal id)
        {
          return (_context.Cities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
