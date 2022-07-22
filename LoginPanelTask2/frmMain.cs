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

namespace LoginPanelTask2
{
    public partial class frmMain : Form
    {
        public string activeUser;


        SqlConnection con;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter dAdapter;
        string server = System.Environment.MachineName;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("server=" + server + "\\SQLEXPRESS; Initial Catalog=Rustam; Integrated Security=True");
            string comand = "select * from books";
            dAdapter = new SqlDataAdapter(comand, con);
            ds = new DataSet();
            con.Open();
            dAdapter.Fill(ds, "books");
            dgvBooks.DataSource = ds.Tables["books"];
            con.Close();

            lblWelcome.Text = "WELCOME " + activeUser.ToUpper();
        }
    }
}
