using System;

namespace Exam
{
    public abstract class Question
    {
        public string Title { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Question;

            if (obj == null)
            {
                return false;
            }

            return string.Equals(Title, other.Title, StringComparison.InvariantCulture);
        }

        public override int GetHashCode()
        {
            return OperationHelper.GetHashCodeFromObject(Title);            
        }
    }
}
