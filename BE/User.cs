using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum UserType { admin, webmaster, user }
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public UserType userType { get; set; }

        public override string ToString()
        {
            return username;
        }

    }
}
