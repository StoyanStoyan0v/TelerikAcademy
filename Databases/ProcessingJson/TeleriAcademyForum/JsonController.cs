namespace TeleriAcademyForum
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    public class JsonController
    {
        private readonly string url;

        private readonly string fileName;

        private readonly JObject jsonObject;

        public JsonController(string url, string fileName)
        {
            this.url = url;
            this.fileName = fileName;
            this.jsonObject = JObject.Parse(this.GetJsonFile());
        }

        public void PrintQuestionsTitles()
        {
            var titles = this.jsonObject["rss"]["channel"]["item"].Select(item => item["title"]);
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }

        public void CreateHtml(string fileName)
        {
            var forumItems = this.ParseJsonToPoco();

            var sb = new StringBuilder();
            
            foreach (var item in forumItems)
            {
                var html = new XDocument();

                var itemInfo = new XElement("div");
                itemInfo.Add(new XElement("br"));
                itemInfo.Add(new XElement("div", string.Format("Question: {0}", item.Title)));
                itemInfo.Add(new XElement("div", string.Format("Category: {0}", item.Category)));
                itemInfo.Add(new XElement("a",new XAttribute("href",item.Link),"Link"));
                html.Add(itemInfo);
                sb.Append(html.ToString());
            }

            File.WriteAllText(fileName, sb.ToString(), Encoding.UTF8);
        }

        private IEnumerable<ForumItem> ParseJsonToPoco()
        {
            var obj = this.jsonObject["rss"]["channel"]["item"];
            return JsonConvert.DeserializeObject<IEnumerable<ForumItem>>(obj.ToString());
        }

        private string GetJsonFile()
        {
            var webController = new WebClient();
            webController.DownloadFile(this.url, this.fileName);
            var doc = new XmlDocument();
            doc.Load(this.fileName);
            string jsonToXml = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            return jsonToXml;
        }
    }
}