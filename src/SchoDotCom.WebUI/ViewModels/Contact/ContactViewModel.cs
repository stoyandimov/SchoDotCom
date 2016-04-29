using System.ComponentModel.DataAnnotations;

namespace SchoDotCom.WebUI.ViewModels.Contact
{
	public class ContactViewModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email Address")]
		public string EmailAddress { get; set; }

		[Required]
		[Display(Name = "Message Subject")]
		public string Subject { get; set; }

		[Required]
		[Display(Name = "Message Content")]
		[StringLength(int.MaxValue, MinimumLength = 140, ErrorMessage = "The field Message Content must be a string with a minimum length of 140.")]
		public string Message { get; set; }

		public bool IsSent { get; set; }
	}
}