using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Examples.day1.Employee_SRP
{
    internal class Employee_ex
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }

        public decimal CalculateYearlySalary()
        {
            return Salary * 12;
        }
        public void GenerateReport(string reportType)
        {
            //Code to generate report based on reportType
        }
        public void SendNotification(string recipient, string message)
        {
            // Code to send email notification
        }

    }
}
