namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TheComputerPartShouldBeInitializedProperly()
        {

            //arrange
            Part part = new Part("Lenovo", 156M);
            //act
            string excpectedName = "Lenovo";
            string actualName = part.Name;

            decimal excpectedPrice = 156M;
            decimal actualPrice = part.Price;
            //act
            Assert.AreEqual(excpectedName, actualName);
            Assert.AreEqual(excpectedPrice, actualPrice);

        }

        [Test]

        public void TheComputerShouldBeInitializedProperly()
        {
            //arrange
            Computer computer = new Computer("Lenovo");

            //act
            string excpectedName = "Lenovo";
            string actualName = computer.Name;

            int excpectedPartsCount = 0;
            int actualPartsCount = computer.Parts.Count;

            //assert
            Assert.AreEqual(excpectedName, actualName);
            Assert.AreEqual(excpectedPartsCount, actualPartsCount);

        }

        [Test]

        public void TheComputerNameThrowsCannotBeEmptyOrWhiteSpaceException() 
        {
            //arrange 
          

            //assert
            Assert.Throws<ArgumentNullException>(()=>new Computer(null));
            Assert.Throws<ArgumentNullException>(() => new Computer(" "));
        }

        [Test]

        public void AddPartShouldWorkfine() 
        {
            //arrange
            Part part = new Part("Chipset", 230M);
            Computer computer = new Computer("Lenovo");

            //act
            computer.AddPart(part);
            int excpected = 1;
            int actual = computer.Parts.Count;

            //assert
            Assert.AreEqual(excpected, actual);

        }

        [Test]

        public void AddPartShouldThrowexceptionIfPartIsEmpty() 
        {

            Computer computer = new Computer("Lenovo");
            Assert.Throws<InvalidOperationException>(()=>computer.AddPart(null));
        }

        [Test]

        public void TotalPartsPriceShouldCalculateCorrectly() 
        {
            Part part1 = new Part("Chipset", 230M);
            Part part2 = new Part("Videocard", 30M);
            Computer computer = new Computer("Lenovo");

            computer.AddPart(part1);
            computer.AddPart(part2);

            decimal expectedSum = 260M;
            decimal actualSum = computer.TotalPrice;

            Assert.AreEqual(expectedSum, actualSum);
        }

        [Test]

        public void RemoveShould() 
        {
            //arrange
            Computer computer = new Computer("Lenovo");
            Part part = new Part("Chipset", 230M);
            computer.AddPart(part);

            //act
            bool excpected = true;
            bool actual = computer.RemovePart(part);

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [Test]

        public void TestingTheGetPartMethod() 
        {
            //arrange
            Part part1 = new Part("Chipset", 230M);
            Part part2 = new Part("Videocard", 30M);
            Computer computer = new Computer("Lenovo");

            computer.AddPart(part1);
            computer.AddPart(part2);

            //act

            Part expected = part2;
            Part actual = computer.GetPart("Videocard");

            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}