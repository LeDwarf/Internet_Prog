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
	public abstract class AbstractFileService : IAbstractCrud
	{
		public XmlSerializer xsSubmit { get; set; }
		public string currentPath { get; set; }
		public String Name { get; set; }

		public void Delete(int id)
		{
			File.Delete(currentPath + "/" + Name + id + ".txt");
		}

		public void Edit(AbstractModel amodel)
		{
			StringWriter txtWriter = new StringWriter();
			xsSubmit.Serialize(txtWriter, amodel);
			File.WriteAllText(currentPath + "/" + Name + amodel.Id + ".txt", txtWriter.ToString());
			txtWriter.Close();
		}

		public void Create(AbstractModel amodel)
		{
			int max = 0;
			foreach (var path in Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly))
			{
				Match m = Regex.Match(path, @"" + Name + @"\d+");
				int currentId = Convert.ToInt32(m.Value.Replace(Name, ""));
				if (currentId > max)
				{
					max = currentId;
				}
			}
			int id = max + 1;
			amodel.Id = id;
			string newFilePath = currentPath + "/" + Name + id + ".txt";
			StringWriter txtWriter = new StringWriter();
			xsSubmit.Serialize(txtWriter, amodel);
			File.WriteAllText(newFilePath, txtWriter.ToString());
			txtWriter.Close();
		}

		public AbstractModel findById(int? id)
		{
			AbstractModel amodel;
			using (StreamReader stream = new StreamReader(currentPath + "/" + Name + id + ".txt", true))
			{
				amodel = (AbstractModel)xsSubmit.Deserialize(stream);
				stream.Close();
			}
			return amodel;
		}

		public List<AbstractModel> getList()
		{
			string[] filesPaths = Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly);
			List<AbstractModel> amodelList = new List<AbstractModel>();
			foreach (string item in filesPaths)
			{
				StreamReader stream = new StreamReader(item, true);
				AbstractModel amodel = (AbstractModel)xsSubmit.Deserialize(stream);
				amodelList.Add(amodel);
				stream.Close();
			}
			return amodelList;
		}
	}
}