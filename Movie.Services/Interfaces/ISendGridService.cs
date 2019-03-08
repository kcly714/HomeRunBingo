using Movie.Models.Responses;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Services.Interfaces
{
    public interface ISendGridService
    {
        Task<Response> ContactUs(ContactUsModel model);
    }
}
