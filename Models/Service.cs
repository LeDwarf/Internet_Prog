using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
	[Serializable]
	public class Service : AbstractModel
	{
		[Required(ErrorMessage = "Введите название")]
		[RegularExpression(@"^.{1,30}$", 
			ErrorMessage = "Введите от 1 до 30 символов")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Введите сумму")]
		[RegularExpression(@"^([1-9])\d{1,5}",
		   ErrorMessage = "Неверно введена сумма")]
		public double Price { get; set; }

		[Required(ErrorMessage = "Введите сумму")]
		[RegularExpression(@"^\d{1,2}",
		   ErrorMessage = "Введите число от 0 до 99")]
		public double Discount { get; set; }
	}
}