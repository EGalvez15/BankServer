using Npgsql;

const string cs = "Server=localhost;Port=5432;Password=hentai42069;Username=postgres;";

using var con = new NpgsqlConnection(cs);
con.Open();

var sql = "SELECT version()";

using var cmd = new NpgsqlCommand(sql, con);

var version = cmd.ExecuteScalar().ToString();
Console.WriteLine($"PostgreSQL version: {version}");

con.Close();