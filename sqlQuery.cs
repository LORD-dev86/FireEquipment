using Npgsql;
using System.Data;

namespace FireEquipment2
{
    public static class SqlQuery
    {
        public static string connString = string.Format("Server={0};Port={1};" +
            "User Id={2};Password={3};Database={4}",
            "localhost", 5432, 
            "postgres", "postgres", "FireEquipment");
        public static NpgsqlConnection conn;
        public static string sql;
        public static NpgsqlCommand cmd;
        public static NpgsqlDataReader dr;
    }
}
