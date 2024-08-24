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
    public class HotelsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _environment;


        public HotelsController(ModelContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Hotels
        public async Task<IActionResult> Index(decimal? selectedCityId, decimal? selectedRate, decimal? selectedRoomPrice, string? searchTerm)
        {
            // Fetch filter options
            var cities = await _context.Cities.ToListAsync();
            var rates = await _context.Hotels.Select(h => h.Rate).Distinct().ToListAsync();
            var roomPrices = await _context.Rooms.Select(r => r.Price).Distinct().ToListAsync();

            // Create view model with filter options and selected values
            var viewModel = new HotelFilterViewModel
            {
                Cities = new SelectList(cities, "Id", "CityName"),
                Rates = new SelectList(rates.Select(r => new { Value = r, Text = r.ToString() }), "Value", "Text"),
                RoomPrices = new SelectList(roomPrices.Select(p => new { Value = p, Text = p.ToString() }), "Value", "Text"),
                SelectedCityId = selectedCityId,
                SelectedRate = selectedRate,
                SelectedRoomPrice = selectedRoomPrice,
                SearchTerm = searchTerm
            };

            // Filter hotels based on selected criteria
            var hotelsQuery = _context.Hotels.Include(h => h.City).Include(h => h.Rooms).AsQueryable();

            // Apply search filter by hotel name
            if (!string.IsNullOrEmpty(searchTerm))
            {
                hotelsQuery = hotelsQuery.Where(h => h.HotelName.Contains(searchTerm));
            }

            // Apply city filter if selected
            if (selectedCityId.HasValue)
            {
                hotelsQuery = hotelsQuery.Where(h => h.CityId == selectedCityId);
            }

            // Apply rate filter if selected
            if (selectedRate.HasValue)
            {
                hotelsQuery = hotelsQuery.Where(h => h.Rate == selectedRate);
            }

            // Apply room price filter if selected
            if (selectedRoomPrice.HasValue)
            {
                hotelsQuery = hotelsQuery.Where(h => h.Rooms.Any(r => r.Price == selectedRoomPrice));
            }

            // Retrieve the filtered hotels
            viewModel.Hotels = await hotelsQuery.ToListAsync();

            return View(viewModel);
        }

        // Redirect to RoomsController.Index with the selected hotel ID
        public IActionResult RedirectToRooms(decimal hotelId)
        {
            return RedirectToAction("Index", "Rooms", new { hotelId });
        }




        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Hotels == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels
                .Include(h => h.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id");
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HotelName,ImageFile,Location,City,Discription,Rate,Policies,CityId")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                if (hotel.ImageFile != null)
                {
                    //path 
                    string wwwRootPath = _environment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + hotel.ImageFile.FileName;
                    //GUID ==> global unique identefier
                    string path = Path.Combine(wwwRootPath + "/NewFolder/", fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await hotel.ImageFile.CopyToAsync(fileStream);
                    }

                    hotel.ImagePath = fileName;
                }
                _context.Add(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", hotel.CityId);
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Hotels == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", hotel.CityId);
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,HotelName,ImagePath,Location,City,Discription,Rate,Policies,CityId")] Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    if (hotel.ImageFile != null)
                    {
                        //path 
                        string wwwRootPath = _environment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + hotel.ImageFile.FileName;
                        //GUID ==> global unique identefier
                        string path = Path.Combine(wwwRootPath + "/NewFolder/", fileName);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await hotel.ImageFile.CopyToAsync(fileStream);
                        }

                        hotel.ImagePath = fileName;
                    }
                    _context.Update(hotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.Id))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", hotel.CityId);
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Hotels == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels
                .Include(h => h.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Hotels == null)
            {
                return Problem("Entity set 'ModelContext.Hotels'  is null.");
            }
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(decimal id)
        {
          return (_context.Hotels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
