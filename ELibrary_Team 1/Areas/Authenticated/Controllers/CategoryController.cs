using ELibrary.Data;
using ELibrary_Team1.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary_Team_1.Areas.Authenticated.Controllers
{
    [Area("Authenticated")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            return View();
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Category.GetAll();
            return Json(new { data = allObj });
        }

        #endregion
    }
}
