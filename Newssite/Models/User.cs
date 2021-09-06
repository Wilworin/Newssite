using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newssite.Pages
{
    public class User
    {
        private int Id { get; set; }
        public string UserName { get; private set; }
        private string Password { get; set; }

        public User(string user, string pass)
        {
            UserName = user;
            Password = pass;
        }
    }
}
