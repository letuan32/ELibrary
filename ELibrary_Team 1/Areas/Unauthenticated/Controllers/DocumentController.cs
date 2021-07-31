using ELibrary_Team_1.Models;
using ELibrary_Team1.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static ELibrary_Team1.Helper;

namespace ELibrary_Team_1.Controllers
{
   
    [Area("Unauthenticated")]
    public class DocumentController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public DocumentController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            this._hostEnvironment = hostEnvironment;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController/Details/5
        [AllowAnonymous]
        
        [Route("/{title}")]      
        public ActionResult Details(string title)
        {
            var document = _unitOfWork.Document.FirstOrDefault(x => x.Title == title, includeProperties: "DocumentCategories.Category,AccessRequests,UserVotes");
            var chapters = _unitOfWork.Chapter.GetAll(x => x.DocumentId == document.Id).ToList();
            ViewBag.Chapters = chapters;
            

            if (_signInManager.IsSignedIn(User))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
                var accessRequest = document.AccessRequests.SingleOrDefault(x => x.UserId == userId);
                if (accessRequest != null)
                {
                    ViewBag.RequestStatus = accessRequest.IsAccept;
                }
            }
            
            return View(document);
        }

        // GET: HomeController/Create

        [AllowAnonymous]
        [HttpGet]
        [Route("/Document/{title}/{number}/{id}")]
        public ActionResult GetChapter(string title, string number, int id)
        {
            var chapter = _unitOfWork.Chapter.FirstOrDefault(x => x.Id == id, includeProperties: "Document");
            
            if(chapter.IsUnlock==true)
            {
                ViewBag.AccessStatus = true;
                return View("ChapterModalPopUp", chapter);
            }
            

            if (_signInManager.IsSignedIn(User))
            {
                var accessList = _unitOfWork.AccessRequest.GetAll(x => x.DocumentId == chapter.DocumentId);
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
                var userAccessStatus = accessList.FirstOrDefault(x => x.UserId == userId);
                if (userAccessStatus == null || userAccessStatus.IsAccept == false)
                {
                    ViewBag.AccessStatus = false;
                    ViewBag.ChapterTitle = chapter.Number + ": " + chapter.Title;
                    return View("ChapterModalPopUp");
                }
                if (userAccessStatus.IsAccept == true)
                {
                    ViewBag.AccessStatus = true;
                    return View("ChapterModalPopUp", chapter);
                }
            }
            else
            {
                ViewBag.AccessStatus = false;
                ViewBag.ChapterTitle = chapter.Number + ": " + chapter.Title;
                return View("ChapterModalPopUp");
            }
            return View("ChapterModalPopUp",chapter);


        }
        [Authorize]
        [HttpPost]
        public ActionResult SendAccessRequest(int documentId)
        {
            if(_signInManager.IsSignedIn(User) ==false)
            {
                return Json(new { success = false, message = "Login to make request" });
            }
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
            var accessRequest = new AccessRequest()
            {
                UserId = userId,
                DocumentId = documentId,
                IsAccept = false,
            };

            _unitOfWork.AccessRequest.Add(accessRequest);
            _unitOfWork.SaveChange();
            return Json(new { success = true, message = "Send request Successful" });
        }



    }
}
