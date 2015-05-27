using System.Collections.Generic;
using System.Linq;

namespace Enumerables
{
	public class Student
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public bool Graduated
		{
			get
			{
				if (Exams == null || Exams.Count == 0)
					return false;

				return Exams.All(ex => ex.Passed);
			}
		}

		public List<Exam> Exams { get; set; }
	}
}
