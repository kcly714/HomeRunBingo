using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.Models.ViewModels
{
    public class MovieViewModel : BaseViewModel
    {
        public int Count { get; set; }

        public string Data { get; set; }
    }
}
