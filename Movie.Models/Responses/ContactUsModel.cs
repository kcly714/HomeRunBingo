using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Models.Responses
{
    public class ContactUsModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Required]
        [MaxLength(254)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(254)]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required]
        [MaxLength(254)]
        [Display(Name = "Body")]
        public string Body { get; set; }
    }
}
