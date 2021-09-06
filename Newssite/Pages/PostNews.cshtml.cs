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
    public class PostNewsModel : PageModel
    {
        public IActionResult OnGet()
        {
            return new RedirectToPageResult("/Index");
        }

        /// <summary>
        /// Requests the text from the form, sends it to the DbHandler so it can update the database. Lastly, redirects to Index again.
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            string header = Request.Form["headline"];
            string newsText = Request.Form["newstext"];
            string user = HttpContext.Session.GetString("username");
            new DbHandler().SaveNewsToDb(header, newsText, DateTime.Now, user);
            return new RedirectToPageResult("/Index");
        }
    }
}
