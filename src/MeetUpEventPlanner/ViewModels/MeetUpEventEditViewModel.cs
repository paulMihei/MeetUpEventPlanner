using System;
using System.ComponentModel.DataAnnotations;

namespace MeetUpEventPlanner.ViewModels
{
    public class MeetUpEventEditViewModel
    {
        [ScaffoldColumn(true)]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Type { get; set; }

        [Required, MaxLength(100)]
        public string Host { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime StartDateAndTime { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime EndDateAndTime { get; set; }

        [Required, MaxLength(500)]
        public string GuestList { get; set; }

        [Required, MaxLength(300)]
        public string Location { get; set; }

        [MaxLength(1000)]
        public string Message { get; set; }
    }
}