namespace SchoDotCom.WebUI.Models
{
    public class SmtpSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public short Port { get; set; }
        public string Server { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
    }
}
