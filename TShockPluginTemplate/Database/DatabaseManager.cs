using System.Data;
using MySql.Data.MySqlClient;
using Terraria;
using TShockAPI;
using TShockAPI.DB;

namespace TShockPluginTemplate
{
    public class DatabaseManager
    {
        public static string DatabasePath = Path.Combine(TShock.SavePath, "SFactions.sqlite");
        private IDbConnection? _db;

        public DatabaseManager(IDbConnection db)
        {
            _db = db;

            var sqlCreator = new SqlTableCreator(db, new SqliteQueryCreator());

            // Table 1
            sqlCreator.EnsureTableStructure(new SqlTable("TableName",
                new SqlColumn("ID", MySqlDbType.Int32) { Primary = true, Unique = true, AutoIncrement = true },
                new SqlColumn("Name", MySqlDbType.TinyText) { NotNull = true },
                new SqlColumn("Score", MySqlDbType.Int32) { DefaultValue = "0" }
                ));

            // Table 2
            sqlCreator.EnsureTableStructure(new SqlTable("SecondTableName",
                new SqlColumn("ID", MySqlDbType.Int32) { Primary = true, Unique = true, AutoIncrement = true },
                new SqlColumn("SomeAnotherProperty", MySqlDbType.Int32),
                new SqlColumn("SomeAnotherAnotherProperty", MySqlDbType.Int32)
                ));
        }

        public bool InsertRow(string name)
        {
            return _db.Query("INSERT INTO TableName (Name) VALUES (@0)", name) != 0;
        }


        public bool UpdateRow(int id, string name, int score)
        {
            return _db.Query("UPDATE TableName SET Name = @0, Score = @1 WHERE ID = @2", name, score, id) != 0;
        }

        public bool DeleteRow(int id)
        {
            return _db.Query("DELETE FROM TableName WHERE ID = @0", id) != 0;
        }

        public int? ReadScore(int id)
        {
            using var reader = _db.QueryReader("SELECT * FROM TableName WHERE ID = @0", id);
            
            while (reader.Read())
            {
                return reader.Get<int>("Score");
            }

            return null;
        }
    }
}