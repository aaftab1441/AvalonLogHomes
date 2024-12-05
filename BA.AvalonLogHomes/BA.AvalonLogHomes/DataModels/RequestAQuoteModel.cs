using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BA.AvalonLogHomes.Adapters;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace BA.AvalonLogHomes.DataModels
{
    public class RequestAQuoteModel : IContactForm
    {
        [Required]
        public string xNVzAName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        [Required]
        public string CsKTVEmail { get; set; }
        public string MUYPQPhone { get; set; }
        public string Fax { get; set; }
        public string BestContactTime { get; set; }
        public string BuildDate { get; set; }
        public string FundingSecured { get; set; }
        public string TypeOfHome { get; set; }
        public string FloorPlan { get; set; }
        public string DescriptionOfChanges { get; set; }
        public string BasementType { get; set; }
        public string OtherDescription { get; set; }
        public string PackageOption { get; set; }
        public string Referral { get; set; }
        public List<IFormFile> Attachments { get; set; }
        public string Comments { get; set; }
        public string Page { get; set; }
    }
}
