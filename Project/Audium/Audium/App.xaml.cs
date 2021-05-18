using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MaterialDesignThemes.Wpf;
using MaterialDesignColors;
using System.Windows.Media;
using Gestionnaires;
using Donnees;


namespace Audium
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {

        public Manager LeManager { get; private set; } = new Manager();

       

        public ManagerProfil LeManagerProfil { get; private set; } = new ManagerProfil();

        public App()
        {
          

        }





        public void Amber()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.Amber];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }

        public void Blue()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.Blue];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }

        public void BlueGrey()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.BlueGrey];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }

        public void Cyan()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.Cyan];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }
        public void DeepOrange()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.DeepOrange];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }

        public void DeepPurple()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.DeepPurple];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }

        public void Green()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.Green];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }
        public void Grey()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.Grey];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }
        public void Indigo()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.Indigo];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }
        public void LightBlue()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.LightBlue];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }
        public void LightGreen()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.LightGreen];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }
        public void Lime()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }
        public void Orange()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.Orange];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }
        public void Pink()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.Pink];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }
        public void Purple()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.Purple];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }
        public void Red()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.Red];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }
        public void Teal()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.Teal];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }
        public void Yellow()
        {
            Color primaryColor = SwatchHelper.Lookup[MaterialDesignColor.Yellow];
            Color accentColor = SwatchHelper.Lookup[MaterialDesignColor.Lime];
            ITheme theme = Theme.Create(new MaterialDesignDarkTheme(), primaryColor, accentColor);
            Resources.SetTheme(theme);
        }
    }


    
}
