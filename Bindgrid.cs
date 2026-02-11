private void BindGrid()
{
    using (OleDbConnection conn = new OleDbConnection(connString))
    {
        string query = "SELECT * FROM Users";

        using (OleDbCommand cmd = new OleDbCommand(query, conn))
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
            {
                System.Data.DataTable dt = new System.Data.DataTable();

                conn.Open();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}
