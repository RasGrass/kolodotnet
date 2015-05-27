using System.Collections.Generic;

namespace Exam
{
    public abstract class ChooseAnswerQuestion : Question
    {
        public List<string> Answers { get; set; }

        public ChooseAnswerQuestion()
        {
            Answers = new List<string>();
        }

        public override bool Equals(object obj)
        {
            var other = obj as ChooseAnswerQuestion;

            if (obj == null || !base.Equals(other))
            {
                return false;
            }

            return OperationHelper.CheckEquality(Answers, other.Answers);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ OperationHelper.GetHash(Answers);           
        }
    }
}
