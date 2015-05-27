
namespace Exam
{
    public class StudentGrade
    {
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public int? Grade { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            var other = obj as StudentGrade; 
            return ExamId == other.ExamId
                && StudentId == other.StudentId
                && Grade == other.Grade;
        }

        public override int GetHashCode()
        {
            return ExamId ^ StudentId ^ (Grade.HasValue ? Grade.Value : 0);
        }
    }
}
