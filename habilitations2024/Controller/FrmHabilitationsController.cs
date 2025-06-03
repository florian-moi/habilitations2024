using habilitations2024.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using habilitations2024.dal;

namespace habilitations2024.Controller
{
    public class FrmHabilitationsController
    {
        private readonly DeveloppeurAccess developpeuracces;

        private readonly ProfilAccess profilacces;

        public FrmHabilitationsController()
        {
            developpeuracces = new DeveloppeurAccess();
            profilacces = new ProfilAccess();
        }

        public List<Developpeur> GetDeveloppeurs(Profil pro = null)
        {
            if (pro == null)
            {
                return developpeuracces.GetLesDeveloppeur();
            }
            else
            {
                return developpeuracces.GetLesDeveloppeur(pro);
            }
        }

        public List<Profil> GetProfils()
        {
            return profilacces.GetLesProfils();
        }

        public void DelDeveloppeur(Developpeur developpeur)
        {
            developpeuracces.DelDeveloppeur(developpeur);
        }

        public void AddDeveloppeur(Developpeur developpeur)
        {
            developpeuracces.AddDeveloppeur(developpeur);
        }

        public void UpdateDeveloppeur(Developpeur developpeur)
        {
            developpeuracces.UpdateDeveloppeur(developpeur);
        }

        public void UpadatePwdDeveloppeur(Developpeur developpeur, string newPwd)
        {
            developpeuracces.UpdatePwd(developpeur);

        }
    }
}
