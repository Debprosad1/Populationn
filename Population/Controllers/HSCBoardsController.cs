using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Population.Data;
using Population.Models;

namespace Population.Controllers
{
    public class HSCBoardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HSCBoardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HSCBoards
        public async Task<IActionResult> Index()
        {
            return View(await _context.HSCBoards.ToListAsync());
        }

        // GET: HSCBoards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hSCBoards = await _context.HSCBoards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hSCBoards == null)
            {
                return NotFound();
            }

            return View(hSCBoards);
        }

        // GET: HSCBoards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HSCBoards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HSCBoard")] HSCBoards hSCBoards)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hSCBoards);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hSCBoards);
        }

        // GET: HSCBoards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hSCBoards = await _context.HSCBoards.FindAsync(id);
            if (hSCBoards == null)
            {
                return NotFound();
            }
            return View(hSCBoards);
        }

        // POST: HSCBoards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HSCBoard")] HSCBoards hSCBoards)
        {
            if (id != hSCBoards.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hSCBoards);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HSCBoardsExists(hSCBoards.Id))
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
            return View(hSCBoards);
        }

        // GET: HSCBoards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hSCBoards = await _context.HSCBoards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hSCBoards == null)
            {
                return NotFound();
            }

            return View(hSCBoards);
        }

        // POST: HSCBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hSCBoards = await _context.HSCBoards.FindAsync(id);
            _context.HSCBoards.Remove(hSCBoards);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HSCBoardsExists(int id)
        {
            return _context.HSCBoards.Any(e => e.Id == id);
        }
    }
}


