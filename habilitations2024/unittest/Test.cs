
using System.Collections.Generic;
using habilitations2024.dal;
using habilitations2024.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace habilitations2024.unittest
{
    [TestClass]
    public class Test1
    {
        DeveloppeurAccess  devAccess;
        
        [TestInitialize]
        public void Initialize()
        {

           devAccess = new DeveloppeurAccess();

        }
            
        [TestMethod]
        public void TestMethod_GetLesDeveloppeur_avecfiltre_profil()
        {

            var profil = new Profil(5, "admin");
            int nombreAttendu = 4;

            List<Developpeur> result = devAccess.GetLesDeveloppeur(profil);


            Assert.IsNotNull(result, "La liste ne doit pas être nulle");
            Assert.AreEqual(nombreAttendu, result.Count, "Le nombre de développeurs récupéré ne correspond pas au filtre profil");
        }

        [TestMethod]
        public void TestMethod_GetLesDeveloppeur_sansfiltre()
        {
            int nombreAttendu = 23;
           
            List<Developpeur> result = devAccess.GetLesDeveloppeur();
           
            Assert.IsNotNull(result, "La liste ne doit pas être nulle");
            Assert.AreEqual(nombreAttendu, result.Count, "Le nombre de développeurs récupéré ne correspond pas au total dans la base de données");
        }
    }
}
