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
    public partial class Contact : Page
    {
        string connString = ConfigurationManager.ConnectionStrings["MyAccessConn"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid2();
            }
        }



        private void BindGrid2()
        {
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = "SELECT * FROM StudentDB";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    conn.Open();
                    gvInventory.DataSource = cmd.ExecuteReader();
                    gvInventory.DataBind();
                }
            }
        }

        protected void btn2Submit_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = "INSERT INTO StudentDB (StudentID, Fullname, Program, Age, Address) VALUES (?, ?, ?, ?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudID", txtid.Text);
                    cmd.Parameters.AddWithValue("@FName", txtfname.Text);
                    cmd.Parameters.AddWithValue("@Pro", txtpro.Text);
                    cmd.Parameters.AddWithValue("@Age", txtage.Text);
                    cmd.Parameters.AddWithValue("@Add", txtadd.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            txtid.Text = "";
            txtfname.Text = "";
            txtpro.Text = "";
            txtage.Text = "";
            txtadd.Text = "";
            BindGrid2();
        }

        protected void gvInventory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvInventory.EditIndex = e.NewEditIndex;
            BindGrid2();
        }

        protected void gvInventory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvInventory.EditIndex = -1;
            BindGrid2();
        }

        protected void gvInventory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int productId = Convert.ToInt32(gvInventory.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvInventory.Rows[e.RowIndex];

            string id = ((TextBox)row.Cells[1].Controls[0]).Text.Trim();
            string fname = ((TextBox)row.Cells[2].Controls[0]).Text.Trim();
            string pro = ((TextBox)row.Cells[3].Controls[0]).Text.Trim();
            string age = ((TextBox)row.Cells[4].Controls[0]).Text.Trim();
            string add = ((TextBox)row.Cells[5].Controls[0]).Text.Trim();

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = "UPDATE StudentDB SET StudentID = ?, FullName = ?, Program = ? Age = ? WHERE Address = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudID", id);
                    cmd.Parameters.AddWithValue("@fname", fname);
                    cmd.Parameters.AddWithValue("@pro", pro);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@age", add);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            gvInventory.EditIndex = -1;
            BindGrid2();
        }

        protected void gvInventory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productId = Convert.ToInt32(gvInventory.DataKeys[e.RowIndex].Value);

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = "DELETE FROM inventory WHERE StudentID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", StudentID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            BindGrid2();
        }
    }
}
