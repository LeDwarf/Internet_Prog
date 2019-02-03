using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebProject.Interfaces;
using WebProject.Models;

namespace WebProject.Services
{
	public class CarService : IAbstractCrud
	{
		CarContext db = new CarContext();

		public void Delete(int id)
		{
			Car b = db.Cars.Find(id);
			if (b != null)
			{
				db.Cars.Remove(b);
				db.SaveChanges();
			}
		}

		public void Edit(AbstractModel amodel)
		{
			db.Entry((Car)amodel).State = EntityState.Modified;
			db.SaveChanges();
		}

		public void Create(AbstractModel amodel)
		{
			db.Cars.Add((Car)amodel);
			db.SaveChanges();
		}

		public AbstractModel findById(int? id)
		{
			Car s = db.Cars.Find(id);
			return s;
		}

		public List<AbstractModel> getList()
		{
			List<AbstractModel> amodel = new List<AbstractModel>();
			List<Car> s = db.Cars.ToList();
			for (int i = 0; i < s.Count; i++)
			{
				amodel.Add(s[i]);
			}
			return amodel;
		}
	}
}