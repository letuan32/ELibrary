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
    public class DocumentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;



        public DocumentController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController/Details/5
        [Route("/{title}")]      
        public ActionResult Details(string title)
        {
            var document = _unitOfWork.Document.FirstOrDefault(x => x.Title == title, includeProperties: "DocumentCategories.Category,AccessRequests,UserVotes");
            var chapters = _unitOfWork.Chapter.GetAll(x => x.DocumentId == document.Id).ToList();
            ViewBag.Chapters = chapters;
            return View(document);
        }

        // GET: HomeController/Create

        [Route("/{title}/{number}/{id}")]
        public ActionResult GetChapter(string title, string number, int id)
        {
            var chapter = _unitOfWork.Chapter.FirstOrDefault(x => x.Id == id, includeProperties: "Document");

            return View(chapter);
        }

    }
}
