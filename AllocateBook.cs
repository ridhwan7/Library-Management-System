using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagment
{
    public partial class AllocateBook : Form
    {
        int res;
        String connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
        public AllocateBook()
        {
            InitializeComponent();
        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'book.NewBook' table. You can move, or remove it, as needed.
            this.newBookTableAdapter.Fill(this.book.NewBook);
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dataGridView1.CurrentRow;
                BookID.Text = selectedRow.Cells[0].Value?.ToString();
                quantitiy_.Text = selectedRow.Cells[6].Value?.ToString();
              
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (
              
              string.IsNullOrWhiteSpace(Amount.Text))
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

                        string query = "UPDATE NewBook SET Quantity = @Quantity WHERE ID ='" + int.Parse(BookID.Text.ToString()) + "' ";

                        int a = int.Parse(Amount.Text);
                        int b = int.Parse(quantitiy_.Text);

                        if (Action.Text == "Issue Book")
                        {
                            Amount.ForeColor = Color.Red;
                            res = b - a;
                        }
                        else if (Action.Text == "Book Return")
                        {
                            Amount.ForeColor = Color.Green;
                            res = b + a;
                        }
                    else
                        {
                            MessageBox.Show("Please select a valid action (Issue Book or Book Return).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                        {


                            cmd.Parameters.AddWithValue("@Quantity", res);


                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                MessageBox.Show("Operation Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Refresh();
                            }
                            else
                            {
                                MessageBox.Show("Failed to add book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    this.newBookTableAdapter.Fill(this.book.NewBook);

                    // Store a reference to the DataTable


                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = book.NewBook;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding book:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Amount_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(Amount.Text.ToString(), out int result))
            {
               
            }

            else
            {
                Amount.Clear();
                MessageBox.Show("Please enter a valid number for Amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             ViewBooks v = new ViewBooks();
            v.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addbook a= new addbook();
            a.Show();
            this.Hide();
        }
    }
}
