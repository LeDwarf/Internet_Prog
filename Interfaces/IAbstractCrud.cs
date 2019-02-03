using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Models;

namespace WebProject.Interfaces
{
	interface IAbstractCrud
	{
		void Delete(int id);
		void Edit(AbstractModel amodel);
		void Create(AbstractModel amodel);
		AbstractModel findById(int? id);
		List<AbstractModel> getList();
	}
}
