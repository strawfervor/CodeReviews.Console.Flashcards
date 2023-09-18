using System.Data.SqlClient;

namespace Flashcards
{
    class Program
    {
        public static void Main(string[] args)
        {
            DatabaseOperations dbos = new DatabaseOperations();
            dbos.NewQuery("INSERT INTO test1 VALUES(1, 'chicken soup', 12.20)");
        }
    }
}