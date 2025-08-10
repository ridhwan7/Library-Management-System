using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagment
{
    public partial class viewusers__ : Form
    {
        private DataTable users1;
        public viewusers__()
        {
            InitializeComponent();
        }

        private void viewusers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'users._Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.users._Users);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dataGridView1.CurrentRow;
                ID.Text = selectedRow.Cells[2].Value?.ToString();
                Name.Text = selectedRow.Cells[0].Value?.ToString();
                Password.Text = selectedRow.Cells[1].Value?.ToString();

              

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            String Name_ = Name.Text.ToString();
            String pass_ = Password.Text.ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandText = "DELETE FROM Users WHERE ID='" + ID.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            this.usersTableAdapter.Fill(this.users._Users);

            // Store a reference to the DataTable


            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = users._Users;


            MessageBox.Show("User Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            String Name_ = Name.Text.ToString();
            String pass_ = Password.Text.ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandText = "UPDATE Users SET UserName = @name,Password = @auth  WHERE ID ='" + int.Parse(ID.Text.ToString()) + "'";
            cmd.Parameters.AddWithValue("@name", Name.Text.Trim());
            cmd.Parameters.AddWithValue("@auth", Password.Text.Trim());
            cmd.ExecuteNonQuery();
            conn.Close();
            this.usersTableAdapter.Fill(this.users._Users);

            // Store a reference to the DataTable

            users1 =users._Users;
            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = users1;


            MessageBox.Show("User Info Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBox1.Text.Replace("'", "''"); // Escape single quotes

            if (users1 != null)
            {
                users1.DefaultView.RowFilter = $"UserName LIKE '%{filterText}%' ";
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String Name_ = Name.Text.ToString();
            String pass_ = Password.Text.ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandText = "INSERT into Users (UserName,Password)  VALUES(@name,@auth)";
            cmd.Parameters.AddWithValue("@name", Name.Text.Trim());
            cmd.Parameters.AddWithValue("@auth", Password.Text.Trim());
            cmd.ExecuteNonQuery();
            conn.Close();
            this.usersTableAdapter.Fill(this.users._Users);

            // Store a reference to the DataTable

            users1 = users._Users;
            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = users1;


            MessageBox.Show("User Info Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
