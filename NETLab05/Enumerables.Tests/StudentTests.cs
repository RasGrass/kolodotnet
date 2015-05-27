using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enumerables.Tests
{
	[TestClass]
	public class StudentTests
	{
		[TestMethod]
		public void Graduated_Returns_False_When_Exams_Is_Null()
		{
			var sut = new Student { Exams = null };
			var result = sut.Graduated;
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Graduated_Returns_False_When_Exams_Is_Empty()
		{
			var sut = new Student { Exams = new List<Exam>() };
			var result = sut.Graduated;
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Graduated_Returns_False_When_Not_All_Exams_Are_Passed()
		{
			var sut = new Student
			{
				Exams = new List<Exam>
				{
					new Exam { Grade = null },
					new Exam { Grade = 5 }
				}
			};
			var result = sut.Graduated;
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Graduated_Returns_False_When_There_Is_Any_Failed_Exam()
		{
			var sut = new Student
			{
				Exams = new List<Exam>
				{
					new Exam { Grade = 2 },
					new Exam { Grade = 5 }
				}
			};
			var result = sut.Graduated;
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Graduated_Returns_True_When_All_Exams_Are_Passed()
		{
			var sut = new Student
			{
				Exams = new List<Exam>
				{
					new Exam { Grade = 3 },
					new Exam { Grade = 5 }
				}
			};
			var result = sut.Graduated;
			Assert.IsTrue(result);
		}
	}
}
