using ChainOfResponsibility_Project.DAL;
using ChainOfResponsibility_Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponsibility_Project.ChainOfResponsibility
{
    public class Manager : Employee
    {
        public override void ProcessRequest(WithDrawViewModel p)
        {
            Context context = new Context();
            if (p.Amount <= 150000)
            {
                BankProcess bankProcess = new BankProcess();
                p.EmployeeName = "Şube Müdürü-Hakan Kayalı";
                p.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi Şube Müdürü tarafından gerçekleştirildi";
                bankProcess.EmployeeName = p.EmployeeName;
                bankProcess.Description = p.Description;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                BankProcess bankProcess = new BankProcess();
                p.EmployeeName = "Şube Müdürü-Hakan Kayalı";
                p.Description = "Müşteri talep etmiş olduğu tutar yetkilinin dahilinde olmadığı için işlem Bölge Müdürüne gönderildi.";
                bankProcess.EmployeeName = p.EmployeeName;
                bankProcess.Description = p.Description;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(p);

            }
           
        }
    }
}
