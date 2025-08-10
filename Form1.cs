using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Security;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibraryManagment
{
    public partial class Form1 : Form
    {
        bool showpassword;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

      
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

       
        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

       
        

      

        private void Usernameinput_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (Usernameinput.Text == "Username")
            {

                Usernameinput.Clear();
            }
            Usernameinput.ForeColor = Color.White;
            panel1.BackColor = Color.White;
        }

        private void t(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;


            cmd.CommandText = "select * from Users where UserName = '"+Usernameinput.Text+"' and Password ='"+Passwordinput.Text+"' ";
         SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                DashBoard Ds = new DashBoard();
                Ds.Show();
                this.Hide();


            }
            else {
                MessageBox.Show("Wrong Username or Password", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

      
        private void Usernameinput_Leave(object sender, EventArgs e)
        {
            if (Usernameinput.Text != "")
            {
                Usernameinput.ForeColor = Color.LawnGreen;
                panel1.BackColor = Color.LawnGreen;
            }
        }

        private void Usernameinput_Validated(object sender, EventArgs e)
        {
           
           
        }

        private void Passwordinput_TextChanged(object sender, EventArgs e)
        {   
            Usernameinput.ForeColor = Color.White;

        }

        private void Passwordinput_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void Passwordinput_TextChanged_1(object sender, EventArgs e)
        {
            

            Passwordinput.ForeColor = Color.White;
            panel2.BackColor = Color.White;
        }

       

       

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            showpassword=!checkBox1.Checked;
            Passwordinput.UseSystemPasswordChar = showpassword;
        }

        private void Passwordinput_Leave(object sender, EventArgs e)
        {
            Passwordinput.ForeColor = Color.Orange;
            panel2.BackColor = Color.Orange;
        }

        private void Passwordinput_MouseClick(object sender, MouseEventArgs e)
        {
            if (Passwordinput.Text == "Password")
            {

                Passwordinput.Clear();
            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/ridwan-olateju-75a079284");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ridhwan7");
        }
    }
}
