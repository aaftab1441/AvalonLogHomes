using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.AvalonLogHomes.DataModels
{
    public interface IContactForm
    {
        string xNVzAName { get; set; }
        string CsKTVEmail { get; set; }
        string MUYPQPhone { get; set; }
        string Page { get; set; }
        List<IFormFile> Attachments { get; set; }
    }
}
