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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Enter(txtUsername.Text, txtPassword.Text);
        }

        public static void Control()
        {
            try
            {
                string cmdString = "Create Database rustam";
                string server = System.Environment.MachineName;
                SqlConnection con = new SqlConnection("server=" + server + "\\SQLEXPRESS; Initial Catalog=master; Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = cmdString;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                con = new SqlConnection("server=" + server + "\\SQLEXPRESS; Initial Catalog=Rustam; Integrated Security=True");
                cmdString = "create table users"
                            + "(userID int primary key identity,"
                            + "userName varchar(30),"
                            + "userPassword varchar(30))"
                            + "insert into users values('alica','35688')"
                            + "create table books"
                            + "(userID int primary key identity,"
                            + "bookName varchar(30),"
                            + "bookAuthor varchar(30))"
                            + "insert into books values"
                            + "('Sefiller','Victor Hugo'),"
                            + "('1984', 'George Orwell'),"
                            + "('Hayvan Çiftliği', 'George Orwell')";
                cmd = new SqlCommand(cmdString, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {

            }


        }
        public static void Enter(string user, string pass)
        {
            string sorgu = "SELECT count(*) FROM users where userName='" + user + "' AND userPassword='" + pass + "'";
            string server = System.Environment.MachineName;
            SqlConnection con = new SqlConnection("server=" + server + "\\SQLEXPRESS; Initial Catalog =Rustam; Integrated Security = True");
            SqlCommand cmd = new SqlCommand(sorgu, con);

            con.Open();
            int c = Convert.ToInt32(cmd.ExecuteScalar());
            if (c==1)
            {
                frmMain frmMain = new frmMain();
                frmLogin flogin = new frmLogin();
                frmMain.activeUser = user;
                frmMain.ShowDialog();
                flogin.Close();

            }
            else
            {
                MessageBox.Show("Hatalı Giriş!");
            }
            con.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Control();
        }
    }
}
