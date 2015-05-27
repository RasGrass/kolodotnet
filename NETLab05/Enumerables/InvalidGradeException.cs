using System;

namespace Enumerables
{
	public class InvalidGradeException : Exception
	{
		private readonly string _message;

		public override string Message
		{
			get { return _message; }
		}

		public InvalidGradeException(int grade)
		{
			_message = "Provided grade ({0}) is not valid. Please provide value between 2 and 5.";
		}
	}
}
