using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e) {
            string username = textBox1.Text;
            string email = textBox2.Text;
            string password = textBox3.Text;
            string verepasswd = textBox4.Text;
            int passlength = password.Length;

            if (passlength > 8 || password == verepasswd)
            {
                string postData ="email=" + email + "&password="+ password+"&name="+username;
                var data = Helpers.webPostMethod(postData, "register");
                Console.WriteLine(data);
                dynamic response = JsonConvert.DeserializeObject(data);
                if ((bool)response.success)
                {
                    MessageBox.Show("Regristration succesful, Welcome: " + username + " !");
                    Console.WriteLine(data);
                    Login newlogin = new Login();
                    newlogin.Show();
                    this.Close();
                }
                else
                {
                    string errors = "";
                    string newLine = Environment.NewLine;

                    foreach (var err in response.error)
                    {
                        foreach (var text in err)
                            errors += "- " +text[0] + newLine;
                    }
                    MessageBox.Show("Regristration failed"+ newLine + newLine + errors, "Regristration failed");
                }

            }
            else if(passlength < 8)
            {
                MessageBox.Show("Password too short ");

            }
            else if(password != verepasswd)
            {
                MessageBox.Show("Password don't match !");
            }
            else
            {
                MessageBox.Show("Please fill in all forms !");

            }
            
           
        }

       
    }
}
