using SchoDotCom.WebUI.ViewModels.Contact;

namespace SchoDotCom.WebUI.ViewModels.Home
{
    public class ResumeViewModel : ContactDetailsViewModel
    {
        public int YearsOfExperience
        {
            get
            {
                return System.DateTime.Now.Year - 2011;
            }
        }
    }
}