using MySqlConnector;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using ToDoApp.Repository;

namespace ToDoApp.Repository
{
    public class ToDoItemRepository

    {
        // Properties = 1.Schritt connection zur DB (dies ist der Speicher)
        private IDbConnection dbConnection => new MySqlConnection(ConnString);
        private String ConnString; 
        // 
        public ToDoItemRepository(string ConnectionString) {
            ConnString = ConnectionString;
        } 
        public void Create() { }
        public void Update() { }
        public void Delete() { }
        public void Read() { }
        public void ReadAll() { }

        

    }
}