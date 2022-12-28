using System;
using System.Collections.Generic;
using System.Linq;


/* The Strategy pattern is a way to switch "strategies", swapping functionality when you want
 * to employ a different behaviour. This is similar to the State pattern, however, you might 
 * choose to use the Strategy pattern whenever it doesn't make sense to have an object hold a "state."
 * For example, below we use a strategy to switch behaviours for sorting a list<>
 */
namespace StrategyEmployeeSort
{
    class Program
    {
        static void Main()
        {
            // Two contexts following different strategies
            EmployeeList employees = new EmployeeList();

            employees.Add(new Employee("Bill", 55000));
            employees.Add(new Employee("Angela", 42000));
            employees.Add(new Employee("Steve", 39000));
            employees.Add(new Employee("Jim", 48000));

            employees.SetSortStrategy(new SortBySalary());
            employees.Sort();
        }
    }

    class Employee
    {
        public Employee(string Name, double Salary)
        {
            incrementID++;

            this.ID = incrementID;
            this.Name = Name;
            this.Salary = Salary;
        }

        private static int incrementID;

        public int ID;
        public string Name;
        public double Salary;
    }


    /* Subject */

    class EmployeeList
    {
        private List<Employee> list;
        private SortStrategy sortstrategy;

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this.sortstrategy = sortstrategy;
        }

        public void Add(Employee employee)
        {
            if (list == null)
                list = new List<Employee>();

            list.Add(employee);
        }

        public void Sort()
        {
            sortstrategy.Sort(list);
        }
    }


    /* Strategies */

    abstract class SortStrategy
    {
        public virtual void Sort(List<Employee> list)
        {
            if (list != null)
                foreach (Employee emp in list)
                    Console.WriteLine("ID: {0} - Name: {1} - Salary: {2}",
                        emp.ID,
                        emp.Name,
                        emp.Salary
                    );
        }
    }

    class SortById : SortStrategy
    {
        public override void Sort(List<Employee> list)
        {
            ////RAW METHOD FOR SORTING BY HIGHEST NUM
            //List<Employee> newList = new List<Employee>();

            //int highestNum = 0;
            //Employee e = new Employee("empty", 0);

            //while (list.Count != 0)
            //{
            //    foreach (Employee emp in list)
            //    {
            //        if (emp.ID > highestNum)
            //        {
            //            highestNum = emp.ID;
            //            e = emp;
            //        }
            //    }

            //    newList.Add(e);
            //    list.Remove(e);
            //    highestNum = 0;
            //}

            list = list.OrderByDescending(emp => emp.ID).ToList();
            base.Sort(list);
        }
    }

    class SortByName : SortStrategy
    {
        public override void Sort(List<Employee> list)
        {
            list = list.OrderBy(emp => emp.Name).ToList();
            base.Sort(list);
        }
    }

    class SortBySalary : SortStrategy
    {
        public override void Sort(List<Employee> list)
        {
            list = list.OrderByDescending(emp => emp.Salary).ToList();
            base.Sort(list);
        }
    }
}
