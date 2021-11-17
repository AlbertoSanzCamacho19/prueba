using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1
{
    public class Usuario
    {
        public string User { set; get ;}
        public string Password { set; get ;}
        public Usuario(String user, string password)
        {
            User = user;
            Password = password;

        }
      
    }
}
