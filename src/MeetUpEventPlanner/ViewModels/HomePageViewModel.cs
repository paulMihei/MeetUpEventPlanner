using MeetUpEventPlanner.Entities;
using System.Collections.Generic;

namespace MeetUpEventPlanner.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<MeetUpEvent> MeetUpEvents { get; set; }
    }
}