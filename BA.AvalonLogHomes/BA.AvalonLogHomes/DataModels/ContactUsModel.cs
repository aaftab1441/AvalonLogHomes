using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BA.AvalonLogHomes.Adapters;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BA.AvalonLogHomes.DataModels
{
    public class ContactUsModel : IContactForm
    {
        [Required]
        public string xNVzAName { get; set; }
        [Required]
        public string CsKTVEmail { get; set; }
        public string MUYPQPhone { get; set; }
        public string Referral { get; set; }
        public List<IFormFile> Attachments { get; set; }
        public string Comments { get; set; }
        public string Page { get; set; }
    }
}
