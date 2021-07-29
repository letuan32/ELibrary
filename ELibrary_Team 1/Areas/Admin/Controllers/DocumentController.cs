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
using static ELibrary_Team1.Helper;
using ELibrary_Team1;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELibrary_Team_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class DocumentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
       


        public DocumentController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            this._hostEnvironment = hostEnvironment;
        }

    // GET: Documents
       
        public IActionResult Index()
        {
            return View(_unitOfWork.Document.GetAll());
        }

///>>>>>>>>>>>>>>>>>>>>>>>>>> Entity Frammework >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    //// Create Document
    //    [HttpGet]
    //    public async Task<IActionResult> Create()
    //    {

    //        IEnumerable<Category> categoryList = await _unitOfWork.Category.GetAllAsync();
    //        DocumentViewModel documentVM = new DocumentViewModel()
    //        {
    //            // Pass Category list from db.Category to SelectListItem
    //            CategorySelectList = categoryList.Select(l => new SelectListItem
    //            {
    //                Text = l.Title,
    //                Value = l.Id.ToString()
    //            })
                
    //        };
    //        return View(documentVM);
    //    }
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create(DocumentViewModel documentVM)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            if(documentVM.ImageFile != null)
    //            {
    //                // UploadedFile method: Check if imange exists and copy Image file to webRoot
    //                documentVM.Document.Image = UploadedFile(documentVM);
    //            }
               
    //            //_unitOfWork.Document.Add(documentVM.Document);
    //            //_unitOfWork.SaveChange();
    //            if(documentVM.CategorySelectList != null)
    //            {
                   
    //                foreach (var item in documentVM.CategorySelectList)
    //                {
    //                    var documentCategory = new DocumentCategory() { DocumentId = documentVM.Document.Id, CategoryId = Int32.Parse(item.Value) };
    //                    documentVM.Document.DocumentCategories.Add(documentCategory);
    //                }
    //            }
    //            _unitOfWork.Document.Add(documentVM.Document);
    //            await _unitOfWork.SaveChangeAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //         return View(documentVM);
    //    }
    //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> End Create>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    // Edit Document
        //public IActionResult Edit(int id)
        //{

        //    var model = new DocumentViewModel();
        //    var document = _unitOfWork.Document.FirstOrDefault(x => x.Id == id, includeProperties: "DocumentCategories");
        //    //var documentCategory = document.DocumentCategories;
        //    IEnumerable <Category> categoryList = _unitOfWork.Category.GetAll().ToList();
        //    var currentCategory = document.DocumentCategories.ToList();
        //    model = new DocumentViewModel()
        //    {
        //        Document = document,
        //        CurrentCategoryList = currentCategory.Select(x=>x.CategoryId).ToList(),
                
        //        //SelectedCategory = documentCategory.Select(x => x.CategoryId).ToList(),
        //        CategorySelectList = categoryList.Select(l => new SelectListItem
        //        {
        //            Text = l.Title,
        //            Value = l.Id.ToString()
        //        })
        //    };
        //    if(model.Document.Image != null)
        //    {
        //        string wwwrootPath = _hostEnvironment.WebRootPath;
        //        string path = Path.Combine(wwwrootPath + "/images/" + document.Image);
        //        using (var stream = System.IO.File.OpenRead(path))
        //        {
        //            model.ImageFile = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
        //        }
        //    }
                
        //    return View(model);

        //}
        //[HttpPost]
        //public IActionResult Edit(DocumentViewModel documentVM)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        if (documentVM.ImageFile != null)
        //        {
        //            documentVM.Document.Image = UploadedFile(documentVM);
        //        }
        //        //_unitOfWork.Document.Update(documentVM.Document);
        //        if (documentVM.CategorySelectList != null)
        //        {
        //            var oldDocumentCategories = _unitOfWork.DocumentCategory.GetAll(x => x.DocumentId == documentVM.Document.Id);

        //            _unitOfWork.DocumentCategory.RemoveRange(oldDocumentCategories);
        //            //_unitOfWork.SaveChange();
        //            var updateCategory = new List<DocumentCategory>();
        //            foreach (var item in documentVM.CurrentCategoryList)
        //            {
        //                updateCategory.Add(new DocumentCategory { DocumentId = documentVM.Document.Id, CategoryId = item });
        //            }
        //            _unitOfWork.DocumentCategory.AddRange(updateCategory);
                    
        //        }
        //        _unitOfWork.Document.Update(documentVM.Document);
        //        _unitOfWork.SaveChange();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    _unitOfWork.SaveChange();
            
        //    return View(documentVM);
        //}
 ///>>>>>>>>>>>>>>>>>>>>>>>>>> Entity Frammework >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // Get Details
        [NoDirectAccess]
        public IActionResult Details(int id)
        {
            var document = _unitOfWork.Document.FirstOrDefault(x => x.Id == id, includeProperties: "Chapters,DocumentCategories.Category,AccessRequests,UserVotes");
            var noChapter = document.Chapters.Count;
            // Count number of current chapters
            //var totalChapter = document.Chapters.Select(x => x.TotalChapter).Count(); TODO: Add field "TotalChapter" that store total chapter of document
            var totalAccess = document.AccessRequests.Where(x => x.IsAccept == true).Count(); // Count total accepted request;
            var totalVote = document.UserVotes.Count;
            var selectedCategory = new SelectList(document.DocumentCategories, "Category.Id", "Category.Title");

            var documentVM = new DocumentViewModel()
            {
                Document = document,
                NoChapter = noChapter,
                TotalAccess = totalAccess,
                TotalVote = totalVote,
                CategorySelectList = selectedCategory,
            };

            return View(documentVM);
        }


        private string UploadedFile(DocumentViewModel model)
        {
            string wwwrootPath = _hostEnvironment.WebRootPath;
            string newFileName = null;

            if(model.Document.Image != null) // Delete old image
            {
                string oldFilePath = Path.Combine(wwwrootPath + "/images/" + model.Document.Image);
                System.IO.File.Delete(oldFilePath);
            }    

            newFileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            string extension = Path.GetExtension(model.ImageFile.FileName);
            newFileName = newFileName + Guid.NewGuid().ToString() + extension;
            string newFilePath = Path.Combine(wwwrootPath + "/images/" + newFileName);
            
            using (var fileStream = new FileStream(newFilePath, FileMode.Create))
            {
                model.ImageFile.CopyTo(fileStream);
            }
         
            return newFileName;
        }
