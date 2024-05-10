namespace GLA2OOPMaxDyson
{
    using System;
    using System.Data;
    using System.Data.SqlTypes;
    using System.Reflection.Metadata.Ecma335;

    namespace ConsoleApp1
    {
        class Employee
        {
            //To do
            //Declare your member variables and initialize values (if required) here.

              
            // Employees name
           public string Name { get ; set; }

                       
            // HourlyWage for the employee
            
            public double hourlyWage { get; set; }


            // How many hours the employee has worked 
            public double Hours { get; set; }

            // Unpaid hours 
            public double unpaidHours { get; set; }



            // How much money the employee currently owns
            public double _moneyOwed { get; set; }




            public void SetName(string name)
            {
                //To do
                //Set name to a member variable/field.
               
               Name = name;
               
            }
            public string GetName()
            {
                //To do
                //return the member variable correspond to the name attribute.

                return Name;
            }

            public void SetWage(double rate)
            {
                //To do
                //set wage

                hourlyWage = rate;


            }
            public void Work(double hours)
            {
                //To do

                //Set Hours  

                Hours = hours;

                //Update unpaid hours

                double totalHours = unpaidHours + Hours;

                // Calculate money Owed
                
                // Using an increment for calculating _moneyOwed if the method Work is passed more than once before the console writes the method Pay

                _moneyOwed += totalHours * hourlyWage;


                // David has worked a total of 5 hours
                // Work(5)
                // Employee David is Paid 75 after working =
                // unpaidHours(0) + Hours(5) = totalHours(5) * hourlyWage(15) = moneyOwed(75)



                //Susan has worked a total of 10 hours
                // Work(8)
                // Work(2) 
                // Employee Susan is Paid 300 after working =
                // unpaidHours(0) + Hours(8) = totalHours(8) * hourlyWage(30) = moneyOwed(240)
                // unpaidHours(0) + Hours(2) = totalHours(2) * hourlyWage(30) = moneyOwed(60) 
                // moneyOwed(60+240) = moneyOwed(300)








            }
            public double Pay()
            {
                //To do
                // return moneyOwed and set unpaid hours and moneyOwed to zero

                // Returning moneyOwed as a local variable

                double moneyOwed = _moneyOwed;

               _moneyOwed = 0;
               unpaidHours = 0;


                return moneyOwed;
             
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Employee emp1 = new Employee();
                Employee emp2 = new Employee();

                emp1.SetName("David");
                emp1.SetWage(15);
                emp2.SetName("Susan");
                emp2.SetWage(30);

                var amount = emp1.Pay();
                Console.WriteLine("Employee '{0}' is paid {1} before working...", emp1.GetName(), emp1.Pay());
                Console.WriteLine("Employee '{0}' is paid {1} before working...", emp2.GetName(), emp2.Pay());
                emp1.Work(5);
                emp2.Work(8);
                Console.WriteLine("Employee '{0}' is paid {1} after working...", emp1.GetName(), emp1.Pay());

                emp1.Work(5);
                emp2.Work(2);
                Console.WriteLine("Employee '{0}' is paid {1} after working...", emp1.GetName(), emp1.Pay());
                Console.WriteLine("Employee '{0}' is paid {1} after working...", emp2.GetName(), emp2.Pay());
             
            }
        }
    }

}
