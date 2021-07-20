using ELibrary_Team_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary_Team_1.ViewModels
{
    public class DocumentViewModel
    {
        public Document Document { get; set; }

        //[Display(Name = "Category Id")]
        //public list<int> selectedcategory { get; set; }
        [Display(Name = "Image File")]
        public IFormFile ImageFile { get; set; }
        [Display(Name = "Current Chapters")]
        public int NoChapter { get; set; }
        [Display(Name = "User Access")]
        public int TotalAccess { get; set; }
        [Display(Name = "User Vote")]
        public int TotalVote { get; set; }

        [Display(Name = "Category")]
        public IEnumerable<SelectListItem> CategorySelectList { get; set; }

        public List<int> CurrentCategoryList { get; set; }


    }
}
