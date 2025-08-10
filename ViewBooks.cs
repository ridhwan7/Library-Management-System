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
    public partial class ViewBooks : Form
    {
        private DataTable booksTable;

        int bid;
        List<DataGridViewRow> rowss = new List<DataGridViewRow>();
        public ViewBooks()
        {
            InitializeComponent();

            this.newBookTableAdapter.Fill(this.book.NewBook);

            // Initialize and assign booksTable
            booksTable = book.NewBook;

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = booksTable;

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = booksTable;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewBooks_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'book.NewBook' table. You can move, or remove it, as needed.
            this.newBookTableAdapter.Fill(this.book.NewBook);
            // TODO: This line of code loads data into the 'database1DataSet10.NewBook' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'database1DataSet8.NewBook' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'database1DataSet6.NewBook' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'database1DataSet1.NewBook' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'database1DataSet.Users' table. You can move, or remove it, as needed.
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            String BN = BookName.Text;
            String AuthorN = Author.Text;
            String GenreN = Genre.Text;
            String PriceN = Price.Text;
            String Quantity_ =Quantity.Text;
            String Date= Date_.Value.ToString();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandText = "UPDATE NewBook SET Book_Name = @name,Author = @auth,Genre=@gen,Price=@pri,Date=@date,Quantity=@num WHERE ID ='" + int.Parse(BookID.Text.ToString()) + "'";

            cmd.Parameters.AddWithValue("@name", BookName.Text.Trim());
            cmd.Parameters.AddWithValue("@auth", Author.Text.Trim());
            cmd.Parameters.AddWithValue("@date", Date_.Value.Date);
            cmd.Parameters.AddWithValue("@gen", Genre.Text.Trim());
            cmd.Parameters.AddWithValue("@Pri", Price.Text.Trim());
            cmd.Parameters.AddWithValue("@num", int.Parse(Quantity_.ToString()));
            cmd.ExecuteNonQuery();
            conn.Close();
            this.newBookTableAdapter.Fill(this.book.NewBook);

            // Store a reference to the DataTable
            booksTable = book.NewBook;

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = booksTable;


            MessageBox.Show("Book Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBox1.Text.Replace("'", "''"); // Escape single quotes

            if (booksTable != null)
            {
                booksTable.DefaultView.RowFilter = $"Book_Name LIKE '%{filterText}%' OR Author LIKE '%{filterText}%'";
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addbook a = new addbook();
            a.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            String BN = BookName.Text;
            String AuthorN = Author.Text;
            String GenreN = Genre.Text;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandText = "DELETE FROM NewBook WHERE ID='" + BookID.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            this.newBookTableAdapter.Fill(this.book.NewBook);

            // Store a reference to the DataTable
            booksTable = book.NewBook;

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = booksTable;

            
            MessageBox.Show("Book Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Author_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dataGridView1.CurrentRow;
                BookID.Text = selectedRow.Cells[0].Value?.ToString();
                BookName.Text = selectedRow.Cells[1].Value?.ToString();
                Author.Text = selectedRow.Cells[2].Value?.ToString();
                
                Genre.Text = selectedRow.Cells[3].Value?.ToString();
                Price.Text = selectedRow.Cells[4].Value?.ToString();
                Date_.Value = Convert.ToDateTime(selectedRow.Cells[5].Value);
                Quantity.Text = selectedRow.Cells[6].Value?.ToString();

            }
        }

        private void BookName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AllocateBook allocateBook = new AllocateBook();
            allocateBook.Show();
            this.Close();
        }
    }
}
