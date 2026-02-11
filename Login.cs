using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M1Assessment_Par
{
    public partial class Login : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["MyAccessConn"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }



        private void BindGrid()
        {
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = "SELECT * FROM Users";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    conn.Open();
                }
            }
        }

        protected void btnLogin_Click_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["PatrollDB"].ConnectionString);

            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Users WHERE Username=? AND Password=?", con);

            cmd.Parameters.AddWithValue("?", usernametxt.Text);
            cmd.Parameters.AddWithValue("?", passwordtxt.Text);

            con.Open();
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Session["User"] = usernametxt.Text;
                Response.Redirect("Dashboard.aspx");
            }

            else
            {
                lblMsg.Text = "Invalid Username/Password.";
            }

            con.Close();
        }
    }
}
