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
        
        public ToDoItemRepository(string ConnectionString)
        {
            ConnString = ConnectionString;
        }
        // Create-----------------------------------------------------------------------------
        public void Create(ToDoItem item) 
        {
            using (var conn = dbConnection)
            {
                conn.Open();
                conn.Execute("INSERT INTO ToDoItem (Title) Values (@Title)", item);
            }
        }

        //Update-------------------------------------------------------------------------------
        public void Update() { }

        // Delete------------------------------------------------------------------------------
        public void Delete(int id) 
        {
            using (var conn = dbConnection)
            {
                conn.Open();
                conn.Execute("DELETE FROM ToDoItem WHERE Id = @id", new { id }); 
            }
        }
        
        public void Read() { }
        // GetAll methode (Item List)-----------------------------------------------------------
        public IEnumerable<ToDoItem> GetAll()
        {
            using (var conn = dbConnection)
            {
                dbConnection.Open(); // Kaufmann fragen: Wenn dbConnection steht wird eine neue Instanz(/Objekt) erstellt? conn ist die Variable für die geöffnete Instaz? 
                var result = dbConnection.Query<ToDoItem>("SELECT * FROM ToDoItem");
                return result;
            }
        }



    }
}