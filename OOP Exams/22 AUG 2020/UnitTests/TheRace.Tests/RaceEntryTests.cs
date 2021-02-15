using NUnit.Framework;
using System;

using TheRace;



namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestTheRaceCounterBeforeStartMustBeZero()
        {
            RaceEntry race = new RaceEntry();
            int expected = 0;
            int actual= race.Counter;

            Assert.AreEqual(expected,actual);
        }

        public void TestIsTheRaceCounterIncreasingWhenTheAddingDataIsCorrect()
        {
            RaceEntry race = new RaceEntry();
            UnitCar car = new UnitCar("Mazda", 220, 3500);
            UnitDriver driver = new UnitDriver("Pepo", car);
            race.AddDriver(driver);
            int expected = 1;
            int actual = race.Counter;

            Assert.AreEqual(expected, actual);


        }
        [Test]

        public void TestWhenTheDriverDataIsNullExceptionWillBeThrown() 
        {
            RaceEntry race = new RaceEntry();
            UnitDriver driver = null;

            Assert.Throws<InvalidOperationException>(()=>race.AddDriver(driver));
        }

        [Test]

        public void TestDoesTheGivenDriverParticipateInTheRace() 
        {
            RaceEntry race = new RaceEntry();
            UnitCar car = new UnitCar("Mazda", 220, 3500);
            UnitDriver driver = new UnitDriver("Pepo", car);
            UnitDriver sameDriver = new UnitDriver("Pepo", car);
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(()=>race.AddDriver(sameDriver), "Driver Pepo is already added");        
        }

        [Test]

        public void ThrowexceptionIfTheParticipantsareLessThanTwo() 
        {
            RaceEntry race = new RaceEntry();
            UnitCar car = new UnitCar("Mazda", 220, 3500);
            UnitDriver driver = new UnitDriver("Pepo", car);

            Assert.Throws<InvalidOperationException>(()=>race.CalculateAverageHorsePower(), "The race cannot start with less than 2 participants");


        }

        [Test]

        public void TestDoesTheAverageHorsePowerCalculatorWorkCorrect() 
        {

            RaceEntry race = new RaceEntry();
            UnitCar firstCar = new UnitCar("Mazda", 220, 3500);
            UnitDriver firstDriver = new UnitDriver("Pepo", firstCar);

            race.AddDriver(firstDriver);

            UnitCar secondCar = new UnitCar("Mazda", 220, 3500);
            UnitDriver secondDriver = new UnitDriver("Sasho", secondCar);

            race.AddDriver(secondDriver);

            double expected = race.CalculateAverageHorsePower();
            double actual = 220;

            Assert.AreEqual(expected, actual);

        }
    }
}
