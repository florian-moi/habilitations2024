using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.model
{
    public class Profil
    {
        private int idProfil;

        private string nom;

        public Profil(int idProfil, string nom)
        {
            this.idProfil = idProfil;
            this.nom = nom;
        }

        public int IdProfil { get => idProfil;}

        public string Nom { get => nom;}

        public override string ToString()
        {
            return  nom;
        }
    }
}
