// Program Name:    Payroll Calculation

// Author:          Anant Agarwal

// Date:            29 Mar 20

// Description:     Assignment 1
//                      This program will prepare a Pay Slip to be included in a cheque envelope for the employees
//                      of a small business. The Pay Slip will also be used by the accountant to prepare the actual 
//                      pay-cheques, and to record the deductions in a company ledger.
//
//                      This program will promp the user for the following:
//                      1. Name of the Employee (the name to appear on the slip)
//                      2. Number of hours worked by the employee
//                      3. Pay rate per hour $$
//                      4. %tage of gross pay deduction (only in whole numbers) %

// Information provided by the user:
//                      In order to calculate the net pay for an employee, we use following formulae:
//                      1. Gross pay = Number of hours worked * Pau rate per hour
//                      2. Deduction amount = Gross pay * %tage of deduction
//                      3. Net pay = Gross pay - Deduction amount

// Final output of the application:
//                      After the calculation is completed, we will display the following information:
//                      1. Employee name
//                      2. Number of hours worked
//                      3. Pay rate per hour $$
//                      4. Gross pay $$
//                      5. Deduction amount $$
//                      6. Net pay $$

//                      There were no compilation errors in the program

//  Assumption:         Employee's pay rate remain constant for the entire pay period.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_calculation_with_Methods
{
    class Program
    {
        // We have defined a "getValue" function to prompt employee for information and store the replies.
        // This function will run a "do-while" loop to ensure that employee does not enter any non-numeric 
        // entries exceot for name.
        // In case any non-numeric entries are made, program will respond with an error message and ask to re-enter.
        // This function will also run "if-else" loop to check for any negative or zero entries and will response the 
        // employee to re-enter the correct values.
        // After data cleasing, function will return "userValue" to Main function
        static double getValue(string prompt, string error)
        {
            double userValue; // variable to hold the employee's responses
            bool haveGoodValue = false; //variable defined to check for non-numeric values

            do
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out userValue))
                {
                    if (userValue <= 0)
                    {
                        Console.WriteLine(error);
                    }
                    else
                    {
                        haveGoodValue = true;
                    }
                }

                else
                {
                    Console.WriteLine("You have entered a non numeric value. Please re-enter.");
                }
            } while (!haveGoodValue);

            return userValue; //returning employee's response after validation
        }

        static void Main(string[] args)
        {
            //declating the variables
            string name;                    // variavle to hold the employee's name
            double hours;                   // variable to hold number of hours worked by the employee
            double payRate;                 // variable to hold the employee's pay rate per hour
            double deductionPercentage;     // variable to hold the employee's deductions in gross pay in %tage
            double grossPay;                // variable to store gross pay $$ calculated
            double deductionAmount;         //variable to store deduction amount $$ calculated             
            double netPay;                  //variable to store net pay $$ after deduction from gross pay 

            // We are calling the "getValue" function which will prompt the employee for information and storing
            // the information in the variables.
            // We have also run a "do-while" loop to ensure "deduction percentage" value entered by the employee
            // is a whole number. If not, the program will prompt an error message and ask to re-enter.
            
            Console.Write("Enter the Employee name: ");
            name = Console.ReadLine(); 
            hours = getValue("Enter the number of hours worked. <Decimal hours allowed>: ", "***Error: Number of hours must be positive. Please re-renter");
            payRate = getValue("Enter the hourly wage: $", "***Error: Hourly wage must be positive. Please re-renter");
            
            do
            {
                deductionPercentage = getValue("Enter deduction percentage. <Whole percentage only>: ", "**Error: *Deduction percentage must be positive. Please re-renter");
                if(deductionPercentage % 1 != 0)
                {
                    Console.WriteLine($"***Error: Deduction percentage cannot have decimals. Please re-enter");
                    deductionPercentage = getValue("Enter deduction percentage. <Whole percentage only>: ", "***Error: Deduction percentage must be positive. Please re-renter");
                }
            } while (deductionPercentage % 1 != 0);
           
            // Based on the formulae provided by the user, we are calculating gross pay, deduction amount and net pay
            grossPay = hours * payRate;
            deductionAmount = grossPay * (deductionPercentage / 100);
            netPay = grossPay - deductionAmount;

            //Final output provided to the employee with all the required information
            Console.WriteLine($"\n\n\n            Name : {name}");
            Console.WriteLine($"Hours worked: {hours:f2} at ${payRate:n2} per hour.\n");
            Console.WriteLine($"            Gross Pay:      ${grossPay:n2}");
            Console.WriteLine($"           Deductions:     -${deductionAmount:n2}");
            Console.WriteLine($"                        ---------------");
            Console.WriteLine($"              Net Pay:      ${netPay:n2} \n");
            
            //Comment before exiting the program
            Console.WriteLine("Thank you, have a good day. \n");
        }
    }
}
