using System.Collections.Generic;

namespace Exam
{
    public class MultipleChoiceQuestion : ChooseAnswerQuestion
    {
        public List<int> CorrectAnswers { get; set; }

        public MultipleChoiceQuestion()
        {
            CorrectAnswers = new List<int>();
        }

        public override bool Equals(object obj)
        {
            var other = obj as MultipleChoiceQuestion;

            if (obj == null || !base.Equals(other))
            {
                return false;
            }

            return OperationHelper.CheckEquality(CorrectAnswers, other.CorrectAnswers);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ OperationHelper.GetHash(CorrectAnswers);  
        }
    }
}
