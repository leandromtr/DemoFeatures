using Microsoft.AspNetCore.Mvc;
using MVCDemo.Data;
using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly MVCDemoDbContext _db;

        public ApplicationTypeController(MVCDemoDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationType;
            return View(objList);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ApplicationType obj)
        {
            _db.ApplicationType.Add(obj);
            _db.SaveChanges();            
            return RedirectToAction("Index");
        }
    }
}
