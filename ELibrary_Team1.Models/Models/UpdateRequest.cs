
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary_Team_1.Models
{
    public class UpdateRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentAuthor { get; set; }
        public string Description { get; set; }
        //
        public AppUser AppUser { get; set; }
    }
}
