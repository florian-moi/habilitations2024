using habilitations2024.dal;
using habilitations2024.model;

namespace Monapp.tests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DeveloppeurAccess DevAccess = new DeveloppeurAccess();
            Profil pro = new Profil(5, "admin");
            int nombreAttendu = 4;


            List<Developpeur> result = DevAccess.GetLesDeveloppeur(pro);


            Assert.IsNotNull(result, "La liste ne doit pas être nulle");
            Assert.AreEqual(nombreAttendu, result.Count, "Le nombre de développeurs récupéré ne correspond pas");
        }
    }
}
