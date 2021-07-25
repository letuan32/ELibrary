using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ELibrary_Team_1.Models
{
    public class AppUser:IdentityUser
    {
        [NotMapped]
        public string Role;

        //

        public string FullName { get; set; }


       

        public ICollection<UpdateRequest> UpdateRequests { get; set; }
        public ICollection<AccessRequest> AccessRequests { get; set; }
        public ICollection<UserVote> UserVotes { get; set; }

    }
    


}
