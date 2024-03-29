﻿using System;
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
    public class BloodGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BloodGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BloodGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.BloodGroups.ToListAsync());
        }

        // GET: BloodGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodGroups = await _context.BloodGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodGroups == null)
            {
                return NotFound();
            }

            return View(bloodGroups);
        }

        // GET: BloodGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BloodGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BloodGroup")] BloodGroups bloodGroups)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bloodGroups);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bloodGroups);
        }

        // GET: BloodGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodGroups = await _context.BloodGroups.FindAsync(id);
            if (bloodGroups == null)
            {
                return NotFound();
            }
            return View(bloodGroups);
        }

        // POST: BloodGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BloodGroup")] BloodGroups bloodGroups)
        {
            if (id != bloodGroups.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloodGroups);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodGroupsExists(bloodGroups.Id))
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
            return View(bloodGroups);
        }

        // GET: BloodGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodGroups = await _context.BloodGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodGroups == null)
            {
                return NotFound();
            }

            return View(bloodGroups);
        }

        // POST: BloodGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bloodGroups = await _context.BloodGroups.FindAsync(id);
            _context.BloodGroups.Remove(bloodGroups);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloodGroupsExists(int id)
        {
            return _context.BloodGroups.Any(e => e.Id == id);
        }
    }
}
