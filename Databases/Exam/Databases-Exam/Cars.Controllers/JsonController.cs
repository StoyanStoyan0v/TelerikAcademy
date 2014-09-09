namespace Cars.Controllers
{
    using System.IO;
    using System.Linq;
    using Cars.Models;
    using Newtonsoft.Json.Linq;

    public class JsonController
    {
        private const string FileExtension = ".json";

        private readonly string filesPath;

        private readonly int filesCount;
      
        public JsonController(string filesPath, int filesCount)
        {
            this.filesPath = filesPath;
            this.filesCount = filesCount;
        }

        public void InsertDataToSql()
        {
            var sqlController = new SQLController();
            for (int i = 0; i < this.filesCount; i++)
            {
                var jsonString = this.ReadJson(string.Format("{0}{1}{2}", this.filesPath, i, FileExtension));
                var jsonObjectArray = JArray.Parse(jsonString);
                foreach (var jsonObject in jsonObjectArray)
                {
                    var madeYear = (int)jsonObject["Year"];

                    var model = (string)jsonObject["Model"];

                    var transmissinType = (TransmissionType)((int)jsonObject["TransmissionType"]);
                
                    var price = (decimal)jsonObject["Price"];

                    var manufacturer = (string)jsonObject["ManufacturerName"];
                    var manufacturerId = sqlController.GetManufacturerId(manufacturer);

                    var dealer = jsonObject["Dealer"];
                    var dealerName = (string)dealer["Name"];
                    var dealerCity = (string)dealer["City"];
                    var dealerId = sqlController.GetDealerId(dealerName, dealerCity);

                    sqlController.InsertCar(model, price, madeYear, transmissinType, manufacturerId, dealerId);
                }
            }
        }
        
        private string ReadJson(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                return json;
            }
        }
    }
}