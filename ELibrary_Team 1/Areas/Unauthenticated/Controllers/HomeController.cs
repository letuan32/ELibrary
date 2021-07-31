using ELibrary_Team_1.Models;
using ELibrary_Team_1.ViewModels;
using ELibrary_Team1.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary_Team_1.Controllers
{
    [Area("Unauthenticated")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;



        public HomeController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            this._hostEnvironment = hostEnvironment;
        }
        // GET: HomeController
        public IActionResult Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            var documents = _unitOfWork.Document.GetAll(includeProperties: "DocumentCategories.Category,AccessRequests,UserVotes");
            ViewData["CurrentSort"] = sortOrder;
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["AuthorSortParm"] = String.IsNullOrEmpty(sortOrder) ? "author_desc" : "";
            ViewData["CategorySortParm"] = String.IsNullOrEmpty(sortOrder) ? "category_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                documents = documents.Where(x => x.Title.ToLower().Contains(searchString.ToLower())
                                            || x.Author.ToLower().Contains(searchString.ToLower())
                                            || x.DocumentCategories.Select(c=>c.Category.Title.ToLower()).Contains(searchString.ToLower())

                );
            }
            switch (sortOrder)
            {
                case "title_desc":
                    documents = documents.OrderBy(x => x.Title);
                    break;
                case "author_desc":
                    documents = documents.OrderBy(x => x.Author);
                    break;
                case "category_desc":
                    documents = documents.OrderBy(x => x.DocumentCategories.Select(c => c.Category.Title));
                    break;
                case "date_desc":
                    documents = documents.OrderByDescending(s => s.UpdateDate);
                    break;
                case "Date":
                    documents = documents.OrderBy(s => s.UpdateDate);
                    break;
                default:
                    documents = documents.OrderBy(s => s.Title);
                    break;
            }


            int pageSize = 3;
            return View(PagingReuslt<Document>.CreateAsync(documents, pageNumber ?? 1, pageSize));
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
