using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Newssite.Pages
{
    [ValidateAntiForgeryToken]
    public class LogoutModel : PageModel
    {
        /// <summary>
        /// Clears the session variabel, thus logging out.
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            HttpContext.Session.SetString("username", "");
            return new RedirectToPageResult("/Index");
        }
    }
}
