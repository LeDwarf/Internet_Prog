using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WebProject.Interfaces;
using WebProject.Models;

namespace WebProject.Services
{
	public class ServiceService : IAbstractCrud
	{
		CarContext db = new CarContext();

		public void Delete(int id)
		{
			Service b = db.Services.Find(id);
			if (b != null)
			{
				db.Services.Remove(b);
				db.SaveChanges();
			}
		}

		public void Edit(AbstractModel amodel)
		{
			db.Entry((Service)amodel).State = EntityState.Modified;
			db.SaveChanges();
		}

		public void Create(AbstractModel amodel)
		{
			db.Services.Add((Service)amodel);
			db.SaveChanges();
		}

		public AbstractModel findById(int? id)
		{
			Service s = db.Services.Find(id);
			return s;
		}

		public List<AbstractModel> getList()
		{
			List<AbstractModel> amodel = new List<AbstractModel>();
			List<Service> s = db.Services.ToList();
			for (int i = 0; i < s.Count; i++)
			{
				amodel.Add(s[i]);
			}
			return amodel;
		}
	}
}