using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;
using WebProject.Interfaces;
using WebProject.Models;

namespace WebProject.Services
{
	public class ServiceFileService : AbstractFileService
	{
		string Name = "Service";
		string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Service";
		XmlSerializer xsSubmit = new XmlSerializer(typeof(Service));

		public ServiceFileService()
		{
			base.Name = Name;
			base.xsSubmit = xsSubmit;
			base.currentPath = currentPath;
		}
	}
}