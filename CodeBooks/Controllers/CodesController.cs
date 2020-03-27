using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeBooks.EF;
using CodeBooks.Models.Codes;

namespace CodeBooks.Controllers
{
    public class CodesController : Controller
    {
        private readonly MyContext _context;

        public CodesController(MyContext context)
        {
            _context = context;
        }

        // GET: Codes
        public async Task<IActionResult> Index(int? CodeId, int? CodebookId)
        {
            CodesViewModel Model = new CodesViewModel();
            Model.CodeId = CodeId;
            Model.CodebookId = CodebookId;
            if (CodeId == null && CodebookId == null)
                return NotFound();
            else if (CodeId != null)
            {
                Model.Rows = _context.Codes.Where(x => x.CodeId == CodeId).Select(x => new CodesViewModel.Row()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Title = x.Title,
                    Company = x.Company,
                    Ordinal = x.Ordinal,
                    CreatedOn = x.CreatedOn
                }).ToList();
                var code = _context.Codes.Where(x => x.Id == CodeId);
                Model.Superior = code.FirstOrDefault().Title;
                Model.scid = code.FirstOrDefault().CodeId;
                Model.scbid = code.FirstOrDefault().CodebookId;

            }
            else if(CodebookId !=null)
            {
                Model.Rows = _context.Codes.Where(x => x.CodebookId == CodebookId).Select(x => new CodesViewModel.Row()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Title = x.Title,
                    Company = x.Company,
                    Ordinal = x.Ordinal,
                    CreatedOn = x.CreatedOn

                }).ToList();
                Model.Superior = _context.Codebooks.Where(x => x.Id == CodebookId).FirstOrDefault().Title;
                Model.scbid = _context.Codebooks.Where(x => x.Id == CodebookId).FirstOrDefault().Id;
            }
            return View(Model);
        }

        // GET: Codes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codes = await _context.Codes
                .Include(c => c.Codebook)
                .Include(c => c.code)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codes == null)
            {
                return NotFound();
            }

            return View(codes);
        }

        // GET: Codes/Create
        public IActionResult Create(int? CodeId, int? CodebookId)
        {
            Codes model = new Codes();
            model.Ordinal = 0;
            model.CodeId = CodeId;
            model.CodebookId = CodebookId;
            model.CreatedOn = DateTime.Now;
            ViewData["CodeId"] = new SelectList(_context.Codes, "Id", "Title", " - ");
            return View(model);
        }

        // POST: Codes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Title,Company,Integer,String,Decimal,Ordinal,CodeId,CodebookId,CreatedOn")] Codes codes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { CodeId = codes.CodeId, CodebookId = codes.CodebookId });
            }
            ViewData["CodebookId"] = new SelectList(_context.Codebooks, "Id", "Id", codes.CodebookId);
            ViewData["CodeId"] = new SelectList(_context.Codes, "Id", "Id", codes.CodeId);
            return View(codes);
        }

        // GET: Codes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codes = await _context.Codes.FindAsync(id);
            if (codes == null)
            {
                return NotFound();
            }
            ViewData["CodebookId"] = new SelectList(_context.Codebooks, "Id", "Id", codes.CodebookId);
            ViewData["CodeId"] = new SelectList(_context.Codes, "Id", "Id", codes.CodeId);
            return View(codes);
        }

        // POST: Codes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Title,Company,Integer,String,Decimal,Ordinal,CodeId,CodebookId,CreatedOn")] Codes codes)
        {
            if (id != codes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodesExists(codes.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { CodeId = codes.CodeId, CodebookId = codes.CodebookId });
            }
            ViewData["CodebookId"] = new SelectList(_context.Codebooks, "Id", "Id", codes.CodebookId);
            ViewData["CodeId"] = new SelectList(_context.Codes, "Id", "Id", codes.CodeId);
            return View(codes);
        }

        // GET: Codes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codes = await _context.Codes
                .Include(c => c.Codebook)
                .Include(c => c.code)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codes == null)
            {
                return NotFound();
            }

            return View(codes);
        }

        // POST: Codes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codes = await _context.Codes.FindAsync(id);
            _context.Codes.Remove(codes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { CodeId = codes.CodeId, CodebookId = codes.CodebookId });
        }

        private bool CodesExists(int id)
        {
            return _context.Codes.Any(e => e.Id == id);
        }
    }
}
