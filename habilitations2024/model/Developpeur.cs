using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.model
{
    public class Developpeur
    {
        public Developpeur(int idDeveloppeur, string nom, string prenom, string tel, string email, Profil profil)
        {
            this.IdDeveloppeur = idDeveloppeur;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Tel = tel;
            this.Email = email;
            this.MotDePasse = MotDePasse;
            this.Profil = profil;
        }

        public int IdDeveloppeur { get; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public string MotDePasse { get; set; }

        public Profil Profil { get; set; }
    }
}
