using ChainOfResponsibility_Project.ChainOfResponsibility;
using ChainOfResponsibility_Project.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponsibility_Project.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(WithDrawViewModel p)
        {
            Employee treasurer = new Treasurer();
            Employee manager = new Manager();
            Employee manaherAsistant = new ManagerAsistant();
            Employee regionalDirector = new RegionalDirector();

            treasurer.SetNextApprover(manaherAsistant);
            manaherAsistant.SetNextApprover(manager);
            manager.SetNextApprover(regionalDirector);

            treasurer.ProcessRequest(p);
            return View();
        }
    }
}
