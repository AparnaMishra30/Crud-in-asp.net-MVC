using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvclearn.Models;

namespace mvclearn.Controllers
{
    public class ModelController : Controller
    {
        // GET: Model
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Model person)
        {
            string name = person.personname;
            int age = person.personage;
            DBrun.Create(person);
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            DBrun obj = new DBrun();
            List<Model> employees = obj.FetchEmployees();
            Session["employees"] = employees;
            return View(employees);
        }
        public ActionResult Edit(int id)
          {
            var employees = (List<Model>)Session["employees"];
          //  var product = _products.FirstOrDefault(p => p.Id == id);
          var employee = employees?.FirstOrDefault(e => e.personid == id);
            TempData["id"] = id;
            return View("Edit",employee);
        }
        [HttpPost]
        public ActionResult Edit(Model updateemp)
        {
            
            var employees = (List<Model>)Session["employees"];
            int id = Convert.ToInt32(TempData["id"]);
            var employee = employees?.FirstOrDefault(e => e.personid == id);
            employee.personname = updateemp.personname;
            employee.personage = updateemp.personage;
            employee.personid = id;
            DBrun.Update(employee);
            return RedirectToAction("Login");
        }
        public ActionResult Delete(int id)
        {
            DBrun.deleterow(id);
            return RedirectToAction("Login");
        }
    }

}