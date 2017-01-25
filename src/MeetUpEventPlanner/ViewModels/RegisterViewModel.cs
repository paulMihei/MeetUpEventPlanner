using System;
using System.ComponentModel.DataAnnotations;

namespace MeetUpEventPlanner.ViewModels
{
    public class RegisterViewModel
    {
        [Required, MaxLength(256)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password), Compare(nameof(RegisterViewModel.Password))]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [MaxLength(50)]
        public string Job { get; set; }
    }
}
