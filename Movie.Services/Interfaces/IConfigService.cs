using Movie.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Services.Interfaces
{
    public interface IConfigService
    {
        ConfigDomain SelectById(int Id);
    }
}
