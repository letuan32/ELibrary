using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ELibrary.Data;
using ELibrary_Team_1.Models;
using ELibrary_Team1.DataAccess.Data.Repository.IRepository;

namespace ELibrary_Team_1.Areas.Admin.Controllers
{
    public class DocumentCategoriesController : Controller
    {
        private readonly ELibraryDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public DocumentCategoriesController(ELibraryDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: DocumentCategories
        [Area("Admin")]
        public async Task<IActionResult> Index()
        {

            var documentCategoriesDbSet = _context.DocumentCategories.Include(d => d.Category).Include(d => d.Document);

           

            

            
            return View(await documentCategoriesDbSet.ToListAsync());
        }

        // GET: DocumentCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentCategory = await _context.DocumentCategories
                .Include(d => d.Category)
                .Include(d => d.Document)
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (documentCategory == null)
            {
                return NotFound();
            }

            return View(documentCategory);
        }

        // GET: DocumentCategories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
            ViewData["DocumentId"] = new SelectList(_context.Documents, "Id", "Id");
            return View();
        }

        // POST: DocumentCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentId,CategoryId")] DocumentCategory documentCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", documentCategory.CategoryId);
            ViewData["DocumentId"] = new SelectList(_context.Documents, "Id", "Id", documentCategory.DocumentId);
            return View(documentCategory);
        }

        // GET: DocumentCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentCategory = await _context.DocumentCategories.FindAsync(id);
            if (documentCategory == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", documentCategory.CategoryId);
            ViewData["DocumentId"] = new SelectList(_context.Documents, "Id", "Id", documentCategory.DocumentId);
            return View(documentCategory);
        }

        // POST: DocumentCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentId,CategoryId")] DocumentCategory documentCategory)
        {
            if (id != documentCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentCategoryExists(documentCategory.CategoryId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", documentCategory.CategoryId);
            ViewData["DocumentId"] = new SelectList(_context.Documents, "Id", "Id", documentCategory.DocumentId);
            return View(documentCategory);
        }

        // GET: DocumentCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentCategory = await _context.DocumentCategories
                .Include(d => d.Category)
                .Include(d => d.Document)
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (documentCategory == null)
            {
                return NotFound();
            }

            return View(documentCategory);
        }

        // POST: DocumentCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documentCategory = await _context.DocumentCategories.FindAsync(id);
            _context.DocumentCategories.Remove(documentCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentCategoryExists(int id)
        {
            return _context.DocumentCategories.Any(e => e.CategoryId == id);
        }
    }
}
