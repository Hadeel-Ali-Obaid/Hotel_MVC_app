using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_Reservation.Models;

namespace Hotel_Reservation.Controllers
{
    public class PaymentDatumsController : Controller
    {
        private readonly ModelContext _context;

        public PaymentDatumsController(ModelContext context)
        {
            _context = context;
        }

        // GET: PaymentDatums
        public async Task<IActionResult> Index()
        {
              return _context.PaymentData != null ? 
                          View(await _context.PaymentData.ToListAsync()) :
                          Problem("Entity set 'ModelContext.PaymentData'  is null.");
        }

        // GET: PaymentDatums/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.PaymentData == null)
            {
                return NotFound();
            }

            var paymentDatum = await _context.PaymentData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentDatum == null)
            {
                return NotFound();
            }

            return View(paymentDatum);
        }

        // GET: PaymentDatums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentDatums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CardProvider,CardNumber,Balance,ExpirationDate")] PaymentDatum paymentDatum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentDatum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentDatum);
        }

        // GET: PaymentDatums/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.PaymentData == null)
            {
                return NotFound();
            }

            var paymentDatum = await _context.PaymentData.FindAsync(id);
            if (paymentDatum == null)
            {
                return NotFound();
            }
            return View(paymentDatum);
        }

        // POST: PaymentDatums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,CardProvider,CardNumber,Balance,ExpirationDate")] PaymentDatum paymentDatum)
        {
            if (id != paymentDatum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentDatum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentDatumExists(paymentDatum.Id))
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
            return View(paymentDatum);
        }

        // GET: PaymentDatums/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.PaymentData == null)
            {
                return NotFound();
            }

            var paymentDatum = await _context.PaymentData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentDatum == null)
            {
                return NotFound();
            }

            return View(paymentDatum);
        }

        // POST: PaymentDatums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.PaymentData == null)
            {
                return Problem("Entity set 'ModelContext.PaymentData'  is null.");
            }
            var paymentDatum = await _context.PaymentData.FindAsync(id);
            if (paymentDatum != null)
            {
                _context.PaymentData.Remove(paymentDatum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentDatumExists(decimal id)
        {
          return (_context.PaymentData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
