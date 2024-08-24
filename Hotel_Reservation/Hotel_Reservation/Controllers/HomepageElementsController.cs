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
    public class HomepageElementsController : Controller
    {
        private readonly ModelContext _context;

        public HomepageElementsController(ModelContext context)
        {
            _context = context;
        }

        // GET: HomepageElements
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomepageElements.ToListAsync());
        }

        // GET: HomepageElements/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homepageElement = await _context.HomepageElements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homepageElement == null)
            {
                return NotFound();
            }

            return View(homepageElement);
        }

        // GET: HomepageElements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomepageElements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HeaderImgPath,HeaderQuoteHeadAr,HeaderQuoteHeadEn,HeaderQuoteAr,HeaderQuoteEn,Article1,Article2,Article3,Article4,Article5,Article6,ImgPath1,ImgPath2,ImgPath3,ImgPath4,ImgPath5,ImgPath6,ImgPath7,ImgPath8,ImgPath9,ImgPath10,ChefName1,ChefName2,ChefName3,ChefName4,TestimonialArticle1,TestimonialArticle2,TestimonialArticle3,TestimonialArticle4,TestimonialImgPath1,TestimonialImgPath2,TestimonialImgPath3,TestimonialImgPath4")] HomepageElement homepageElement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homepageElement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homepageElement);
        }

        // GET: HomepageElements/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homepageElement = await _context.HomepageElements.FindAsync(id);
            if (homepageElement == null)
            {
                return NotFound();
            }
            return View(homepageElement);
        }

        // POST: HomepageElements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,HeaderH1Text,HeaderImgPath,HeaderQuoteHeadAr,HeaderQuoteHeadEn,HeaderQuoteAr,HeaderQuoteEn,Article1,Article2,Article3,Article4,Article5,Article6,ImgPath1,ImgPath2,ImgPath3,ImgPath4,ImgPath5,ImgPath6,ImgPath7,ImgPath8,ImgPath9,ImgPath10,ChefName1,ChefName2,ChefName3,ChefName4,TestimonialArticle1,TestimonialArticle2,TestimonialArticle3,TestimonialArticle4,TestimonialImgPath1,TestimonialImgPath2,TestimonialImgPath3,TestimonialImgPath4")] HomepageElement homepageElement)
        {
            if (id != homepageElement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homepageElement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomepageElementExists(homepageElement.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(homepageElement);
        }

        // GET: HomepageElements/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homepageElement = await _context.HomepageElements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homepageElement == null)
            {
                return NotFound();
            }

            return View(homepageElement);
        }

        // POST: HomepageElements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var homepageElement = await _context.HomepageElements.FindAsync(id);
            _context.HomepageElements.Remove(homepageElement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomepageElementExists(decimal id)
        {
            return _context.HomepageElements.Any(e => e.Id == id);
        }
    }
}
