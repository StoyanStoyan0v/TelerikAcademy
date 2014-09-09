namespace Cars.ConsoleClient
{
    using System;
    using System.Linq;

    using Cars.Controllers;

    internal class ConsoleClient
    {
        private static void Main()
        {
            //Takes some time (about 2 minutes on my machine) .. please be patient..
            InsertDataFromJson();
            CreateReports();
        }

        private static void InsertDataFromJson()
        {
            var jsonController = new JsonController(@"../../JSON/data.",5);
            jsonController.InsertDataToSql();
            Console.WriteLine("Cars added successfuly..");
        }

        private static void CreateReports()
        {
            var xmlController = new XmlController();
            xmlController.CreateReports(@"../../Queries.xml");
            Console.WriteLine("XML emports created successfully..");
        }
    }
}