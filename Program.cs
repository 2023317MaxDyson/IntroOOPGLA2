using System;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Assignment2MaxDyson
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public string Ssn { get; set; }
        public double BaseSalary { get; set; }

        // two-argument constructor
        public Employee(string name, string ssn)
        {
            Name = name;
            Ssn = ssn;
            BaseSalary = 0;
        }

        //Virtual Method Default Behavior: update the salary
        public virtual void UpdateSalary(double percent)
        {
            BaseSalary = BaseSalary + BaseSalary * percent;

        }

        //Overriding Object Class ToString() method...
        public override string ToString()
        {
            return Name + "\nSocial security number: " + Ssn;

        }

        // abstract method will be overridden by inherited subclasses        
        public abstract double earnings();
        // no implementation is allowed here, derived calss must override this method!
    }


    public class SalariedEmployee : Employee
    {
        // three-argument constructor
        public SalariedEmployee(string name, string ssn, double salary) : base(name, ssn)
        {
            BaseSalary = salary; // Set weekly salary
        }

        //Must Override base class method                                                           
        public override double earnings()
        {
            return BaseSalary;
        }

        //Overriding BaseClass ToString Method                                                    
        public override string ToString()
        {
            string s = "Salaried employee: " + base.ToString() + "\nWeekly salary " + string.Format("${0:0.00}", BaseSalary) + string.Format("\nEarnings ${0:0.00}", earnings()) + "\n";
            return s;
        }

    }




    //define and Create 'HourlyEmployee' class 
    //{
    //To do
    // define property for 'wage', 'hours', and overtimeRate
    // define constructor method by matching the total parameters from the main method object instance creation statement  
    // Override the base class earnings method and implement earnings for HourlyEmployee class   
    // Override ToString() method.                                                                                                   
    //}
    public class HourlyEmployee : Employee
    {
        //ToDo

        //wage 

        public double wage;

        // hours 

        public Int32 hours;

        //overtimeRate

        public double overtimeRate;


        // five-argument constructor


        // Name, SSN, Wage, OvertimeRate, HoursWorked


        public HourlyEmployee (string name, string ssn, double _wage, double _overtimeRate, Int32 HoursWorked) : base(name, ssn)
        {
            wage = _wage;
            overtimeRate = _overtimeRate;
            hours = HoursWorked;
         

        }


        /* Employees are paid by the number of hours they work.They also receive 
         * overtime pay for working over 40 hours.i.e. 
         * if an hourly employee works 50 hours in a week, the 
         * first 40 hours would be paid by regular payment, remaining (50-40) 10 hours will be 
         * overtime payment that is 1.5 times the regular pay rate.
        */



        // Overriding BaseClass earnings Method 

        public override double earnings()
        {
            //  Total Earnings: 921.25


            // wage = 16.75, overtimeRate = 1.5, hours = 50


            double regularPayment = wage * (hours - 10);

            double regularpayRate = wage * (hours - 40);

           double overtimePayment = overtimeRate * regularpayRate;

           double Earnings =  regularPayment + overtimePayment;
            
            return Earnings ;
        }

        // Overriding BaseClass ToString Method 
        public override string ToString()
        {
          
            /* Hourly employee: Stuart Russell
              * Social security number: 111 - 22 - 4444
              * Hourly Salary $16.75, Hours Worked 50
              *  Earnings $921.25 */

            string s = "Hourly employee: " + base.ToString() + "\nHourly salary " + string.Format("${0:0.00}", wage) + ", " + "Hours Worked " +  hours + string.Format("\nEarnings ${0:0.00}", earnings()) + "\n"; ;
            return s;
        }


    }

    //define and Create 'CommissionEmployee' class 
    //{
    //To do
    // define property for 'GrossSales' and 'CommitionRate'
    // define constructor method by matching the total parameters from the main method object instance creation statement  
    // Override the base class earnings method and implement earnings for CommissionEmployee class
    // Override ToString() method.
    //}
    public class CommissionEmployee : Employee
    {
        //ToDo

        // CommissionRate

        public double CommissionRate;

        // GrossSales 

        public Int32 GrossSales;


        // four-argument constructor

        //Name, SSN, TotalSales, CommissionRate
        public CommissionEmployee(string name, string ssn, Int32 grosssales, double commissionrate ) : base(name, ssn)
        {
            CommissionRate = commissionrate;
            GrossSales = grosssales;


        }

        /*Commission employees are paid a percentage of their total sales.*/


        // Overriding BaseClass earnings Method 

        public override double earnings()
        {
                       
            // 10000 x 0.06 = $600

            return  CommissionRate * GrossSales;
        }

        // Overriding BaseClass ToString Method 
        public override string ToString()
        {
            string s =  "Commmission Employee: " + base.ToString() + "\nGross Sales " + string.Format("${0:0}", GrossSales) + ", " + "Commission Rate " + string.Format("{0}%",  CommissionRate)   + string.Format("\nEarnings ${0:0}", earnings()) + "\n";
            return s;
        }

    }

    //define and Create 'BasePlusCommissionEmployee' class 
    //{
    //To do
    // define constructor method by matching the total parameters from the main method object instance creation statement  
    // Override the base class earnings method and implement earnings for BasePlusCommissionEmployee class 
    // Override the UpdateSalary method if required.
    // Override ToString() method.                                          
    //}
    public class BasePlusCommissionEmployee : CommissionEmployee
    {
        //ToDo


        // Five-argument constructor
        //Name, SSN, TotalSales, CommissionRate, BaseSalary
        public BasePlusCommissionEmployee (string name, string ssn, Int32 totalsales, double commissionrate, Int32 salary) : base(name, ssn, totalsales, commissionrate)

        {
            BaseSalary = salary;
        }


        // This group receives a base salary, additionally they also receive a percentage of their total sales.
        // Assume, further that, the management has decided to increase Base-Plus-Commission-Employee’s basic pay by 
        //  30% of their base salary.  Their commission rate is also updated (Look inside the starter code for the amount). 



        // Overriding BaseClass earnings Method 
        public override double earnings()
        {

            //Earnings $500
             
            return (CommissionRate * GrossSales) + BaseSalary;
        }


        // Override the UpdateSalary method if required.
        public override void UpdateSalary(double percent)
        {
            // percent = 30
            // convert 30 to 0.30 = percent 

      BaseSalary = BaseSalary + (BaseSalary * (percent / 100));


        }

        // Overriding BaseClass ToString Method 

        public override string ToString()
        {

           //  Base Plus Commission Employee: David Whatmore
            //Social security number: 777 - 77 - 7777
          //Gross Sales $5000, Commission Rate 0.04 %, Base Salary $300
          //Earnings $500 

            string s = "Base Plus Commission Employee: " + Name + "\nSocial security number: " + Ssn + "\nGross Sales " + string.Format("${0:0}", GrossSales) + ", " + "Commission Rate " + string.Format("{0}%", CommissionRate) + ", " + "Base Salary " + string.Format("${0:0}", BaseSalary) + string.Format("\nEarnings ${0:0}", earnings()) + "\n";
            return s; 
        }


       
    }


    class Program
    {
        static void Main(string[] args)
        {
            /*
             Please do not change the content of the main method.
             */

            //Create subclass objects
            SalariedEmployee salariedEmployee = new SalariedEmployee("Mahbub Murshed", "111-22-3333", 800.00); //Name, SSN, BaseSalary
            HourlyEmployee hourlyEmployee = new HourlyEmployee("Stuart Russell", "111-22-4444", 16.75, 1.5, 50); ////Name, SSN, Wage, OvertimeRate, HoursWorked
            CommissionEmployee commissionEmployee = new CommissionEmployee("Susan Harper", "444-44-4444", 10000, .06); //Name, SSN, TotalSales, CommissionRate
            BasePlusCommissionEmployee basePlusCommissionEmployee = new BasePlusCommissionEmployee("David Whatmore", "777-77-7777", 5000, .04, 300); //Name, SSN, TotalSales, CommissionRate, BaseSalary

            //Create an Employee array of base type
            var employees = new Employee[4];
            //Initialize array with different Employees
            employees[0] = salariedEmployee;
            employees[1] = hourlyEmployee;
            employees[2] = commissionEmployee;
            employees[3] = basePlusCommissionEmployee;

            Console.WriteLine("Weekly salary of all employees in the collection:\n");

            //Process every element in the array
            foreach (var currentEmployee in employees)
            {
                Console.WriteLine(currentEmployee); // invokes tostring    
            }

            double percentageIncrease = 30;
            double newCommissionRate = 0.05;
            //Update Salary for BasePlusCommissionEmployee
            //Find BasePlusCommissionEmployee types
            foreach (var currentEmployee in employees)
            {
                // Check if employee is a BasePlusCommissionEmployee
                if (currentEmployee is BasePlusCommissionEmployee)
                {
                    currentEmployee.UpdateSalary(percentageIncrease); //30% base salary update
                    Console.WriteLine("Base Plus Commission Employee:\nThe new base salary with a {0}% increase is: ${1}", percentageIncrease, currentEmployee.BaseSalary);

                    //Downcast Employee reference to BasePlusCommissionEmployee reference
                    //Downcast is required to access the "CommissionRate" property.
                    BasePlusCommissionEmployee employee = (BasePlusCommissionEmployee)currentEmployee;
                    employee.CommissionRate = newCommissionRate; //New Commission Rate;
                    Console.WriteLine("The new commission rate is: " + employee.CommissionRate + "%");

                } // end if  
            } // end for
            Console.WriteLine();
            //Process every element in the array
            foreach (var currentEmployee in employees)
            {
                Console.WriteLine("Employee {0} is {1}", currentEmployee.Name, currentEmployee.GetType().Name);
                Console.WriteLine("Total Earnings: " + currentEmployee.earnings());
            }
        }
    }
}


/*
  
If Executed Correctly, Your program will show the following output:

Weekly salary of all employees in the collection:

Salaried employee: Mahbub Murshed
Social security number: 111-22-3333
Weekly salary $800.00
Earnings $800.00

Hourly employee: Stuart Russell
Social security number: 111-22-4444
Hourly Salary $16.75, Hours Worked 50
Earnings $921.25

Commission Employee: Susan Harper
Social security number: 444-44-4444
Gross Sales $10000, Commission Rate 0.06%
Earnings $600

Base Plus Commission Employee: David Whatmore
Social security number: 777-77-7777
Gross Sales $5000, Commission Rate 0.04%, Base Salary $300
Earnings $500

Base Plus Commission Employee:
The new base salary with a 30% increase is: $390
The new commission rate is: 0.05%

Employee Mahbub Murshed is SalariedEmployee
Total Earnings: 800
Employee Stuart Russell is HourlyEmployee
Total Earnings: 921.25
Employee Susan Harper is CommissionEmployee
Total Earnings: 600
Employee David Whatmore is BasePlusCommissionEmployee
Total Earnings: 640


 */
