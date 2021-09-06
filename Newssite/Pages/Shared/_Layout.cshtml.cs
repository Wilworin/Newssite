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
    public class _LayoutModel : PageModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public void OnGet()
        {
            UserName = HttpContext.Session.GetString("username");
        }

        public void OnPost()
        {
            UserName = Request.Form["username"];
            PassWord = Request.Form["password"];
            HttpContext.Session.SetString("username", "Bernie");
        }
    }
}
