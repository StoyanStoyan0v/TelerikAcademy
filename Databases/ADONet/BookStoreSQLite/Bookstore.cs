using DatabaseHandlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreSQLite
{
    class Bookstore
    {
        private static DBHandler dbConnection;
        
        private static void Main()
        {
            string filePath = "..\\..\\bookstore.s3db";
            dbConnection = new SQLiteDbHandler(filePath);

            PrintAllBooks();
           
            GetBookByTitle("Hello");
            GetBookByTitle("Pesho");

            try
            {
                AddBook(5, "Hello", "Somebody", "667-666-666", new DateTime(2010, 7, 14));
                Console.WriteLine("Book added!");
            }
            catch (Exception)
            {
                Console.WriteLine("There is such book in the database already!");
            }
        }

        private static void AddBook(int id, string name, string author, string isbn, DateTime publishDate)
        {
            var keys = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("Id",id),
                new KeyValuePair<string, object>("Title",name),
                new KeyValuePair<string, object>("Author",author),
                new KeyValuePair<string, object>("ISBN",isbn),
                new KeyValuePair<string, object>("PublishDate",publishDate)
            };
            dbConnection.InsertIntoDatabase(keys, "Books");
        }

        private static void GetBookByTitle(string title)
        {
            var result = dbConnection.SelectFromTable(new string[] { "Author", "Title" }, string.Format("Books WHERE Title = '{0}'", title));
            PrintResult(result);
        }
        
        private static void PrintAllBooks()
        {
            var result = dbConnection.SelectFromTable(new string[] { "Author", "Title" }, "Books");
            PrintResult(result);
        }
        
        private static void PrintResult(IDictionary<object, object> result)
        {
            Console.WriteLine(new string('-',30));
            Console.WriteLine(string.Format("Books found:"));
            Console.WriteLine(new string('-',30));
            if (result.Count == 0)
            {
                return;
            }
            foreach (var item in result)
            {
                Console.WriteLine(string.Format("Author: {0}", item.Key));
                Console.WriteLine(string.Format("Book(s): {0}", item.Value));
            }
            Console.WriteLine(new string('-',30));
        }
    }
}