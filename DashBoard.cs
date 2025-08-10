using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagment
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want to Quit", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

       

        private void viewCatalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBooks v = new ViewBooks();
            v.Show();
        }

        private void addNewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addbook s = new addbook();
            s.Show();
        }

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllocateBook a = new AllocateBook();
            a.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void addNewUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewusers__ f = new viewusers__();
            f.Show();
            
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewusers__ v = new viewusers__();
            v.Show();
        }
    }
}
