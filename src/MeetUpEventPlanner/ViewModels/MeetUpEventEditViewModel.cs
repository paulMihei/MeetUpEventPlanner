using MeetUpEventPlanner.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace MeetUpEventPlanner.ViewModels
{
    public class MeetUpEventEditViewModel
    {
        public MeetUpEventEditViewModel() { }
        public MeetUpEventEditViewModel(MeetUpEvent meetUpEvent)
        {
            Id = meetUpEvent.Id;
            Name = meetUpEvent.Name;
            Type = meetUpEvent.Type;
            Host = meetUpEvent.Host;
            StartDateAndTime = meetUpEvent.StartDateAndTime;
            EndDateAndTime = meetUpEvent.EndDateAndTime;
            GuestList = meetUpEvent.GuestList;
            Location = meetUpEvent.Location;
            Message = meetUpEvent.Message;
        }

        [ScaffoldColumn(true)]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Type { get; set; }

        [Required, MaxLength(100)]
        public string Host { get; set; }

        [Display(Name = "Start Date And Time")]
        [Required, DataType(DataType.DateTime)]
        public DateTime StartDateAndTime { get; set; }

        [Display(Name = "End Date And Time")]
        [Required, DataType(DataType.DateTime)]
        public DateTime EndDateAndTime { get; set; }

        [Display(Name = "Guest List")]
        [Required, MaxLength(500)]
        public string GuestList { get; set; }

        [Required, MaxLength(300)]
        public string Location { get; set; }

        [MaxLength(1000)]
        [Display(Name = "Message (Optional)")]
        public string Message { get; set; }
    }
}