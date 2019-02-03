using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebProject.Models;

namespace WebProject
{
	public class CarContext : DbContext
	{
		public DbSet<Car> Cars { get; set; }
		public DbSet<Service> Services { get; set; }
	}
}