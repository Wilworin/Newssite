using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Newssite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<News> NewsList = new();

        public string UserName { get; set; } = "";

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                UserName = HttpContext.Session.GetString("username");
            }
            else
            {
                UserName = "";
            }
            NewsList = new DbHandler().GetNewsFromDb();
        }

        public void OnPost()
        {
            string Test = "Test";
            ViewData["mytest"] = Test;
        }
    }
}
