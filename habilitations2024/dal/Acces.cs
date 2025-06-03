using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using habilitations2024.bddManager;

namespace habilitations2024.dal
{
    public class Acces
    {
        private static readonly String connection = "Server=localhost;DataBase=Habilitations;User=root;PassWord=";
        
        private static Acces instance = null;

        public BddManager Manager { get; }

        private Acces()
        {
            try
            {
                Manager = BddManager.GetInstance(connection);
            }catch (Exception)
            { 
                Environment.Exit(0); 
            
            }
        }

        public static Acces GetInstance()
        {
            if (instance == null)
            {
                instance = new Acces();
            }
            return instance;
        }
    }
}
