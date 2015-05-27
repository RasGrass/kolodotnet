using System;

namespace Exam
{
    public class OpenQuestion: Question
    {
        public string CorrectAnswer { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as OpenQuestion;

            if (obj == null || !base.Equals(other))
            {
                return false;
            }

            return string.Equals(CorrectAnswer, other.CorrectAnswer, StringComparison.InvariantCulture);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ OperationHelper.GetHashCodeFromObject(CorrectAnswer);
        }
    }
}
