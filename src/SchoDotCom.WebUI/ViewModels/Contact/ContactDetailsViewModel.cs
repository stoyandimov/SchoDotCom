using System;

namespace SchoDotCom.WebUI.ViewModels.Contact
{
    public class ContactDetailsViewModel
    {
        public bool IncludeContactDetails
        {
            get
            {
                return GetConfigSettingAsBool("IncludeContactDetails");
            }
        }

        public string PhoneNumber
        {
            get
            {
                return GetConfigSetting("PhoneNumber");
            }
        }

        public string EmailAddress
        {
            get
            {
                return GetConfigSetting("EmailAddress");
            }
        }

        public string Address
        {
            get
            {
                return GetConfigSetting("Address");
            }
        }

        private bool GetConfigSettingAsBool(string key)
        {
            bool setting;
            Boolean.TryParse(GetConfigSetting(key), out setting);
            return setting;
        }

        private string GetConfigSetting(string key)
        {
            var setting = System.Configuration.ConfigurationManager.AppSettings["schodotcom:" + key];
            return setting ?? "";
        }
    }
}