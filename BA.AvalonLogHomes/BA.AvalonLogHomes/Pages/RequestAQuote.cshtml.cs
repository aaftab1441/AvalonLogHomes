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
    public class RequestAQuoteViewModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly ISmtpService _smtpService;
        private readonly IRecaptchaService _recaptcha;

        [BindProperty]
        public RequestAQuoteModel RequestAQuoteModel { get; set; }

        public RequestAQuoteViewModel(IConfiguration config, ISmtpService smtpService, IRecaptchaService recaptcha)
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
                RequestAQuoteModel.Page = "RequestAQuote";
                RecaptchaResponse recaptcha = await _recaptcha.Validate(Request);
                if (!recaptcha.success)
                {
                    ModelState.AddModelError("Recaptcha", "There was an error validating the Recaptcha code.  Please try Again!");
                    return Page();
                }
                else
                {
                    ContactUsAdapter contactUs = new ContactUsAdapter(_config, _smtpService, RequestAQuoteModel);
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