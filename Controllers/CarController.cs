using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Interfaces;
using WebProject.Models;
using WebProject.Services;

namespace WebProject.Controllers
{
	public class CarController : Controller
	{
		String store = ConfigurationManager.AppSettings.Get("DataStorage");
		IAbstractCrud car;


		public CarController()
		{
			if (store == "db")
			{
				car = new CarService();
			}

			if (store == "file")
			{
				car = new CarFileService();
			}
		}

		[HttpGet]
		public ActionResult EditCar(int? id)
		{

			if (car.findById(id) != null)
			{
				return View(car.findById(id));
			}
			return HttpNotFound();
		}

		[HttpPost]
		public ActionResult EditCar(Car s)
		{
			car.Edit(s);
			return RedirectToAction("Cars");
		}

		[HttpGet]
		public ActionResult CreateCar()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateCar(Car s)
		{
			car.Create(s);
			return RedirectToAction("Cars");
		}

		public ActionResult DeleteCar(int id)
		{
			car.Delete(id);
			return RedirectToAction("Cars");
		}

		public ActionResult Cars()
		{
			return View(car.getList());
		}
	}
}