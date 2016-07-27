using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeetUpEventPlanner.Entities
{
    public class MeetUpEventPlannerDbContext : IdentityDbContext<User>
    {
        public MeetUpEventPlannerDbContext(DbContextOptions<MeetUpEventPlannerDbContext> options)
            : base(options)
        { } 

        public DbSet<MeetUpEvent> MeetUpEvent { get; set; }
    }
}
