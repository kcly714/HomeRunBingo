using Movie.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Services.Interfaces
{
    public interface IContactUsService
    {
        int Insert(ContactUsModel model);
    }
}
