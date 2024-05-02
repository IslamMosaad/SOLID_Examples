using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Examples.day1.Employee_SRP
{
    internal interface IEmployee
    {
        string Name { get; set; }
        decimal Salary { get; set; }
        string Department { get; set; }
    }
    internal class Employee : IEmployee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }


        #region violate SRP
        //public decimal CalculateYearlySalary()
        //{
        //    return Salary * 12;
        //}
        //public void GenerateReport(string reportType)
        //{
        //    //Code to generate report based on reportType
        //}
        //public void SendNotification(string recipient, string message)
        //{
        //    // Code to send email notification
        //}
        #endregion
    }
    internal class SalaryCalculator
    {
        public decimal CalculateYearlySalary(IEmployee employee)
        {
            return employee.Salary * 12;
        }
    }
    internal class ReportGenerator
    {
        public void GenerateReport(IEmployee employee, string reportType)
        {
            //Code to generate report based on reportType
        }
    }
    internal class NotificationSender
    {
        public void SendNotification(IEmployee employee, string recipient, string message)
        {
            // Code to send email notification
        }
    }

}
