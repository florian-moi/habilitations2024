using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using habilitations2024.model;
using MySql.Data.MySqlClient;

namespace habilitations2024.dal
{
    public class DeveloppeurAccess
    {
        private readonly Acces acces = null;

        public DeveloppeurAccess() {
            acces = Acces.GetInstance();
        }

        public List<Developpeur> GetLesDeveloppeur()
        {
            List<Developpeur> lesDevs = new List<Developpeur>();
            if (acces.Manager != null)
            {
                try
                {
                    string req = "SELECT developpeur.iddeveloppeur,developpeur.nom,prenom,tel,mail,developpeur.idprofil,profil.nom FROM developpeur JOIN profil ON developpeur.idprofil = profil.idprofil";
                    List<Object[]> records = acces.Manager.ReqSelect(req);

                    foreach (Object[] record in records)
                    {
                        if (records != null)
                        {
                            Profil profil = new Profil((int)record[5], (string)record[6]);
                            Developpeur dev = new Developpeur((int)record[0], (string)record[1], (string)record[2], (string)record[3], (string)record[4], profil);
                            lesDevs.Add(dev);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return lesDevs;
            }
            return null;

        }

        public void DelDeveloppeur(Developpeur developpeur)
        {
            if (acces.Manager != null)
            {
                int id = developpeur.IdDeveloppeur;
                Dictionary<string, object> dic = new Dictionary<string, object>();
                string req = $"DELETE FROM developpeur WHERE developpeur.iddeveloppeur = {id}";


                try
                {


                    acces.Manager.ReqUpdate(req);
                }
                catch (Exception)
                {
                    Environment.Exit(0);
                }
            }
        }
        public void AddDeveloppeur(Developpeur developpeur)
        {
            if (acces.Manager != null)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();

                dic.Add("@Nom", developpeur.Nom);
                dic.Add("@Prenom", developpeur.Prenom);
                dic.Add("@tel", developpeur.Tel);
                dic.Add("@mail", developpeur.Email);
                dic.Add("@PWD", developpeur.MotDePasse);
                dic.Add("@idprofil", developpeur.Profil.IdProfil);

                string req = "INSERT INTO developpeur (nom,prenom,tel,mail,pwd,idprofil) values (@Nom,@Prenom,@tel,@mail,SHA2(@PWD,256),@idprofil)";

                try
                {
                    acces.Manager.ReqUpdate(req, dic);
                }
                catch (Exception)
                {
                    Environment.Exit(0);
                }
            }
        }

        public void UpdateDeveloppeur(Developpeur developpeur)
        {
            if (acces.Manager != null)
            {
                string req = "update developpeur set nom = @nom, prenom = @prenom, tel = @tel, mail = @mail, idprofil = @idprofil where iddeveloppeur = @iddeveloppeur;";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idDeveloppeur", developpeur.IdDeveloppeur);
                parameters.Add("@nom", developpeur.Nom);
                parameters.Add("@prenom", developpeur.Prenom);
                parameters.Add("@tel", developpeur.Tel);
                parameters.Add("@mail", developpeur.Email);
                parameters.Add("idprofil", developpeur.Profil.IdProfil);
                try
                {
                    acces.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }


        }

        public void UpdatePwd(Developpeur developpeur)
        {
            if (acces.Manager != null)
            {
                string req = "update developpeur set pwd = SHA2(@pwd, 256) ";
                req += "where iddeveloppeur = @iddeveloppeur;";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idDeveloppeur", developpeur.IdDeveloppeur);
                parameters.Add("@pwd", developpeur.MotDePasse);
                try
                {
                    acces.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
        }

        public bool ControleAuthentification(Admin admin)
        {
            if (acces.Manager != null)
            {
                
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    string req = "SELECT * FROM developpeur WHERE nom = @Nom AND prenom = @prenom AND pwd = SHA2(@pwd,256) AND idprofil = 5;";
                    parameters.Add("@Nom", admin.nom);
                    parameters.Add("@prenom", admin.prenom);
                    parameters.Add("@pwd", admin.pwd);
                try {
                    List<Object[]> records = acces.Manager.ReqSelect(req,parameters);

                    if (records != null && records.Count > 0 && records[0] != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return false;
                
            }
        }
    }


