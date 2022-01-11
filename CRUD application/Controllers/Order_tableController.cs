using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_application.Models;

namespace CRUD_application.Controllers
{
    public class Order_tableController : Controller
    {
        private readonly DataDbContext _context;

        public Order_tableController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Order_table
        public async Task<IActionResult> Index()
        {
            return View(await _context.Order_table.ToListAsync());
        }

        // GET: Order_table/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_table = await _context.Order_table
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order_table == null)
            {
                return NotFound();
            }

            return View(order_table);
        }

        // GET: Order_table/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order_table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,description,quantity,price")] Order_table order_table)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order_table);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order_table);
        }

        // GET: Order_table/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_table = await _context.Order_table.FindAsync(id);
            if (order_table == null)
            {
                return NotFound();
            }
            return View(order_table);
        }

        // POST: Order_table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,description,quantity,price")] Order_table order_table)
        {
            if (id != order_table.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order_table);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Order_tableExists(order_table.Id))
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
            return View(order_table);
        }

        // GET: Order_table/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_table = await _context.Order_table
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order_table == null)
            {
                return NotFound();
            }

            return View(order_table);
        }

        // POST: Order_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order_table = await _context.Order_table.FindAsync(id);
            _context.Order_table.Remove(order_table);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Order_tableExists(int id)
        {
            return _context.Order_table.Any(e => e.Id == id);
        }
    }
}
