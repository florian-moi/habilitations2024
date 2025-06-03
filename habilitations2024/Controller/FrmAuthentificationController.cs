using habilitations2024.dal;
using habilitations2024.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.Controller
{
    public class FrmAuthentificationController
    {
        private readonly DeveloppeurAccess developpeuracces;

        private readonly ProfilAccess profilacces;

        public FrmAuthentificationController()
        {
            developpeuracces = new DeveloppeurAccess();
            profilacces = new ProfilAccess();
        }

        public List<Developpeur> GetDeveloppeurs()
        {
            return developpeuracces.GetLesDeveloppeur();
        }

        public bool ControleAuthentification(Admin admin)
        {
            return developpeuracces.ControleAuthentification(admin);
        }
    }
}
