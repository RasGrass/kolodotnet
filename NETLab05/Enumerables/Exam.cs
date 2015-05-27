namespace Enumerables
{
	public class Exam
	{
		public string Name { get; set; }

		private int? _grade;

		public int? Grade
		{
			get { return _grade; }
			set
			{
				if (value.HasValue && (value < 2 || value > 5))
					throw new InvalidGradeException(value.Value);
				_grade = value;
			}
		}

		public bool Passed
		{
			get { return Grade.HasValue && Grade.Value > 2; }
		}
	}
}