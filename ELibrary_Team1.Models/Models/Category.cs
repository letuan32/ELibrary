using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary_Team_1.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<DocumentCategory> DocumentCategories { get; set; }

    }
}
