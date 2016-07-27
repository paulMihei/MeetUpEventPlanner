using MeetUpEventPlanner.Entities;
using System.Collections.Generic;

namespace MeetUpEventPlanner.Services
{
    public interface IMeetUpEventData
    {
        IEnumerable<MeetUpEvent> GetAllEvents();
        MeetUpEvent GetEvent(int id);
        void Add(MeetUpEvent meetUpEvent);
        int Commit();
    }
}
