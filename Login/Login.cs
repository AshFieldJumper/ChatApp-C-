using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Login
{
    public partial class Login : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        public Login()
        {
            InitializeComponent();
        }

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Register registernew = new Register();
            registernew.Show();
            this.Hide();
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
        private void login()
        {
            string password = textBox2.Text;
            string email = textBox1.Text;
            bool loggedin = false;
            if (email != "" || password != "")
            {
                string postData = "email=" + email + "&password=" + password;
                string suburl = "login";
                var data = Helpers.webPostMethod(postData, suburl);
                Console.WriteLine(data);

                try
                {
                    dynamic stuff = JsonConvert.DeserializeObject(data);
                    Console.WriteLine(data);
                    Console.WriteLine(stuff);

                    Helpers.api_token = stuff.api_token;

                    if ((bool)stuff.success)
                    {
                        loggedin = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    MessageBox.Show("Password or username is invalid !");

                }
                if (loggedin)
                {
                    Home newhome = new Home();
                    newhome.ShowDialog();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomeScreen newhomescreen = new HomeScreen();
            newhomescreen.Show();
            this.Hide();
        }
    }
}
