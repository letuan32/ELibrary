using ELibrary_Team_1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary_Team_1.ViewModels
{
    public class DocumentViewModel
    {
        public Document Document { get; set; }
        public List<int> SelectedCategory { get; set; }
        
        public IEnumerable<SelectListItem> CategoryList { get; set; }


    }
}
