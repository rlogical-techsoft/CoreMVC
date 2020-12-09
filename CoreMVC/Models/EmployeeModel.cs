using CoreMVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Models
{
    public class EmployeeModel : IEmployee
    {
        public int Id { get; set; }
        public string Employee_Name { get; set; }
        public List<string> Employees { get; set; }
    }

}
