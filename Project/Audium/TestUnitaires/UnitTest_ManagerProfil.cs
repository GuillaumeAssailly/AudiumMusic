using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donnees;
using Gestionnaires;
using Xunit;

namespace TestUnitaires
{
    public class UnitTest_ManagerProfil
    {

        [Fact]
        public void TestCouleurDéfaut()
        {
            ManagerProfil profil = new();
            Assert.Equal("Blue", profil.CouleurTheme);
            

        }

        [Fact]
        public void TestModifParam()
        {
            ManagerProfil profil = new();
            profil.ModifierParamètres("Indigo", "SuperChemin");
            Assert.Equal("SuperChemin", profil.CheminBaseDonnees);
        }

        [Fact]
        public void TestModifProfil()
        {
            ManagerProfil profil = new();
            profil.ModifierProfil("Charles", "Image");
            Assert.Equal("Charles", profil.Nom);
        }

        [Fact]
        public void TestAjouterFavoris()
        {
            ManagerProfil profil = new();
            EnsembleAudio e = new EnsembleAudio("test", "un album test", "img.png", EGenre.GenreMusique.JAZZ);
            profil.ModifierListeFavoris(e);
            Assert.Single(profil.ListFavoris);
            Assert.True(e.Favori);

        }

        [Fact]
        public void TestRetirerFavoris()
        {
            ManagerProfil profil = new();
            EnsembleAudio e = new EnsembleAudio("test", "un album test", "img.png", EGenre.GenreMusique.JAZZ);
            profil.ModifierListeFavoris(e);
            profil.ModifierListeFavoris(e);
            Assert.Empty(profil.ListFavoris);
            Assert.False(e.Favori);
        }

        




    }
}
