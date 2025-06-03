using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using habilitations2024.model;

namespace habilitations2024.dal
{
    public class ProfilAccess
    {
        private readonly Acces acces = null;

        public ProfilAccess(){ 
            acces = Acces.GetInstance();
        }

        public List<Profil> GetLesProfils()
        {
            List<Profil> lesProfils = new List<Profil>();
            if (acces.Manager != null)
            {
                string req = "SELECT profil.idprofil, profil.nom FROM profil ORDER BY idprofil ASC";
                try
                {
                    List<Object[]> records = acces.Manager.ReqSelect(req);
                    foreach (Object[] ligne in records)
                    {
                        if (records != null)
                        {

                            Profil profil = new Profil((int)ligne[0], (string)ligne[1]);
                            lesProfils.Add(profil);


                        }

                    }
                }catch (Exception)
                { 
                    Environment.Exit(0); 
                }
                return lesProfils;
            }
            return null;
        }

    }
}
