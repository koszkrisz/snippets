using MySql.Data.MySqlClient;

// MySQL kapcsolat minta WPF-ben

string kapcsolat = "server=localhost;database=versenyek;uid=root;pwd=;";

MySqlConnection conn = new MySqlConnection(kapcsolat);

try
{
    conn.Open();

    string lekerdezes = "SELECT nev, eredmeny FROM versenyzok";

    MySqlCommand cmd = new MySqlCommand(lekerdezes, conn);

    MySqlDataReader reader = cmd.ExecuteReader();

    while (reader.Read())
    {
        string nev = reader["nev"].ToString();
        string eredmeny = reader["eredmeny"].ToString();

        Console.WriteLine($"{nev} - {eredmeny}");
    }

    reader.Close();
}
catch (Exception ex)
{
    MessageBox.Show(ex.Message);
}
finally
{
    conn.Close();
}