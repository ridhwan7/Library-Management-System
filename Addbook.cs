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
    public partial class addbook : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";

        public addbook()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAddBook_Click_1(object sender, EventArgs e)
        {
            // Validate input fields
            if (
                string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                string.IsNullOrWhiteSpace(Genre.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookId;
            

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO NewBook ( Book_Name, Author, Genre,Price, Date, Quantity) " +
                                   "VALUES ( @Title, @Author, @Genre,@Price, @Date, @Quantity)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                       
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Author", txtAuthor.Text.Trim());
                        cmd.Parameters.AddWithValue("@Date", dtpPublicationDate.Value.Date);
                        cmd.Parameters.AddWithValue("@Genre", Genre.Text.Trim());
                        cmd.Parameters.AddWithValue("@Price", PriceTxt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Quantity", (int)numQuantity.Value);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Book added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding book:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
       

        private void ClearForm()
        {
             
            txtTitle.Clear();
            txtAuthor.Clear();
            Genre.Clear();
            dtpPublicationDate.Value = DateTime.Now;
            numQuantity.Value = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewBooks v = new ViewBooks();
            v.Show();
           this.Hide();
        }

        private void txtBookId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpPublicationDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PriceTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void addbook_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllocateBook al = new AllocateBook();
            al.Show();
            this.Hide();
        }
    }
}
