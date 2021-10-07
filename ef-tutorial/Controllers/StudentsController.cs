using ef_tutorial.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_tutorial.Controllers
{
	class StudentsController
	{
		private readonly EdDbContext _context;

		public StudentsController()
		{
			_context = new EdDbContext();
		}

		public List<Student> GetAll()
		{
			return _context.Students
							.Include(x => x.Major)
							.ToList();
		}
		public Student GetByPk(int Id)
		{
			return _context.Students
							.Include(x => x.Major)
							.SingleOrDefault(s => s.Id == Id);
		}
		public bool Create(Student Student)
		{
			Student.Id = 0;
			_context.Students.Add(Student);
			var rowsAffected = _context.SaveChanges();
			if (rowsAffected != 1)
			{
				throw new Exception("Create failed");
			}
			return true;
		}
		public bool Change(int Id, Student Student)
		{
			if (Id != Student.Id)
			{
				throw new Exception("Ids don't match!");
			}
			_context.Entry(Student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			var rowsAffected = _context.SaveChanges();
			if (rowsAffected != 1)
			{
				throw new Exception("Create failed");
			}
			return true;
		}
		public bool Remove(int Id)
		{
			var Student = _context.Students.Find(Id);
			if (Student == null)
			{
				return false;
			}
			_context.Students.Remove(Student);
			_context.SaveChanges();
			return true;
		}
	}
}
