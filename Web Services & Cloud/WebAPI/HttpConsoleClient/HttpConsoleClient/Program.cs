using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;

namespace HttpConsoleClient
{
    class Program
    {
        static WebClient client;
        
        static void Main(string[] args)
        {
            client = new WebClient();
            var songToPost = "{'Title': 'Nice Song', 'Year': '2000','Genre':'Chalga'}";
            var contentType = "application/json";
            UploadData(songToPost, contentType, "song");
            GetData("song");

            var artistToPost = "{'Title': 'Hits of 2000 year', 'Year': '2000','Producer':'Bai Ivan'}";

            UploadData(artistToPost, contentType, "album");
            GetData("album");

            //The others are base on the same methods... no time to write them... sorry 
        }

        static void UploadData(string data, string contentType, string uri)
        {
            client.Headers[HttpRequestHeader.ContentType] = contentType;
            client.UploadString("http://localhost:5846/api/" + uri, data);
        }

        static void GetData(string uri)
        {
            var students = client.DownloadString("http://localhost:5846/api/" + uri);

            Console.WriteLine(students);
        }
    }
}