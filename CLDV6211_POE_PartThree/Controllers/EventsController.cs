﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLDV6211_POE_PartThree.Data;
using CLDV6211_POE_PartThree.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Components.Forms;


namespace CLDV6211_POE_PartThree.Controllers
{
    public class EventsController : Controller
    {
        private readonly CLDV6211_POE_PartThreeContext _context;

        public EventsController(CLDV6211_POE_PartThreeContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index(string searchString)
        {

            if (_context.Event == null)
            {
                return Problem("Entity set 'CLDV6211_POE_PartThreeContext.'  is null.");
            }

            var events = from m in _context.Event
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(s => s.EventName!.ToUpper().Contains(searchString.ToUpper()));
            }


            return View(await events.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventName,Description,EventDate")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int id)
        {


            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EventName,Description,EventDate")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
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
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool isBookingExists = await _context.Booking.AnyAsync(b => b.EventId == id);


            // Check if there are any bookings associated with the event
            if (isBookingExists)
            {
                var @event = await _context.Event.FindAsync(id);
                ModelState.AddModelError("", "Cannot delete event as it has associated bookings.");
                return View(@event);
            }

            var eventToDelete = await _context.Event.FindAsync(id);

            _context.Event.Remove(eventToDelete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventId == id);
        }


    }
}
//var events = await _context.Event
//                .Where(e => e.EventDate >= start && e.EventDate <= end)
//                .ToListAsync();
//return events.Any();