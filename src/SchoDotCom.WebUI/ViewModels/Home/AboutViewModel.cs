namespace SchoDotCom.WebUI.ViewModels.Home
{
	public class AboutViewModel
	{
		int _yearOfBirth;

		public int AgeInDogYears {
			get
			{
				return ((System.DateTime.Now.Year - _yearOfBirth) * 7);
			}
		}

		public AboutViewModel(int yearOfBirth)
		{
			_yearOfBirth = yearOfBirth;
		}
	}
}