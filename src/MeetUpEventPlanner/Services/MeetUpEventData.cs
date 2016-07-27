using System.Collections.Generic;
using System.Linq;
using MeetUpEventPlanner.Entities;

namespace MeetUpEventPlanner.Services
{
    public class MeetUpEventData : IMeetUpEventData
    {
        private MeetUpEventPlannerDbContext _context;

        public MeetUpEventData(MeetUpEventPlannerDbContext context)
        {
            _context = context;
        }

        public void Add(MeetUpEvent meetUpEvent)
        {
            _context.Add(meetUpEvent);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public IEnumerable<MeetUpEvent> GetAllEvents()
        {
            return _context.MeetUpEvent;
        }

        public MeetUpEvent GetEvent(int id)
        {
            return _context.MeetUpEvent.FirstOrDefault(e => e.Id == id);
        }
    }
}
