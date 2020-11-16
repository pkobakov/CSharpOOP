using System;
using System.Collections.Generic;


namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Employee worker = new Employee("Petkan");
            Manager manager = new Manager("Boss", new List<string> { "CV", "Projects"});
            List<Employee> employeeList = new List<Employee>() { worker, manager};
            DetailsPrinter allEmployees = new DetailsPrinter(employeeList);
            allEmployees.PrintDetails();

        }
    }
}
