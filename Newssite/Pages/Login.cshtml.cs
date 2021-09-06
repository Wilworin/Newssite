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
    public class LoginModel : PageModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        /// <summary>
        /// Checks if the supplied username and password matches a post in the database. If so, it sets the Session variable with the
        /// username. If not, it clears the Session variable.
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            UserName = Request.Form["username"];
            PassWord = Request.Form["password"];
            if (new DbHandler().CheckIfUser(UserName, PassWord))
            {
                HttpContext.Session.SetString("username", UserName);
            }
            else
            {
                HttpContext.Session.SetString("username", "");
            }
            return new RedirectToPageResult("/Index");
        }
    }
}
