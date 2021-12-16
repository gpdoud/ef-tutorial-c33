using ef_tutorial.Controllers;
using ef_tutorial.Models;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace ef_tutorial
{
	class Program
	{
		async static Task Main(string[] args)
		{
			var majCtrl = new MajorsController();
			var majors = await majCtrl.GetAll();
			majors.ForEach(m => Console.WriteLine(m));
			var major = await majCtrl.GetByPk(1);
			Console.WriteLine(major);
		}
		
		//static void FakeMethod() { 
		//	Major major = null;
		//	var majorsCtrl = new MajorsController();

		//	var NewMajor = new Major()
		//	{
		//		Id = 0, Code = "MUSX", Description = "Music", MinSat = 1595
		//	};
		//	try
		//	{
		//		var rc1 = majorsCtrl.Create(NewMajor);
		//		if (!rc1)
		//		{
		//			Console.WriteLine("Create failed!");
		//		}
		//	} catch (Exception ex)
		//	{
		//		Console.WriteLine($"Exception occurred: {ex.Message}");
		//	}
		//	NewMajor.Description = "Classical Music";
		//	majorsCtrl.Change(NewMajor.Id, NewMajor);
		//	Console.WriteLine($"NewMajor {NewMajor}");
		//	var rc = majorsCtrl.Remove(NewMajor.Id);
		//	if (!rc)
		//	{
		//		Console.WriteLine("Remove failed!");
		//	}
		//	major = majorsCtrl.GetByCode("GENB");
		//	Console.WriteLine(major);

		//	major = majorsCtrl.GetByPk(2);
		//	Console.WriteLine($"{major.Description}");

		//	major = majorsCtrl.GetByPk(999999);
		//	if(major == null)
		//	{
		//		Console.WriteLine("Not found");
		//	}

		//	var majors = majorsCtrl.GetAll();
		//	foreach(var m in majors)
		//	{
		//		Console.WriteLine($"{m.Description}");
		//	}
		//}
	}
}
