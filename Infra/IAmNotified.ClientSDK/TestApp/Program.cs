using System;
using System.Collections.Generic;
using IAmNotified.Schema;

namespace IAmNotified.ClientSDK.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MailNotifier n = new MailNotifier();
            n.Push( new MailSchema
            {
                Tomail = new List<string> { "you@you.nl"}
                , Priority = MailPriority.Low
                , Subject = "Onderwerp"
                , Content = "hierbij een linkje <a href='www.google.com'> veel plezier ermee"
            });

            n.Push( new MailSchema
            {
                FromName = "program"
                , FromMail = "program@test.nl"
                , Tomail = new List<string> { "andme@love.nl"}
                , Priority = MailPriority.Normal
                , Subject = "Onderwerpie"
                , Content = "hierbij een linkje <a href='www.google.com'> veel plezier ermee fsdklfkdsmfksdfksdlkfmslk mflksd" + Environment.NewLine + Environment.NewLine + "tweede regel"
            });
        }
    }
}
