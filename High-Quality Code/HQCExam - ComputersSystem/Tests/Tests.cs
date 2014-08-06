namespace Tests
{
    using System;
    using System.IO;
    using ComputersSystem;
    using ComputersSystem.ComputerFactories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Tests
    {
        private Manufacturer manufacurer;

        [TestInitialize]
        public void Initialize()
        {
            this.manufacurer = new Dell();
        }

        [TestMethod]
        public void TestBatteryCharge()
        {
            var pc = this.manufacurer.IntroduceLaptop();

            pc.Battery.Percentage = 49;
            pc.Battery.Charge(11);
            Assert.AreEqual(pc.Battery.Percentage, 60);

            pc.Battery.Charge(50);
            Assert.AreEqual(pc.Battery.Percentage, 100);

            pc.Battery.Percentage = -1111;
            pc.Battery.Charge(1000);
            Assert.AreEqual(pc.Battery.Percentage, 0);
        }

        [TestMethod]
        public void TestCpuRandom()
        {
            var min = 10;
            var max = 50;
            var pc = this.manufacurer.IntroducePC();
            pc.Cpu.SaveRandomNumberToRam(min, max);
            var number = pc.Memory.LoadValue();
            Assert.IsTrue(min < number && number < max);
        }

        [TestMethod]
        public void TestCpuSquareNumber()
        {
            StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            var pc = this.manufacurer.IntroducePC();
            pc.Cpu.RenderSquareNumber(new ColorfullVideocard());
            var expected = consoleOutput.ToString();
            Assert.AreEqual(expected.Substring(0, expected.Length - 2), "Square of 8 is 64.");
        }
    }
}