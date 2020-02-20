using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Login
{
    public partial class HomeScreen : MaterialForm
    {
        public HomeScreen()
        {
            InitializeComponent();

            InitializeComponent();

            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Orange500, Primary.Yellow600,
                Primary.Yellow100, Accent.LightBlue200,
                TextShade.WHITE
            );
        }

    }
}
