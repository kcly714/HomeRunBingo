using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeRunBingo.Models.Domain
{
    public class ConfigDomain
    {
        public int Id { get; set; }
        public string ApiName { get; set; }
        public string ApiKey { get; set; }
    }
}
