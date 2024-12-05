using System.Threading.Tasks;
using BA.AvalonLogHomes.DataModels;
using BA.AvalonLogHomes.Adapters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using BA.Common.Services;
using reCAPTCHA.AspNetCore;

namespace BA.AvalonLogHomes.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly ISmtpService _smtpService;
        private readonly IRecaptchaService _recaptcha;

        [BindProperty]
        public ContactUsModel contactUsModel { get; set; }

        public ContactModel(IConfiguration config, ISmtpService smtpService, IRecaptchaService recaptcha)
        {
            _config = config;
            _smtpService = smtpService;
            _recaptcha = recaptcha;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPost()
        {


            if (ModelState.IsValid)
            {
                contactUsModel.Page = "ContactUs";
                RecaptchaResponse recaptcha = await _recaptcha.Validate(Request);
                if (!recaptcha.success)
                {
                    ModelState.AddModelError("Recaptcha", "There was an error validating the Recaptcha code.  Please try Again!");
                    return Page();
                }
                else
                {
                    ContactUsAdapter contactUs = new ContactUsAdapter(_config, _smtpService, contactUsModel);
                    await contactUs.CreateAndSendEmail();
                    return RedirectToPage("/ThankYou");
                }
            }
            else
            {
                return Page();
            }
        }
    }
}