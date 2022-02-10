using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;
using System.Configuration;

namespace ExcahnegEmailAccess
{
    class EmailExchangeService
    {
        //To read email message by subject
        public static EmailMessage VerifyEmailNotification(string subject)
        {
            var service = GetEmailExchangeService();
            foreach (Item email in service.FindItems(WellKnownFolderName.Inbox, new ItemView(5)))
            {
                EmailMessage message = EmailMessage.Bind(service, email.Id);
                if (message.Subject.Contains(subject) && message.DateTimeReceived >= DateTime.Now.AddMinutes(-5))
                {
                    return message;
                }
            }
            //Check in JunkEmail if not found in Inbox.
            foreach (Item email in service.FindItems(WellKnownFolderName.JunkEmail, new ItemView(5)))
            {
                EmailMessage message = EmailMessage.Bind(service, email.Id);
                if (message.Subject.Contains(subject) && message.DateTimeReceived >= DateTime.Now.AddMinutes(-5))
                {
                    return message;
                }
            }
            return null;
        }

        //To get exchangeService object
        private static ExchangeService GetEmailExchangeService()
        {
            string userName = ConfigurationManager.AppSettings["UserName"].ToString();
            string password = ConfigurationManager.AppSettings["Password"].ToString();
            ExchangeService service = null;
            try
            {
                service = new ExchangeService { Credentials = new WebCredentials(userName, password) };
                service.Url = new Uri(ConfigurationManager.AppSettings["OutlookExchangeURL"]);
            }
            catch
            {
                Console.WriteLine("Email exchange connection/login failed");
            }
            return service;
        }
    }
}
