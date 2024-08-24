using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_Reservation.Models;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace Hotel_Reservation.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly InvoiceService _invoiceService;
        private readonly EmailService _emailService;

        public RoomsController(ModelContext context, IWebHostEnvironment environment, InvoiceService invoiceService, EmailService emailService)
        {
            _context = context;
            _environment = environment;
            _invoiceService = invoiceService;
            _emailService = emailService;
        }

        // GET: Rooms
        public async Task<IActionResult> Index(decimal? hotelId)
        {
            var modelContext = _context.Rooms.Include(r => r.Hotel).Include(r => r.UserLogin).AsQueryable();

            if (hotelId.HasValue)
            {
                modelContext = modelContext.Where(r => r.HotelId == hotelId);
            }

            return View(await modelContext.ToListAsync());
        }


        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Hotel)
                .Include(r => r.UserLogin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Id");
            ViewData["UserLoginId"] = new SelectList(_context.UserLogins, "Id", "Id");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageFile,RoomName,NumberOfBeds,Status,HotelId,UserLoginId,Price")] Room room)
        {
            if (ModelState.IsValid)
            {
                if (room.ImageFile != null)
                {
                    //path 
                    string wwwRootPath = _environment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + room.ImageFile.FileName;
                    //GUID ==> global unique identefier
                    string path = Path.Combine(wwwRootPath + "/NewFolder/", fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await room.ImageFile.CopyToAsync(fileStream);
                    }

                    room.ImagePath = fileName;
                }
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Id", room.HotelId);
            ViewData["UserLoginId"] = new SelectList(_context.UserLogins, "Id", "Id", room.UserLoginId);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Id", room.HotelId);
            ViewData["UserLoginId"] = new SelectList(_context.UserLogins, "Id", "Id", room.UserLoginId);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,ImagePath,RoomName,NumberOfBeds,Status,HotelId,UserLoginId,Price")] Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Id))
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
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Id", room.HotelId);
            ViewData["UserLoginId"] = new SelectList(_context.UserLogins, "Id", "Id", room.UserLoginId);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Hotel)
                .Include(r => r.UserLogin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Rooms == null)
            {
                return Problem("Entity set 'ModelContext.Rooms'  is null.");
            }
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(decimal id)
        {
            return (_context.Rooms?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> BookRoom(decimal roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room == null)
            {
                return NotFound();
            }

            // Initialize the view model with room details
            var viewModel = new RoomBookingViewModel
            {
                RoomId = room.Id,
                BookingDate = DateTime.Now,
                Room = room
            };

            return View(viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmBooking(RoomBookingViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel); // Return the form with validation errors if any
            }

            var room = await _context.Rooms.FindAsync(viewModel.RoomId);
            if (room == null)
            {
                return NotFound();
            }

            // Validate the card information
            var card = await _context.PaymentData
                .FirstOrDefaultAsync(p => p.CardNumber == viewModel.CardNumber && p.ExpirationDate == viewModel.ExpirationDate);

            if (card == null || card.Balance < room.Price)
            {
                ModelState.AddModelError("", "Invalid card details or insufficient funds.");
                return View(viewModel); // Return the view with an error message
            }

            // Deduct the price from the card balance
            card.Balance -= (decimal)room.Price;
            _context.Update(card);
            await _context.SaveChangesAsync();

            // Create a new booking record
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!decimal.TryParse(userId, out decimal userIdDecimal))
            {
                return Unauthorized(); // Handle invalid or missing user ID
            }

            var booking = new RoomBookingViewModel
            {
                RoomId = room.Id,
                UserId = userIdDecimal,
                PaymentCardId = card.Id, // Make sure to store the correct card ID
                BookingDate = viewModel.BookingDate
            };

            _context.Add(booking);
            await _context.SaveChangesAsync();

            // Generate PDF invoice
            var invoice = new Invoice
            {
                Id = booking.Id,
                Amount = (decimal)room.Price,
                Date = DateTime.Now
            };

            var pdfBytes = _invoiceService.GenerateInvoicePdf(invoice);

            // Send email with PDF attachment
            await _emailService.SendEmailWithAttachmentAsync(viewModel.Email, pdfBytes, "Your Invoice", "Please find your invoice attached.");

            return RedirectToAction("Index");
        }




    }
}