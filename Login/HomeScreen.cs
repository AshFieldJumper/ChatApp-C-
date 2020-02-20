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

            //this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

       // private const int cGrip = 16;
       // private const int cCaption = 32;

        //protected override void WndProc(ref Message m)
        //{
            //if (m.Msg == 0x84)
            //{
                //Point pos = new Point(m.LParam.ToInt32());
               // pos = this.PointToClient(pos);
                //if (pos.Y < cCaption)
                //{
                //    m.Result = (IntPtr)2;
                   // return;
               // }
                //if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                //{
                   // m.Result = (IntPtr)17;
                    //return;
              //  }
            //}
            //base.WndProc(ref m);
        //}
       
    }
}
