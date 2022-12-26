using ChainOfResponsibility_Project.DAL;
using ChainOfResponsibility_Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponsibility_Project.ChainOfResponsibility
{
    public class RegionalDirector : Employee
    {
        public override void ProcessRequest(WithDrawViewModel p)
        {
            Context context = new Context();
            if (p.Amount <= 250000)
            {
                BankProcess bankProcess = new BankProcess();
                p.EmployeeName = "Bölge Müdürü-Nazlı Siyah";
                p.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi Bölge Müdürü tarafından gerçekleştirildi";
                bankProcess.EmployeeName = p.EmployeeName;
                bankProcess.Description = p.Description;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                BankProcess bankProcess = new BankProcess();
                p.EmployeeName = "Bölge Müdürü-Nazlı Siyah";
                p.Description = "Müşteri talep etmiş olduğu tutar banka limitlerinin günlük çekim tutarının üstünde olduğu için işlem gerçekleştirilemedi.";
                bankProcess.EmployeeName = p.EmployeeName;
                bankProcess.Description = p.Description;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
            }
           
        }
    }
}
