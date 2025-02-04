using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoShopRentalMVC1.Data;
using VideoShopRentalMVC1.Models;

namespace VideoShopRentalMVC1.Controllers
{
    public class RentalDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RentalDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentalDetail.ToListAsync());
        }

        // GET: RentalDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalDetail = await _context.RentalDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalDetail == null)
            {
                return NotFound();
            }

            return View(rentalDetail);
        }

        // GET: RentalDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentalDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RentalHeaderId,MovieId,Movies,Price")] RentalDetail rentalDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalDetail);
        }

        // GET: RentalDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalDetail = await _context.RentalDetail.FindAsync(id);
            if (rentalDetail == null)
            {
                return NotFound();
            }
            return View(rentalDetail);
        }

        // POST: RentalDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RentalHeaderId,MovieId,Movies,Price")] RentalDetail rentalDetail)
        {
            if (id != rentalDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalDetailExists(rentalDetail.Id))
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
            return View(rentalDetail);
        }

        // GET: RentalDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalDetail = await _context.RentalDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalDetail == null)
            {
                return NotFound();
            }

            return View(rentalDetail);
        }

        // POST: RentalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalDetail = await _context.RentalDetail.FindAsync(id);
            if (rentalDetail != null)
            {
                _context.RentalDetail.Remove(rentalDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalDetailExists(int id)
        {
            return _context.RentalDetail.Any(e => e.Id == id);
        }
    }
}
