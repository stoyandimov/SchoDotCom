using System.ComponentModel.DataAnnotations;

namespace SchoDotCom.WebUI.ViewModels.Contact
{
    public class ContactViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email{ get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 140, ErrorMessage = "The field Message must be with a minimum length of 140.")]
        public string Message { get; set; }

        public bool IsSent { get; set; }
    }
}