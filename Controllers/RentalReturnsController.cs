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
    public class RentalReturnsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalReturnsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RentalReturns
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RentalReturn.Include(r => r.Customer).Include(r => r.Rental);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RentalReturns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalReturn = await _context.RentalReturn
                .Include(r => r.Customer)
                .Include(r => r.Rental)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalReturn == null)
            {
                return NotFound();
            }

            return View(rentalReturn);
        }

        // GET: RentalReturns/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name");
            ViewData["RentalId"] = new SelectList(_context.Rental, "Id", "CustomerId");
            return View();
        }

        // POST: RentalReturns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RentalId,CustomerId,ReturnDate,LateFee,CreatedAt,UpdatedAt")] RentalReturn rentalReturn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalReturn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name", rentalReturn.CustomerId);
            ViewData["RentalId"] = new SelectList(_context.Rental, "Id", "CustomerId", rentalReturn.RentalId);
            return View(rentalReturn);
        }

        // GET: RentalReturns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalReturn = await _context.RentalReturn.FindAsync(id);
            if (rentalReturn == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name", rentalReturn.CustomerId);
            ViewData["RentalId"] = new SelectList(_context.Rental, "Id", "CustomerId", rentalReturn.RentalId);
            return View(rentalReturn);
        }

        // POST: RentalReturns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RentalId,CustomerId,ReturnDate,LateFee,CreatedAt,UpdatedAt")] RentalReturn rentalReturn)
        {
            if (id != rentalReturn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalReturn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalReturnExists(rentalReturn.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name", rentalReturn.CustomerId);
            ViewData["RentalId"] = new SelectList(_context.Rental, "Id", "CustomerId", rentalReturn.RentalId);
            return View(rentalReturn);
        }

        // GET: RentalReturns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalReturn = await _context.RentalReturn
                .Include(r => r.Customer)
                .Include(r => r.Rental)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalReturn == null)
            {
                return NotFound();
            }

            return View(rentalReturn);
        }

        // POST: RentalReturns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalReturn = await _context.RentalReturn.FindAsync(id);
            if (rentalReturn != null)
            {
                _context.RentalReturn.Remove(rentalReturn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalReturnExists(int id)
        {
            return _context.RentalReturn.Any(e => e.Id == id);
        }
    }
}
