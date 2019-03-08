using Movie.Models.Responses;
using Movie.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Movie.Services
{
    public class SendGridService : ISendGridService
    {
        
        private IConfigService _configService;
        //private readonly SendGridClient _client;
        //private static readonly string MessageId = "X-Message-Id";

        public SendGridService(IConfigService configService)
        {
            _configService = configService;
        }

        public async Task<Response> ContactUs(ContactUsModel model)
        {
            //var ApiKey = _configService.SelectById(4); 
            //var client = new SendGridClient(apiKey.ToString());
            var configService = _configService.SelectById(4);
            var ApiKey = configService.ApiKey;
        
            var client = new SendGridClient(ApiKey);
            var from = new EmailAddress(model.Email);
            var subject = "Movie Contact Us Page";
            //template route
            string emailTemplate = File.ReadAllText("C:/Projects/Portfolio/Movie_Api/Movie.Services/ContactUs/ContactUsTemp.html");

            //Full Name
            string templateWithName = emailTemplate.Replace("{FullName}", model.FullName);
            //Email
            string templateWithEmail = templateWithName.Replace("{Email}", model.Email);
            //Subject
            string templateWithSubject = templateWithEmail.Replace("{Subject}", model.Subject);
            //Body
            string templateWithBody = templateWithSubject.Replace("{Body}", model.Body);

            var plainTextContent = templateWithBody;
            var htmlContent = templateWithBody;

            var to = new EmailAddress("dantweigel@gmail.com", "Admin");

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response);
            Console.Read();
            return response;
        }

    }
}
