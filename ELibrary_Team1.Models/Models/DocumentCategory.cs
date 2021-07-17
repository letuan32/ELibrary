using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary_Team_1.Models
{
    public class DocumentCategory
    {
       
        public int DocumentId { get; set; }
        
        public int CategoryId { get; set; }
        //
        public  Category Category { get; set; }
        public  Document Document { get; set; }

    }
}
