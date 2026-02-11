protected void btnLogin_Click_Click(object sender, EventArgs e)
{
    using (OleDbConnection con = new OleDbConnection(connString))
    {
        OleDbCommand cmd = new OleDbCommand(
            "SELECT * FROM Users WHERE Username=? AND [Password]=?", con);

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
    }
}
