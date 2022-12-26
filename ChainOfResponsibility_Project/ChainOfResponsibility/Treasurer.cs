using ChainOfResponsibility_Project.DAL;
using ChainOfResponsibility_Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponsibility_Project.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(WithDrawViewModel p)
        {
            Context context = new Context();
            if (p.Amount <= 40000)
            {
                BankProcess bankProcess = new BankProcess();
                p.EmployeeName = "Veznedar-Ayşenur Yıldız";
                p.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi Vezne Sorumlusu tarafından gerçekleştirildi";
                bankProcess.EmployeeName = p.EmployeeName;
                bankProcess.Description = p.Description;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                BankProcess bankProcess = new BankProcess();
                p.EmployeeName = "Veznedar-Ayşenur Yıldız";
                p.Description = "Müşteri talep etmiş olduğu tutar yetkilinin dahilinde olmadığı için işlem Şube Müdür Yardımcısına gönderildi.";
                bankProcess.EmployeeName = p.EmployeeName;
                bankProcess.Description = p.Description;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(p);

            }
        }
    }
}
