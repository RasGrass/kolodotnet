using System.Collections.Generic;
using System.Linq;

namespace Enumerables
{
	public static class StudentExtensions
	{
		public static double? GetAverageGrade(this Student student)
		{
			if (student.Exams == null)
				return null;

			return student.Exams
				.Where(exam => exam.Grade.HasValue)
				.Average(exam => exam.Grade.Value);
		}

		public static List<Exam> GetFailedExams(this Student student)
		{
			if (student.Exams == null)
				return new List<Exam>();

			return student.Exams
				.Where(exam => exam.Passed == false)
				.ToList();
		}
	}
}
