namespace BookmarksSite.ConsoleClient
{
    using BookmarkingSite.Controllers;

    internal class ConsoleClient
    {
        private static void Main(string[] args)
        {
            var xmlCOntroller = new XMLController();
            //xmlImporter.ImportDataFromXml(@"../../bookmarks.xml");
            xmlCOntroller.ExecuteSimpleQueryFromXml(@"../../simple-query.xml", new ConsoleLogger());
        }
    }
}