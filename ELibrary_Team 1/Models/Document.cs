using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary_Team_1.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Description { get; set; }
        public Boolean IsPublic { get; set; }

        //
        public ICollection<DocumentCategory> DocumentCategories { get; set; }
        public ICollection<Chapter> Chapters { get; set; }
        public ICollection<AccessRequest> AccessRequests { get; set; }
        public ICollection<Rate> Rates { get; set; }
    }
}
