using System;
using Xunit;
using Donnees;

namespace TestUnitaires
{
    public class UnitTest_Piste
    {
        [Fact]
        public void TestTitrePiste()
        {
            Piste p1 = new Piste("PisteVide");
            Assert.Equal("PisteVide", p1.Titre);
          
        }

        
        


    }
}
