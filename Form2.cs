using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagment
{
  
    public partial class Form2 : Form
    {
        bool showpassword;
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            showpassword = !checkBox1.Checked;
            Passwordinput.UseSystemPasswordChar = showpassword;
            password.UseSystemPasswordChar = showpassword;
        }

        private void Signup_Click(object sender, EventArgs e)
        {
            String UserName = Usernameinput.Text;
            String Password = Passwordinput.Text;
            if (password.Text == Passwordinput.Text )
            {  if(!Usernameinput.Text.Contains("User")|| !Usernameinput.Text.Contains("user")) { 
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                conn.Open();
                    cmd.CommandText = "INSERT INTO Users (UserName, Password) VALUES ('" + UserName + "','" + Password + "')";

                    cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("User Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Username cannot contain the word User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                               MessageBox.Show("Password does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Usernameinput_TextChanged(object sender, EventArgs e)
        {
            if (Usernameinput.Text.Contains("User") )
            {

                Usernameinput.Clear();
            }
            Usernameinput.ForeColor = Color.White;
            panel1.BackColor = Color.White;
        }

        private void Passwordinput_TextChanged(object sender, EventArgs e)
        {
            if (Passwordinput.Text.Contains("passwo"))
            {
                 
                Passwordinput.Clear();
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            if (password.Text.Contains("confirm"))
            {

                password.Clear();
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
           Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ridhwan7");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/ridwan-olateju-75a079284");
        }
    }
}
