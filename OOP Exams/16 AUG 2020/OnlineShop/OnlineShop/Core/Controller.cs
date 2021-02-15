using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using OnlineShop.Models.Products.Components;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;
        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {

            if (this.computers.Any(c=>c.Id == id)) //If a computer, with the same id, already exists in the computers collection...
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

             IComputer currentComputer = computerType switch //Creates a computer with the correct type....
            {
                nameof (DesktopComputer) => (IComputer) new DesktopComputer(id, manufacturer, model, price),
                nameof(Laptop) => new Laptop(id, manufacturer, model, price),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComputerType), //If the computer type is invalid

            };

            this.computers.Add(currentComputer); //...and adds it to the collection of computers.
            
            //If it's successful, returns 
            string outputMessage = String.Format(SuccessMessages.AddedComputer, id); 
            return outputMessage;

        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer currentComputer = CreateComp(computerId);

            if (components.Any(c => c.Id == id)) //If a component, with the same id, already exists in the components collection...
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            //Creates a component with the correct type.....

            var currentComponent = componentType switch
            {
                nameof(ComponentType.Motherboard) => (IComponent)new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                nameof(ComponentType.PowerSupply) => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                nameof(ComponentType.CentralProcessingUnit) => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                nameof(ComponentType.RandomAccessMemory) => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                nameof(ComponentType.SolidStateDrive) => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                nameof(ComponentType.VideoCard) => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComponentType) //If the component type is invalid
            };


            currentComputer.AddComponent(currentComponent); //...and adds it to the computer with that id
            components.Add(currentComponent); //then adds it to the collection of components in the controller

            //If it's successful, returns=>

            string outputMessage = String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            return outputMessage;
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
           IComputer currentComputer = CreateComp(computerId);

            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            if (peripherals.Any(c=>c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            var currentPeripheral = peripheralType switch
            { 
            nameof(PeripheralType.Headset)=>(IPeripheral)new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
            nameof(PeripheralType.Keyboard) => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
            nameof(PeripheralType.Monitor) => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
            nameof(PeripheralType.Mouse) => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
            _=> throw new ArgumentException(ExceptionMessages.InvalidPeripheralType)
            };

            
            currentComputer.AddPeripheral(currentPeripheral);
            peripherals.Add(currentPeripheral);

            string outputMessage = String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
            return outputMessage;
        }

        public string BuyBest(decimal budget) //Removes the computer with the highest overall performance...
        {
            
            //and with a price, less or equal to the budget, 
            //from the collection of computers.

            var selectedComputers = computers.OrderByDescending(c => c.OverallPerformance);
            
            //Select the computers from the collection by overallperformance.

            foreach (var  bestComputer in selectedComputers) 
            {
                if (bestComputer.Price <= budget)
                {
                    var computerData = bestComputer.ToString(); //getting data about the first matched (best) comp.
                    computers.Remove(bestComputer);
                    return computerData; //If it's successful, it returns ToString method on the removed computer.
                }
            }

            string exceptionMessage = String.Format(ExceptionMessages.CanNotBuyComputer, budget);
            return exceptionMessage; // if not successful
        }

        public string BuyComputer(int id) //Removes a computer, with the given id, from the collection of computers.
        {
            var computerForSale = computers.FirstOrDefault(c => c.Id == id);

            if (computerForSale == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            computers.Remove(computerForSale);
            return computerForSale.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);

            //If it's successful, it returns ToString method on the computer with the given id.

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var currentComponent = components.FirstOrDefault(c=>c.GetType().Name == componentType); //2...component, with the given type
            var currentComputer = computers.FirstOrDefault(c => c.Id == computerId); //3...from the computer with that id

            if (currentComputer==null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            //1.Removes a .... 

            currentComputer.RemoveComponent(componentType);
            components.Remove(currentComponent);

            string outputMessage = String.Format(SuccessMessages.RemovedComponent, componentType, computerId);
            return outputMessage;
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var currentPeripheral = peripherals.FirstOrDefault(p=>p.GetType().Name == peripheralType);
            var currentComputer = computers.FirstOrDefault(c => c.Id == computerId);

            currentComputer.RemovePeripheral(peripheralType);
            peripherals.Remove(currentPeripheral);

            string outputMessage = String.Format(SuccessMessages.RemovedPeripheral, peripheralType, computerId);
            return outputMessage;
        }

        private IComputer CreateComp(int computerId)
        {
            var currentComputer = computers.FirstOrDefault(c => c.Id == computerId);
            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return currentComputer;
        }
    }
}
