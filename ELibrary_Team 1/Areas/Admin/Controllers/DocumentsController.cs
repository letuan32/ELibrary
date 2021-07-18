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
using ELibrary_Team_1.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ELibrary_Team_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class DocumentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;


        public DocumentsController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Documents
        public IActionResult Index()
        {

            return View(_unitOfWork.Document.GetAll());

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<Category> categoryList = await _unitOfWork.Category.GetAllAsync();
            DocumentViewModel documentVM = new DocumentViewModel()
            {

                CategoryList = categoryList.Select(l => new SelectListItem
                {
                    Text = l.Title,
                    Value = l.Id.ToString()
                })
            };
            return View(documentVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentViewModel documentVM)
        {
            if (ModelState.IsValid)
            {
                documentVM.Document.Image = UploadedFile(documentVM);
                _unitOfWork.Document.Add(documentVM.Document);

                _unitOfWork.SaveChange();
                


                foreach (var item in documentVM.SelectedCategory)
                {
                    _unitOfWork.DocumentCategory.Add(new DocumentCategory { DocumentId = documentVM.Document.Id, CategoryId = item });
                }

                await _unitOfWork.SaveChangeAsync();
                return RedirectToAction(nameof(Index));


            }
            return View(documentVM);

        }

        private string UploadedFile(DocumentViewModel model)
        {
            string FileName = null;
            if (model.ImageFile != null)
            {
                //save image to wwwroot folder
                
                string wwwrootPath = _hostEnvironment.WebRootPath;
                FileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                FileName = FileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwrootPath + "/images/" + FileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.ImageFile.CopyTo(fileStream);
                }
            }
            return FileName;
        }
    }

}
