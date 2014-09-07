namespace TeleriAcademyForum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var controller = new JsonController(@"http://forums.academy.telerik.com/feed/qa.rss ", @"../../qa.xml");
            controller.PrintQuestionsTitles();
            controller.CreateHtml(@"../../forum.html");
        }
    }
}