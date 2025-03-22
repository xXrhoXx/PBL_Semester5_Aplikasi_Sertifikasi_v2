using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAccessorApp.Models.ViewModels
{
    public class UserSession
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }

        public UserSession() { }
        public UserSession(string username, string email, int id)
        {
            this.username = username;
            this.id = id;
            this.email = email;
        }
    }
}
