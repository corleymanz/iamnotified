
using IAmNotified.Common.Serialize;
using IAmNotified.Schema;

namespace IAmNotified.IAmNotifiedService.Implementation.Handler
{
    public class MailHandler : IHandler
    {
        public IMail _mail;
        public IMail Mail
        {
            get
            {
                if (_mail == null)
                {
                    _mail = new Mail();
                }
                return _mail;
            } 
        }

        public void Process(string message)
        {
            var mailInstance = Json.DeSerialize<MailSchema>(message);

            Mail.SendMail(mailInstance);
        }
    }
}