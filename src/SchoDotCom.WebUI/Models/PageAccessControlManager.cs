using Microsoft.Extensions.Options;
using System.Linq;

namespace SchoDotCom.WebUI.Models
{
    public class PageAccessControlManager
    {
        AppSettings _appSettings;
        public PageAccessControlManager(IOptions<AppSettings> opt)
            => _appSettings = opt.Value;
        public bool IsPageDisabled(string slug)
            => !IsPageEnabled(slug);
        public bool IsPageEnabled(string slug)
            => _appSettings.DisabledPages == null || !_appSettings.DisabledPages.Contains(slug.ToLower());
    }
}
