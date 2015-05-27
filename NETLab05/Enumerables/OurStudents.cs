using System.Collections.Generic;
using System.Linq;

namespace Enumerables
{
	public class OurStudents
	{
		private readonly Student[] _students =
		{
			new Student
			{
				Id = 1,
				Name = "Smith",
				Exams = new List<Exam>
				{
					new Exam { Name = "Algebra" },
					new Exam { Name = "Economics" }
				}
			},
			new Student
			{
				Id = 2,
				Name = "Lee",
				Exams = new List<Exam>
				{
					new Exam { Name = "Algebra" },
					new Exam { Name = "Geometry" },
					new Exam { Name = "Economics" }
				}
			},
			new Student
			{
				Id = 3,
				Name = "Brown",
				Exams = new List<Exam>
				{
					new Exam { Name = "Economics" }
				}
			}
		};

		public Student[] StudentsArray
		{
			get { return _students; }
		}

		public List<Student> StudentsList
		{
			get { return _students.ToList(); }
		}
	}
}
