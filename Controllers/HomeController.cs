using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Services;
using WebProject.Models;

namespace WebProject.Controllers
{
	public class HomeController : Controller
	{
		CarContext db = new CarContext();

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult News()
		{
			return View();
		}

		public ActionResult Feedback()
		{
			return View();
		}
	}
}