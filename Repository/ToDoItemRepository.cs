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
        public void Update(int id, string title) 
        {
            using (var conn = dbConnection)
            {
                conn.Open();
                conn.Execute("UPDATE ToDoItem SET Title = @Title WHERE Id = @Id", new { Id = id, Title = title });
            }
        }

        // Delete------------------------------------------------------------------------------
        public void Delete(int id) 
        {
            using (var conn = dbConnection)
            {
                conn.Open();
                conn.Execute("DELETE FROM ToDoItem WHERE Id = @id", new { id });  //<-- Anonymes Object
            }
        }

        // GetAll methode (Item List)-----------------------------------------------------------
        public void Read() { }
        public IEnumerable<ToDoItem> GetAll()
        {
            using (var conn = dbConnection)
            {
                dbConnection.Open(); // Kaufmann fragen: Wenn dbConnection steht wird eine neue Instanz(/Objekt) erstellt? conn ist die Variable für die geöffnete Instaz? 
                var result = dbConnection.Query<ToDoItem>("SELECT * FROM ToDoItem");
                return result;
            }
        }

        //SetStatusTask methoden ()
        public void UpdateDone(int id, bool isDone)
        {
            using (var conn = dbConnection)
            {
                conn.Open();
                conn.Execute("UPDATE ToDoItem SET IsDone = @IsDone Where Id = @id", new {Id = id, IsDone = isDone }); //isDone Variable weil um auch false setzen zu können, un dnicht nur true
            }
        }
       



    }
}