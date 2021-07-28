using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELibrary_Team_1.Models
{
    public class Chapter
    {
        public int Id { get; set; }

        //[Required]
        //public string Number { get; set; }
        //[Required]
        //public string Title { get; set; }
        public int DocumentId { get; set; }
        public string Content { get; set; }
        public Boolean IsUnlock { get; set; }
        //
        public Document Document { get; set; }
    }
}
