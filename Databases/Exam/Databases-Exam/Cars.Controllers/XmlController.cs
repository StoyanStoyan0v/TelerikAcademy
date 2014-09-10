namespace Cars.Controllers
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    using Cars.Models;

    public class XmlController
    {
        public void CreateReports(string filePath)
        {
            var sqlController = new SQLController();
            var document = XDocument.Load(filePath);
            var queries = document.Descendants("Query");
            
            foreach (var query in queries)
            {
                var cars = sqlController.GetCars();
                var exportingFile = (string)query.Attribute("OutputFileName");
                var orderBy = (string)query.Element("OrderBy");
                var whereClauses = query.Elements("WhereClauses").Elements("WhereClause");
                
                foreach (var whereClause in whereClauses)
                {
                    var property = (string)whereClause.Attribute("PropertyName");
                    var type = (string)whereClause.Attribute("Type");
                    var condition = (string)whereClause;
                    int number;
                    
                    if (int.TryParse(condition, out number))
                    {
                        cars = this.Filter(cars, property, type, number);
                    }
                    else
                    {
                        cars = this.FilterBy(cars, property, type, condition);
                    }
                }

                cars = this.SortBy(cars, orderBy);
                this.ExportReports(cars, exportingFile);
            }
        }

        private void ExportReports(IQueryable<Car> cars, string filePath)
        {
            var sqlController = new SQLController();
            var result = new XElement("Cars");

            foreach (var car in cars.ToList())
            {
                var xmlCar = new XElement("Car");
                xmlCar.SetAttributeValue("Manufacturer", car.Manufacturer.Name);
                xmlCar.SetAttributeValue("Model", car.Model);
                xmlCar.SetAttributeValue("Year", car.Year);
                xmlCar.SetAttributeValue("Price", car.Price);
                var xmlTransmission = new XElement("TransmissionType",car.TransmissionType);
                xmlCar.Add(xmlTransmission);
                var dealer = new XElement("Dealer");
                dealer.SetAttributeValue("Name", car.Dealer.Name);
                var xmlCities = new XElement("Cities");
                var cities = sqlController.GetCities().Where(c => c.Dealers.Any(d => d.Name == car.Dealer.Name));
                foreach (var city in cities)
                {
                    var xmlCity = new XElement("City", city.Name);
                    xmlCities.Add(xmlCity);
                }
                dealer.Add(xmlCities);
                xmlCar.Add(dealer);
                result.Add(xmlCar);
            }

            result.Save(string.Format("{0}{1}", @"../../XMLReports/", filePath));
        }

        private IQueryable<Car> SortBy(IQueryable<Car> cars, string type)
        {
            switch (type)
            {
                case "Id":
                    cars = cars.OrderBy(c => c.Id);
                    break;
                case "Year":
                    cars = cars.OrderBy(c => c.Year);
                    break;
                case "Model":
                    cars = cars.OrderBy(c => c.Model);
                    break;
                case "Price":
                    cars = cars.OrderBy(c => c.Price);
                    break;
                case "Manufacturer":
                    cars = cars.OrderBy(c => c.Manufacturer.Name);
                    break;
                case "Dealer":
                    cars = cars.OrderBy(c => c.Dealer.Name);
                    break;
            }
            return cars;
        }

        private IQueryable<Car> Filter(IQueryable<Car> cars, string property, string type, int condition)
        {
            switch (property)
            {
                case "Id":
                    switch (type)
                    {
                        case "Equals":
                            cars = cars.Where(c => c.Id == condition);
                            break;
                        case "GreaterThan":
                            cars = cars.Where(c => c.Id > condition);
                            break;
                        case "LessThan":
                            cars = cars.Where(c => c.Id < condition);
                            break;
                        default:
                            break;
                    }
                    break;
                case "Year":
                    switch (type)
                    {
                        case "Equals":
                            cars = cars.Where(c => c.Year == condition);
                            break;
                        case "GreaterThan":
                            cars = cars.Where(c => c.Year > condition);
                            break;
                        case "LessThan":
                            cars = cars.Where(c => c.Year < condition);
                            break;
                        default:
                            break;
                    }
                    break;
                case "Price":
                    switch (type)
                    {
                        case "Equals":
                            cars = cars.Where(c => c.Price == condition);
                            break;
                        case "GreaterThan":
                            cars = cars.Where(c => c.Price > condition);
                            break;
                        case "LessThan":
                            cars = cars.Where(c => c.Price < condition);
                            break;
                        default:
                            break;
                    }
                    break;
            }
            return cars;
        }

        private IQueryable<Car> FilterBy(IQueryable<Car> cars, string property, string type, string condition)
        {
            switch (property)
            {
                case "Model":
                    switch (type)
                    {
                        case "Equals":
                            cars = cars.Where(c => c.Model == condition);
                            break;
                        case "Contains":
                            cars = cars.Where(c => c.Model.Contains(condition));
                            break;
                        default:
                            break;
                    }
                    break;
                case "Manifacturer":
                    switch (type)
                    {
                        case "Equals":
                            cars = cars.Where(c => c.Manufacturer.Name == condition);
                            break;
                        case "Contains":
                            cars = cars.Where(c => c.Manufacturer.Name.Contains(condition));
                            break;
                        default:
                            break;
                    }
                    break;
                case "Dealer":
                    switch (type)
                    {
                        case "Equals":
                            cars = cars.Where(c => c.Dealer.Name == condition);
                            break;
                        case "Contains":
                            cars = cars.Where(c => c.Dealer.Name.Contains(condition));
                            break;
                        default:
                            break;
                    }
                    break;
                case "City":
                    switch (type)
                    {
                        case "Equals":
                            cars = cars.Where(c => c.Dealer.City.Name == condition);
                            break;
                    }
                    break;
            }
            return cars;
        }
    }
}