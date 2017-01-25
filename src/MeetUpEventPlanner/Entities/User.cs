using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace MeetUpEventPlanner.Entities
{
    public class User : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public string Job { get; set; }
    }
}
