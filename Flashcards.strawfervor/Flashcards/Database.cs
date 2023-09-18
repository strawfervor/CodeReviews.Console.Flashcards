using System.Data.SqlClient;

namespace Flashcards
{
    class DatabaseOperations
    {
        string connectionString = @"Data Source=(local);Integrated Security=True;";

        public DatabaseOperations()//constructor is used to check if table exists and if not to make tables
        {
            string createTable1 = $@"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Stack')
                CREATE TABLE Stack (
                stack_id int NOT NULL IDENTITY PRIMARY KEY,
                name nvarchar(50) NOT NULL)";

            string createTable2 = $@"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Cards')
                CREATE TABLE Cards (
                card_id int NOT NULL IDENTITY PRIMARY KEY,
                front Text NOT NULL,
                back Text NOT NULL,
                stack_id int NOT NULL,
                CONSTRAINT FK_StackCard FOREIGN KEY (stack_id)
                REFERENCES Stack(stack_id)
                ON DELETE CASCADE
                ON UPDATE CASCADE)";

            string createTable3 = $@"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='StudySessions')
                CREATE TABLE StudySessions (
                study_id int NOT NULL IDENTITY PRIMARY KEY,
                date Text NOT NULL,
                score Text NOT NULL,
                stack_id int NOT NULL,
                CONSTRAINT FK_StackStudySession FOREIGN KEY (stack_id)
                REFERENCES Stack(stack_id)
                ON DELETE CASCADE
                ON UPDATE CASCADE)";

            NewQuery(createTable1);
            NewQuery(createTable2);
            NewQuery(createTable3);
        }

        public void NewQuery(string command)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var tableCmd = conn.CreateCommand();

                tableCmd.CommandText = command;

                int rowCount = tableCmd.ExecuteNonQuery();//this is executing command without "output"

                if (rowCount > 0)
                {
                    Console.Write($"Record updated!");
                }

                conn.Close();
            }
        }
    }
}
