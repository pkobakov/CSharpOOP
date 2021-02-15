using NUnit.Framework;
using System;
namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TheComputerConstuctorShouldBeInitializedCorrectly()
        {
            //this.Manufacturer = manufacturer;
            //this.Model = model;
            //this.Price = price;

            Computer computer = new Computer("Lenovo", "ThinkPad", 1200);
            string expectedManufacturer = "Lenovo";
            string actualManufacturer = computer.Manufacturer;

            string expectedModel = "ThinkPad";
            string actualModel = computer.Model;

            decimal expectedPrice = 1200;
            decimal actualPrice = computer.Price;


            Assert.AreEqual(expectedManufacturer, actualManufacturer);
            Assert.AreEqual(expectedModel, actualModel);
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]

        public void TheComputerManagerCounterShouldStartFromZero() 
        {
            ComputerManager computerManager = new ComputerManager();

            int expectedCount = 0;
            int actualCount = computerManager.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]

        public void TheComputerManagerCountShouldIncreaseCorrectly() 
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("Lenovo", "ThinkPad", 1200);

            computerManager.AddComputer(computer);

            int expectedCount = 1;
            int actualCount = computerManager.Count;

            Assert.AreEqual(expectedCount, actualCount);
            Assert.That(computerManager.Computers, Has.Member(computer));
        }

        [Test]

        public void IfTheComputerExistsExceptioShouldBeThrown() 
        {

            Computer firstComp = new Computer("Acer", "One", 500);
            Computer secondComp = new Computer("Acer", "One", 500);
            ComputerManager computerManager = new ComputerManager();

            computerManager.AddComputer(firstComp);

            Assert.Throws<ArgumentException>(()=>computerManager.AddComputer(secondComp), "This computer already exists.");
        }

        [Test]

        public void AddedComputerShouldNotBeNull() 
        {
            ComputerManager computerManager = new ComputerManager();
            Assert.Throws<ArgumentNullException>(()=>computerManager.AddComputer(null),"Can not be null!");
        }

        [Test]

        public void TheRemoveCommandShouldWorkCorrectly() 
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("Lenovo", "ThinkPad", 1200);

            computerManager.AddComputer(computer);
            computerManager.RemoveComputer("Lenovo", "ThinkPad");

            int expectedCount = 0;
            int actualCount = computerManager.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]

        public void RemoveShoudThrowExceptionMessageIfComputerISInvalid() 
        {
            ComputerManager computerManager = new ComputerManager();
            Assert.Throws<ArgumentException>(() => computerManager.RemoveComputer("Mac", "MacBook"), "There is no computer with this manufacturer and model.");

        }

        [Test]

        public void GetComputerShouldWorkCorrectly() 
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("Lenovo", "ThinkPad", 1200);

            computerManager.AddComputer(computer);
            var actual = computerManager.GetComputer("Lenovo", "ThinkPad");

            Assert.AreEqual(computer, actual);

        }

        [Test]

        public void GetComputerByManufacturerShouldWorkCorrectly()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer1 = new Computer("Lenovo", "ThinkPad", 1200);
            Computer computer2 = new Computer("Lenovo", "IdeaPad", 1500);
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);

            var collection = computerManager.GetComputersByManufacturer("Lenovo");

            Assert.IsTrue(collection.Count == 2);
        }

        [Test]

        public void TheValidateNullManufacturerValueShuldWorkCorrectly()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer(null, "FROG", 3400);
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(()=>computerManager.GetComputer(null, "FROG"), "Manufacturer can not be null");
        }

        [Test]
        public void TheValidateNullModelValueShuldWorkCorrectly()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("Asus", "FROG", 3400);
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("Asus", null), "Model can not be null");
        }

    }
}