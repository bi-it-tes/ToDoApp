using Dapper;
using MySqlConnector;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using ToDoApp.Model;
using ToDoApp.Repository;

namespace ToDoApp.Repository
{
    public class ToDoItemRepository

    {
        // Properties = 1.Schritt connection zur DB (dies ist der Speicher)
        private IDbConnection dbConnection => new MySqlConnection(ConnString);
        private String ConnString;
        // 
        public ToDoItemRepository(string ConnectionString)
        {
            ConnString = ConnectionString;
        }
        public void Create(ToDoItem item) 
        {
            using (var conn = dbConnection)
            {
                conn.Open();
                conn.Execute("INSERT INTO ToDoItem (Title) Values (@Title)", item);
            }
        }
        public void Update() { }
        public void Delete() { }
        public void Read() { }
        public IEnumerable<ToDoItem> GetAll()
        {
            using (var conn = dbConnection)
            {
                conn.Open(); // Kaufmann fragen: Wenn dbConnection steht wird eine neue Instanz erstellt? conn ist die Variable für die geöffnete Instaz? 
                var result = conn.Query<ToDoItem>("SELECT * FROM ToDoItem");
                return result;
            }
        }



    }
}