using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary_Team_1.Models
{
    public class AccessRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; }
       
        public DateTime UnlockDate { get; set; }
        public DateTime ExpityDate { get; set; }
        public Boolean IsAccept { get; set; }
        public int DocumentId { get; set; }

        // 
        public Document Document { get; set; }
        public AppUser AppUser { get; set; }


    }
}
