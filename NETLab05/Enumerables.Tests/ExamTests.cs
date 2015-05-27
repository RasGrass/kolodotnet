using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enumerables.Tests
{
	[TestClass]
	public class ExamTests
	{
		[TestMethod]
		[ExpectedException(typeof(InvalidGradeException))]
		public void Grade_Throws_When_Invalid_Grade_1()
		{
			var sut = new Exam { Grade = 1 };
			var result = sut.Passed;
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidGradeException))]
		public void Grade_Throws_When_Invalid_Grade_2()
		{
			var sut = new Exam { Grade = 6 };
			var result = sut.Passed;
		}

		[TestMethod]
		public void Passed_Returns_False_When_No_Grade()
		{
			var sut = new Exam { Grade = null };
			var result = sut.Passed;
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Passed_Returns_False_When_Grade_Is_2()
		{
			var sut = new Exam { Grade = 2 };
			var result = sut.Passed;
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Passed_Returns_False_When_Grade_Is_Greater_Than_2()
		{
			var sut = new Exam { Grade = 4 };
			var result = sut.Passed;
			Assert.IsTrue(result);
		}
	}
}
