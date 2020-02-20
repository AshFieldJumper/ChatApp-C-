using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Login
{
    public partial class HomeScreen : MaterialForm
    {
        public HomeScreen()
        {
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

        private void bunifuFlatButton(object sender, EventArgs e)
        {
            BunifuFlatButton b=sender as BunifuFlatButton;
            BunifuFlatButton b2 ;
            foreach (var obj in this.panel3.Controls)
            {

                if (obj is BunifuFlatButton )

                {
                    b2=obj as BunifuFlatButton;
                    if (b2.Active && b.Name!=b2.Name) 
                    {
                        b2.selected = false;
                    }
                    else
                    {
                        b2.selected = true;
                    }

                }
            }
        }
    }
}
