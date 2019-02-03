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
	public class ServiceController : Controller
	{
		String store = ConfigurationManager.AppSettings.Get("DataStorage");
		IAbstractCrud service;


		public ServiceController()
		{
			if (store == "db")
			{
				service = new ServiceService();
			}

			if (store == "file")
			{
				service = new ServiceFileService();
			}
		}

		[HttpGet]
		public ActionResult EditService(int? id)
		{

			if (service.findById(id) != null)
			{
				return View(service.findById(id));
			}
			return HttpNotFound();
		}

		[HttpPost]
		public ActionResult EditService(Service s)
		{
			service.Edit(s);
			return RedirectToAction("Services");
		}

		[HttpGet]
		public ActionResult CreateService()

		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateService(Service s)
		{
			service.Create(s);
			return RedirectToAction("Services");
		}

		public ActionResult DeleteService(int id)
		{
			service.Delete(id);
			return RedirectToAction("Services");
		}

		public ActionResult Services()
		{
			return View(service.getList());
		}
	}
}