using System.Collections.Generic;

namespace Exam
{
    public class Exam
    {
        public int ExamId { get; set; }
        public List<Question> Questions { get; set; }

        public Exam()
        {
            Questions = new List<Question>();        
        }

        public override bool Equals(object obj)
        {
            var other = obj as Exam;

            if(other == null) {
                return false;
            }

            return ExamId == other.ExamId && OperationHelper.CheckEquality(Questions, other.Questions);
        }

        public override int GetHashCode()
        {
            return OperationHelper.GetHash(Questions) ^ ExamId;
        }
    }
}