/////////-----------CRUD using Popup-Dialog//////////
        // AddorEdit
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {  
            if (id == 0)
            {
                IEnumerable<Category> categoryList = await _unitOfWork.Category.GetAllAsync();
                DocumentViewModel documentVM = new DocumentViewModel()
                {
                    Document = new Document(),
                    // Pass Category list from db.Category to SelectListItem
                    CategorySelectList = categoryList.Select(l => new SelectListItem
                    {
                        Text = l.Title,
                        Value = l.Id.ToString()
                    })
                };
                return View(documentVM);
            }    
            else
            {
                var documentVM = new DocumentViewModel();
                var document = _unitOfWork.Document.FirstOrDefault(x => x.Id == id, includeProperties: "DocumentCategories");
                //var documentCategory = document.DocumentCategories;
                IEnumerable<Category> categoryList = _unitOfWork.Category.GetAll().ToList();
                var currentCategory = document.DocumentCategories.ToList();
                documentVM = new DocumentViewModel()
                {
                    Document = document,
                    CurrentCategoryList = currentCategory.Select(x => x.CategoryId).ToList(),

                    //SelectedCategory = documentCategory.Select(x => x.CategoryId).ToList(),
                    CategorySelectList = categoryList.Select(l => new SelectListItem
                    {
                        Text = l.Title,
                        Value = l.Id.ToString()
                    })
                };
                if (documentVM.Document.Image != null)
                {
                    string wwwrootPath = _hostEnvironment.WebRootPath;
                    string path = Path.Combine(wwwrootPath + "/images/" + document.Image);
                    using (var stream = System.IO.File.OpenRead(path))
                    {
                        documentVM.ImageFile = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
                    }
                }

                return View(documentVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult AddOrEdit(int id,  DocumentViewModel documentVM)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    if (documentVM.ImageFile != null)
                    {
                        // UploadedFile method: Check if imange exists and copy Image file to webRoot
                        documentVM.Document.Image = UploadedFile(documentVM);
                    }
                    _unitOfWork.Document.Add(documentVM.Document);
                    _unitOfWork.SaveChange();

                    if (documentVM.CurrentCategoryList != null)
                    {
                        var documentCategory = new List<DocumentCategory>();
                        foreach (var item in documentVM.CurrentCategoryList)
                        {
                            documentCategory.Add(new DocumentCategory() { DocumentId = documentVM.Document.Id, CategoryId = item });
                            
                        }
                        _unitOfWork.DocumentCategory.AddRange(documentCategory);
                    }
                    
                    
                    _unitOfWork.SaveChange(); 
                }

                else
                {
                    if (documentVM.ImageFile != null)
                    {
                        documentVM.Document.Image = UploadedFile(documentVM);
                    }
                    //_unitOfWork.Document.Update(documentVM.Document);
                    if (documentVM.CurrentCategoryList != null)
                    {
                        var oldDocumentCategories = _unitOfWork.DocumentCategory.GetAll(x => x.DocumentId == documentVM.Document.Id);

                        _unitOfWork.DocumentCategory.RemoveRange(oldDocumentCategories);
                        //_unitOfWork.SaveChange();
                        var updateCategory = new List<DocumentCategory>();
                        foreach (var item in documentVM.CurrentCategoryList)
                        {
                            updateCategory.Add(new DocumentCategory { DocumentId = documentVM.Document.Id, CategoryId = item });
                        }
                        _unitOfWork.DocumentCategory.AddRange(updateCategory);

                    }
                    _unitOfWork.Document.Update(documentVM.Document);
                    _unitOfWork.SaveChange();
                    
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _unitOfWork.Document.GetAll())});
            }

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", documentVM) });
        }

        // Delete
        public IActionResult Delete(int id)
        {

            var document = _unitOfWork.Document.GetById(id);
            return View(document);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var document = _unitOfWork.Document.GetById(id);
            _unitOfWork.Document.Remove(document);
            _unitOfWork.SaveChange();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _unitOfWork.Document.GetAll())});
        }


        /////////----END-----------CRUD using Popup-Dialog//////////
    }

}
