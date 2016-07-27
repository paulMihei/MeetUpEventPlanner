using System;

namespace MeetUpEventPlanner.Entities
{
    public class MeetUpEvent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Host { get; set; }

        public DateTime StartDateAndTime { get; set; }

        public DateTime EndDateAndTime { get; set; }

        public string GuestList { get; set; }

        public string Location { get; set; }

        public string Message { get; set; }
    }
}
