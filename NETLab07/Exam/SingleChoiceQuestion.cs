
namespace Exam
{
    public class SingleChoiceQuestion : ChooseAnswerQuestion
    {
        public int CorrectAnswer { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as SingleChoiceQuestion;

            if (obj == null || !base.Equals(other))
            {
                return false;
            }

            return CorrectAnswer == other.CorrectAnswer;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ CorrectAnswer;
        }
    }
}
