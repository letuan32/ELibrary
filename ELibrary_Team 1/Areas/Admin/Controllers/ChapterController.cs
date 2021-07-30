using ELibrary_Team_1.Models;
using ELibrary_Team_1.ViewModels;
using ELibrary_Team1.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary_Team_1.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ChapterController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChapterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            ChapterViewModel chaptervm = new ChapterViewModel()
            {
                Chapter = new Chapter(),
                DocumentList = _unitOfWork.Document.GetAll().Select(i => new SelectListItem {
                    Text = i.Title,
                    Value = i.Id.ToString()
                })
            };
            if (id == null)
            {
                return View(chaptervm);
            }
            chaptervm.Chapter = _unitOfWork.Chapter.GetById(id.GetValueOrDefault());
            if (chaptervm.Chapter == null)
            {
                return NotFound();
            }
            return View(chaptervm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ChapterViewModel chapterViewModel)
        {
            if (ModelState.IsValid)
            {
                if (chapterViewModel.Chapter.Id == 0)
                {
                    _unitOfWork.Chapter.Add(chapterViewModel.Chapter);
                }
                else
                {
                    _unitOfWork.Chapter.Update(chapterViewModel.Chapter);
                }
                _unitOfWork.SaveChange();
                return RedirectToAction(nameof(Index));
            }
            return View(chapterViewModel);
        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Chapter.GetAll(includeProperties: "Document");
            return Json(new { data = allObj }); 
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Chapter.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Chapter.Remove(objFromDb);
            _unitOfWork.SaveChange();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
