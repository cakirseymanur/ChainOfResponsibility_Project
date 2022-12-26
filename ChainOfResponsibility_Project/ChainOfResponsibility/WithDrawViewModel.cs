using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponsibility_Project.ChainOfResponsibility
{
    public class WithDrawViewModel
    {
        public int BankProcessID { get; set; }
        public int Amount { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public string Description { get; set; }
    }
}
