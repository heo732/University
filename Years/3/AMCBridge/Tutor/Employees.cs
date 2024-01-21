using System;
using System.Collections.Generic;

namespace Employees
{
    public class Employees
    {
        public static void Main(string[] args)
        {
            var values = new List<int>();
            foreach (var value in Console.ReadLine().Split(' '))
            {
                values.Add(int.Parse(value));
            }

            var employees = new Dictionary<int, Employee>();
            int index = 0;
            while (values[index] != -1)
            {
                Employee employee = null;
                switch (values[index])
                {
                    case 1:
                        {
                            employee = new Accountant();
                            break;
                        }
                    case 2:
                        {
                            employee = new Seamstress();
                            break;
                        }
                    case 3:
                        {
                            employee = new Seller();
                            break;
                        }
                }
                switch (values[index + 1])
                {
                    case 1:
                        {
                            employee.SalaryType = SalaryType.Hourly;
                            break;
                        }
                    case 2:
                        {
                            employee.SalaryType = SalaryType.Daily;
                            break;
                        }
                }
                employee.SalaryRate = values[index + 2];
                employees.Add(values[index + 3], employee);
                index += 4;
            }
            index++;

            while (values[index] != -1)
            {
                employees[values[index]].HoursWorked += values[index + 1];
                index += 2;
            }

            double sumResult = 0.0;
            foreach (var employee in employees.Values)
            {
                sumResult += employee.Total;
            }

            Console.Write(sumResult.ToString());
        }
    }

    public enum SalaryType
    {
        Hourly,
        Daily
    }

    public abstract class Employee
    {
        public SalaryType SalaryType { get; set; }

        public double SalaryRate { get; set; }

        public double HoursWorked { get; set; }

        public abstract double Bonus { get; }

        public double Salary
        {
            get
            {
                if (SalaryType == SalaryType.Hourly)
                    return HoursWorked * SalaryRate;
                else
                    return Math.Floor(HoursWorked / 8.0) * SalaryRate;
            }
        }        

        public double Total
        {
            get
            {
                return Salary + Bonus;
            }
        }
    }

    public class Accountant : Employee
    {
        public override double Bonus
        {
            get
            {
                return 0.0;
            }
        }
    }

    public class Seamstress : Employee
    {
        public override double Bonus
        {
            get
            {
                return Math.Floor(HoursWorked / 24.0) * 0.01 * Salary;
            }
        }
    }

    public class Seller : Employee
    {
        public override double Bonus
        {
            get
            {
                return Salary * 0.1;
            }
        }
    }
}
