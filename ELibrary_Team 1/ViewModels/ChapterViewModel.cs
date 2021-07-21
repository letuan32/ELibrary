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
    public class ChapterViewModel
    {
        public Chapter Chapter { get; set; }
        public IEnumerable<SelectListItem> DocumentList { get; set; }
        public string DocumentTitle { get; set; }
    }
}