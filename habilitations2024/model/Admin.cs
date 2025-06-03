using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.model
{
    public class Admin
    {
         public Admin(string nom, string prenom, string pwd)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.pwd = pwd;
        }

        public string nom { get; }

        public string prenom { get; }

        public string pwd { get; }
    }
}
