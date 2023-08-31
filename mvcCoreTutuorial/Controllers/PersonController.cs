using Microsoft.AspNetCore.Mvc;
using mvcCoreTutuorial.Models.Domain;
using System;

namespace mvcCoreTutuorial.Controllers
{
    public class PersonController : Controller
    {
        private readonly DatabaseContext _ctx;
        public PersonController(DatabaseContext ctx) 
        { 
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            //there are three methods for trasferring data from controller to view
            //1st one is viewbag
            ViewBag.greeting = "Hello MVC from ViewBag";
            //2nd one is ViewData
            ViewData["greeting2"] = "this msg is from ViewData";
            //1st and 2nd can send data only from controller to view
            //3rd one is Temdata
            //Tempdata can send data from one controller method to another controller method 
            TempData["greeting3"] = "this msg is from tempdata";
            return View();
        }
        //it is a get method
        public IActionResult AddPerson()
        {
           return View();
        }

        [HttpPost]
		public IActionResult AddPerson(Person person)
		{
            if(!ModelState.IsValid)
            {
                return View();

            }
            try
            {
                _ctx.Person.Add(person);
                _ctx.SaveChanges();
                TempData["msg"] = "Added succesfully";
                return RedirectToAction("AddPerson");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "could not Added";
                return View();
            }
       
		}
		[HttpPost]
		public IActionResult EditPerson(Person person)
		{
			if (!ModelState.IsValid)
			{
				return View();

			}
			try
			{
				_ctx.Person.Update(person);
				_ctx.SaveChanges();
				
				return RedirectToAction("DisplyPerson");
			}
			catch (Exception ex)
			{
				TempData["msg"] = "could not updateed";
				return View();
			}

		}

        public IActionResult EditPerson(int id)
        {
            var persons = _ctx.Person.Find(id);
            return View(persons);
        }

        public IActionResult  DisplyPerson()
        {
            var persons = _ctx.Person.ToList();
            return View(persons);
        }
		public IActionResult DeletePerson(int id)
		{
            try
            {
				var persons = _ctx.Person.Find(id);
                if (persons!= null)
                {
                    _ctx.Person.Remove(persons);
                    _ctx.SaveChanges();

                }
					
			}
            catch(Exception ex) 
            {

            }
            return RedirectToAction("DisplyPerson");
			
		}



	}
}
