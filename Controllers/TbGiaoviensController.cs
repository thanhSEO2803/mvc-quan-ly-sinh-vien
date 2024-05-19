using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BT_QUANLYSINHVIEN.Data;

namespace BT_QUANLYSINHVIEN.Controllers
{
    public class TbGiaoviensController : Controller
    {
        private readonly DbQuanLySinhVienContext _context;

        public TbGiaoviensController(DbQuanLySinhVienContext context)
        {
            _context = context;
        }

        // GET: TbGiaoviens
        public async Task<IActionResult> Index()
        {
            var dbQuanLySinhVienContext = _context.TbGiaoviens.Include(t => t.MakhoaNavigation);
            return View(await dbQuanLySinhVienContext.ToListAsync());
        }

        // GET: TbGiaoviens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiaovien = await _context.TbGiaoviens
                .Include(t => t.MakhoaNavigation)
                .FirstOrDefaultAsync(m => m.Magiaovien == id);
            if (tbGiaovien == null)
            {
                return NotFound();
            }

            return View(tbGiaovien);
        }

        // GET: TbGiaoviens/Create
        public IActionResult Create()
        {
            ViewData["Makhoa"] = new SelectList(_context.TbKhoas, "Makhoa", "Makhoa");
            return View();
        }

        // POST: TbGiaoviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Magiaovien,Tengiaovien,Sdt,Diachi,Makhoa")] TbGiaovien tbGiaovien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbGiaovien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Makhoa"] = new SelectList(_context.TbKhoas, "Makhoa", "Makhoa", tbGiaovien.Makhoa);
            return View(tbGiaovien);
        }

        // GET: TbGiaoviens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiaovien = await _context.TbGiaoviens.FindAsync(id);
            if (tbGiaovien == null)
            {
                return NotFound();
            }
            ViewData["Makhoa"] = new SelectList(_context.TbKhoas, "Makhoa", "Makhoa", tbGiaovien.Makhoa);
            return View(tbGiaovien);
        }

        // POST: TbGiaoviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Magiaovien,Tengiaovien,Sdt,Diachi,Makhoa")] TbGiaovien tbGiaovien)
        {
            if (id != tbGiaovien.Magiaovien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbGiaovien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbGiaovienExists(tbGiaovien.Magiaovien))
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
            ViewData["Makhoa"] = new SelectList(_context.TbKhoas, "Makhoa", "Makhoa", tbGiaovien.Makhoa);
            return View(tbGiaovien);
        }

        // GET: TbGiaoviens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiaovien = await _context.TbGiaoviens
                .Include(t => t.MakhoaNavigation)
                .FirstOrDefaultAsync(m => m.Magiaovien == id);
            if (tbGiaovien == null)
            {
                return NotFound();
            }

            return View(tbGiaovien);
        }

        // POST: TbGiaoviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tbGiaovien = await _context.TbGiaoviens.FindAsync(id);
            if (tbGiaovien != null)
            {
                _context.TbGiaoviens.Remove(tbGiaovien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbGiaovienExists(string id)
        {
            return _context.TbGiaoviens.Any(e => e.Magiaovien == id);
        }
    }
}
