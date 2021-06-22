using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary_Team_1.Models
{
    public class Rate
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string UserId { get; set; }
        public int Vote { get; set; }
        public double AverageRate { get; set; }

        public AppUser AppUser { get; set; }
        public Document Document { get; set; }
    }
}
