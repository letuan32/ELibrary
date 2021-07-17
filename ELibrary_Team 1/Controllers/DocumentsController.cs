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

namespace ELibrary_Team_1.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public DocumentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                Document = new Document(),
                SelectedCategory = new List<int>(),
                
                CategoryList = categoryList.Select(l => new SelectListItem
                {
                    Text = l.Title,
                    Value = l.Id.ToString()
                })
        };
            return View(documentVM);
        }
        [HttpPost]
        public IActionResult Create(DocumentViewModel documentVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Document.Add(documentVM.Document);

                _unitOfWork.SaveChange();

                
                foreach (var item in documentVM.SelectedCategory)
                { 
                   _unitOfWork.DocumentCategory.Add(new DocumentCategory { DocumentId = documentVM.Document.Id, CategoryId = item });
                }

                    _unitOfWork.SaveChange();
                    return RedirectToAction(nameof(Index));
                

            }
            return View(documentVM);

        }

        // GET: Documents/Edit/5
       
    }
}
