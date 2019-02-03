using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
	[Serializable]
	public class Car : AbstractModel
	{
		[Required(ErrorMessage = "Введите название")]
		[RegularExpression(@"^.{1,30}$",
			ErrorMessage = "Введите от 1 до 30 символов")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Введите число км. пробега")]
		[RegularExpression(@"^([1-9])\d{1,4}",
		   ErrorMessage = "Неверно введена сумма")]
		public string Mileage { get; set; }

		[Required(ErrorMessage = "Введите тип КПП")]
		[RegularExpression(@"^(?:Автомат|Механика)",
			ErrorMessage = "'Автомат' или 'Механика'")]
		public string Transmission { get; set; }

		[Required(ErrorMessage = "Введите объем / мощность / тип топлива")]
		[RegularExpression(@"^.{1,30}$",
			ErrorMessage = "Пример: 5л/150лс/Бензин")]
		public string Engine { get; set; }

		[Required(ErrorMessage = "Введите количество мест")]
		[RegularExpression(@"^([2,4,5,6])",
		   ErrorMessage = "Допустимое количество: 2, 4, 5, 6")]
		public int Psngr_cap { get; set; }

		[Required(ErrorMessage = "Введите сумму")]
		[RegularExpression(@"^([1-9])\d{1,6}",
		   ErrorMessage = "Неверно введена сумма")]
		public double Price { get; set; }

		[Required(ErrorMessage = "Введите сумму")]
		[RegularExpression(@"^\d{1,2}",
		   ErrorMessage = "Введите число от 0 до 99")]
		public double Discount { get; set; }
	}
}