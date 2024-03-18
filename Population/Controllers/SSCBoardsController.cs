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
    public class SSCBoardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SSCBoardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SSCBoards
        public async Task<IActionResult> Index()
        {
            return View(await _context.SSCBoards.ToListAsync());
        }

        // GET: SSCBoards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sSCBoards = await _context.SSCBoards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sSCBoards == null)
            {
                return NotFound();
            }

            return View(sSCBoards);
        }

        // GET: SSCBoards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SSCBoards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SSCBoard")] SSCBoards sSCBoards)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sSCBoards);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sSCBoards);
        }

        // GET: SSCBoards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sSCBoards = await _context.SSCBoards.FindAsync(id);
            if (sSCBoards == null)
            {
                return NotFound();
            }
            return View(sSCBoards);
        }

        // POST: SSCBoards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SSCBoard")] SSCBoards sSCBoards)
        {
            if (id != sSCBoards.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sSCBoards);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SSCBoardsExists(sSCBoards.Id))
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
            return View(sSCBoards);
        }

        // GET: SSCBoards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sSCBoards = await _context.SSCBoards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sSCBoards == null)
            {
                return NotFound();
            }

            return View(sSCBoards);
        }

        // POST: SSCBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sSCBoards = await _context.SSCBoards.FindAsync(id);
            _context.SSCBoards.Remove(sSCBoards);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SSCBoardsExists(int id)
        {
            return _context.SSCBoards.Any(e => e.Id == id);
        }
    }
}
