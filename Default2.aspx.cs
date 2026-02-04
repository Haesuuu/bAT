using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lt6.StudentWebApp_Par
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        string connString = ConfigurationManager.ConnectionStrings["MyAccessConn"].ConnectionString;
        private void BindGrid()
        {
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = "SELECT * FROM Users";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    conn.Open();
                    gvUsers.DataSource = cmd.ExecuteReader();
                    gvUsers.DataBind();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = "INSERT INTO Users (UserName, Email) VALUES (?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            txtName.Text = "";
            txtEmail.Text = "";
            BindGrid();
        }

        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            BindGrid();
        }

        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);

            GridViewRow row = gvUsers.Rows[e.RowIndex];
            string name = ((TextBox)row.Cells[1].Controls[0]).Text.Trim();
            string email = ((TextBox)row.Cells[2].Controls[0]).Text.Trim();

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = "UPDATE Users SET UserName = ?, Email = ? WHERE ID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@id", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            gvUsers.EditIndex = -1;
            BindGrid();
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = "DELETE FROM Users WHERE ID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            BindGrid();
        }
    }
}