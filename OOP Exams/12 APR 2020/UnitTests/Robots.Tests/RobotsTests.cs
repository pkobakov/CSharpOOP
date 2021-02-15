namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        [Test]

        public void RobotContructorShouldBeinitializedProperly() 
        {
            //arrange
            Robot robot = new Robot("R2D2", 350);

            //act
            string expectedName = "R2D2";
            string actualName = robot.Name;

            int expectedMaximumBattery = 350;
            int actualMaximumBattery = robot.MaximumBattery;

            int expectedBattery = 350;
            int actualBattery = robot.Battery;



            //assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedMaximumBattery, actualMaximumBattery);
            Assert.AreEqual(expectedBattery, actualBattery);
        
        }

        [Test]

        public void TheRobotManagerShouldBeInitializedCorrectly() 
        {
            RobotManager robotManager = new RobotManager(4);

            //act
            int expectedCapacity = 4;
            int actualCapacity = robotManager.Capacity;

            //assert
            Assert.AreEqual(expectedCapacity, actualCapacity);
        
        }

        [Test]

        public void TheCapacityShouldThrowExceptionIfBelowZero() 
        {

            Assert.Throws<ArgumentException>(()=>new RobotManager(-1));
        
        }

        [Test]

        public void TheCountShouldBeSetProperly() 
        {

            RobotManager robotManager = new RobotManager(1);
            int expected = 0;
            int actual = robotManager.Count;

            //assert
            Assert.AreEqual(expected, actual);
        
        }

        [Test]
        public void TestingTheAddMethod() 
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot = new Robot("R2D2", 55);
            Robot robot2 = new Robot("R2D2", 56);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot2));
        }

        [Test]

        public void TestDoesTheCapacityThrowsExceptionWhenNotEnough() 
        {

            RobotManager robotManager = new RobotManager(0);
            Robot robot = new Robot("R2D2", 55);
            
            Assert.Throws<InvalidOperationException>(()=>robotManager.Add(robot));
        }

        [Test]

        public void ForRemoveMethodRobotShouldExistInRobots()
        {
            RobotManager robotManager = new RobotManager(3);
            Robot robot = new Robot("R2D2", 55);
            Robot robot2 = new Robot("Tripio", 65);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(()=>robotManager.Remove(robot2.Name));
        
        }

        [Test]

        public void RemoveShouldWorkProperlyIfRobotExists() 
        {
            //arrange
            RobotManager robotManager = new RobotManager(3);
            Robot robot = new Robot("R2D2", 55);
            Robot robot2 = new Robot("Tripio", 65);

            //act
            robotManager.Add(robot);
            robotManager.Add(robot2);

            string name = "Tripio";

            robotManager.Remove(name);
            int expected = 1;
            int actual = robotManager.Count;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void ForWorkMethodRobotShouldExistInRobots()
        {
            //arrange
            RobotManager robotManager = new RobotManager(3);
            Robot robot = new Robot("R2D2", 55);
            Robot robot2 = new Robot("Tripio", 65);
            //act
            robotManager.Add(robot);

            //assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Work(robot2.Name,"work", 8));

        }

        [Test]

        public void RobotBatteryCannotBeBelowTheBattteryUsage() 
        {
            //arrange
            RobotManager robotManager = new RobotManager(3);
            Robot robot = new Robot("R2D2", 55);

            //act
            robotManager.Add(robot);

            //assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Work(robot.Name, "work", 65));
        }

        [Test]

        public void WorkMethodShpuldReduceRobotBattery() 
        {
            //arrange
            RobotManager robotManager = new RobotManager(3);
            Robot robot = new Robot("R2D2", 55);

            //act
            robotManager.Add(robot);
            robotManager.Work(robot.Name, "work", 45);

            int expexted = 10;
            int actual = robot.Battery;

            //assert
            Assert.AreEqual(expexted,actual);

        }

        [Test]

        public void ForChargeMethodRobotShouldExistInRobots()
        {
            //arrange
            RobotManager robotManager = new RobotManager(3);
            Robot robot = new Robot("R2D2", 55);
            Robot robot2 = new Robot("Tripio", 65);
            //act
            robotManager.Add(robot);

            //assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge(robot2.Name));

        }

        [Test]

        public void ChargeMethodShpuldSetRobotBatteryToMaximumBattery()
        {
            //arrange
            RobotManager robotManager = new RobotManager(3);
            Robot robot = new Robot("R2D2", 55);

            //act
            robotManager.Add(robot);
            robotManager.Work(robot.Name, "work", 10);
            robotManager.Charge(robot.Name);

            int expexted = 55;
            int actual = robot.MaximumBattery;

            //assert
            Assert.AreEqual(expexted, actual);

        }


    }
}
