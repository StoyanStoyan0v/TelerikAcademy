namespace Cars.Tests.JustMock
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using System.Collections.Generic;
    using Cars.Models;

    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;

        private CarsController controller;

        public CarsControllerTests() : this(new JustMockCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void SearchCarShouldRetunrADetail()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Search("BMW"));
            var firstModel = model.First();
            Assert.AreEqual(2, firstModel.Id);
            Assert.AreEqual("325i", firstModel.Model);
            Assert.AreEqual(2008, firstModel.Year);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortCarByInvalidParameterShouldThrowArgumentException()
        {
            var sortedCollection = this.GetModel(() => this.controller.Sort("blabla"));
        }

        [TestMethod]
        public void SortCarByMakeParameter()
        {
            var sortedCollection = (ICollection<Car>)this.GetModel(() => this.controller.Sort("make"));
            var firstModel = sortedCollection.First();
            Assert.AreEqual(1, firstModel.Id);
            Assert.AreEqual("Audi", firstModel.Make);
            Assert.AreEqual("A4", firstModel.Model);
            Assert.AreEqual(2005, firstModel.Year);
        }

        [TestMethod]
        public void SortCarByYearParameter()
        {
            var sortedCollection = (ICollection<Car>)this.GetModel(() => this.controller.Sort("year"));
            var firstModel = sortedCollection.First();
            Assert.AreEqual(4, firstModel.Id);
            Assert.AreEqual("Opel", firstModel.Make);
            Assert.AreEqual("Astra", firstModel.Model);
            Assert.AreEqual(2010, firstModel.Year);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}