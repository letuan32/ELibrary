using ELibrary_Team1.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary_Team_1.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Authorize(Roles = "Admin, Staff")]
    public class AccessRequestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccessRequestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public IActionResult Index()
        {
            var requests = _unitOfWork.AccessRequest.GetAll(includeProperties: "AppUser,Document");
            return View(requests);
        }

    

        [HttpPost]
        public IActionResult ChangeStatus([FromBody] string id)
        {
            var requestId = Int32.Parse(id);
            var objFromDb = _unitOfWork.AccessRequest.FirstOrDefault(x => x.Id == requestId);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error" });
            }
            if (objFromDb.IsAccept == true)
            {
                //user is currently locked, we will unlock them
                objFromDb.IsAccept = false;
            }
            else
            {
                objFromDb.IsAccept = true;
            }
            _unitOfWork.AccessRequest.Update(objFromDb);
            _unitOfWork.SaveChange();
            return Json(new { success = true, message = "Operation Successful." });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.AccessRequest.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.AccessRequest.Remove(objFromDb);
            _unitOfWork.SaveChange();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
