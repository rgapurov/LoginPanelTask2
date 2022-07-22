using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPanelTask2
{
    public class methods
    {

        public static void Control()
        {
            try
            {
                string cmdString = "Create Database rustam";
                string server = System.Environment.MachineName;
                SqlConnection con = new SqlConnection("server=" + server + "\\SQLEXPRESS; Initial Catalog=master; Integrated Security=True");
                SqlCommand cmd = new SqlCommand(cmdString, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                con = new SqlConnection("server=" + server + "\\SQLEXPRESS; Initial Catalog=Rustam; Integrated Security=True");
                cmdString =  "create table users"
                            +"(userID int primary key identity,"
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
    }
}
