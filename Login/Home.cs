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
using Newtonsoft.Json;

// todo : Zoek button moet leeg worden wanneer er op geklikt wordt en gevuld worden met "Zoeken..." als ergens ander geklikt wordt.
//      : Vensters moet worden verplaatst. 

namespace Login
{
    public partial class Home : MaterialForm
    {
        public Home()
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

        private void button4_Click(object sender, EventArgs e)
        {
           
           Close();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e) {

        }

        private void onlineCheck_Tick(object sender, EventArgs e)
        {
            var online = Helpers.webGetMethod("online");
            Console.WriteLine(online);
            dynamic users = JsonConvert.DeserializeObject(online);
            foreach (var persoon in users)
            {
                Console.WriteLine(persoon.name);
            }
        }
    }
}
