using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Script.Serialization;

namespace Exam
{
    public class QuestionConverter : JavaScriptConverter
    {
        public const string QuestionTypeField = "QuestionType";
        public const string AnswersField = "Answers";
        public const string MultipleChoiceQuestionType = "MultipleChoiceQuestion";
        public const string SingleChoiceQuestionType = "SingleChoiceQuestion";
        public const string OpenQuestionType = "OpenQuestion";
        public const string TitleField = "Title";
        public const string CorrectAnswersField = "CorrectAnswers";
        public const string CorrectAnswerField = "CorrectAnswer";
        

        public void costam()
        {
            Thread.Sleep(2000);
        }


        private List<T> GetListFromObject<T>(object obj)
        {
            return (obj as System.Collections.ArrayList).Cast<T>().ToList();
        }

        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            var question = dictionary["QuestionType"] as string;
            Question result;
            switch (question)
            {
                case "MultipleChoiceQuestion":
                    result = new MultipleChoiceQuestion
                    {
                        Title = dictionary["Title"] as string,
                        Answers = GetListFromObject<string>(dictionary["Answers"]),
                        CorrectAnswers = GetListFromObject<int>(dictionary["CorrectAnswers"])
                    };
                    break;
                case "OpenQuestion":
                    result = new OpenQuestion
                    {
                        CorrectAnswer = dictionary["CorrectAnswer"] as string,
                        Title = dictionary["Title"] as string
                    };
                    break;
                case "SingleChoiceQuestion":
                    result = new SingleChoiceQuestion
                    {
                        Answers = GetListFromObject<string>(dictionary["Answers"]),
                        CorrectAnswer = (int) dictionary["CorrectAnswer"],
                        Title = dictionary["Title"] as string
                    };
                    break;
                default:
                    result = null;
                    break;
            }
            return result;
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            IDictionary<string,object> result = new Dictionary<string, object>();
            
            if (obj.GetType() == typeof (MultipleChoiceQuestion))
            {
                var q = obj as MultipleChoiceQuestion;                
                result.Add("QuestionType","MultipleChoiceQuestion");
                result.Add("CorrectAnswers",q.CorrectAnswers);
                result.Add("Title",q.Title);
                result.Add("Answers", q.Answers);

            } else if(obj.GetType() == typeof (OpenQuestion))
            {
                var q = obj as OpenQuestion;
                result.Add("QuestionType", "OpenQuestion");
                result.Add("CorrectAnswer", q.CorrectAnswer);
                result.Add("Title", q.Title);

            } else if (obj.GetType() == typeof (SingleChoiceQuestion))
            {
                var q = obj as SingleChoiceQuestion;
                result.Add("QuestionType", "SingleChoiceQuestion");
                result.Add("CorrectAnswer", q.CorrectAnswer);
                result.Add("Title", q.Title);
                result.Add("Answers", q.Answers);

            } else if(obj.GetType() == typeof (Question))
            {
                var q = obj as Question;
                result.Add("QuestionType", "Question");
                result.Add("Title", q.Title);
            } else if(obj.GetType() == typeof (ChooseAnswerQuestion))
            {
                var q = obj as ChooseAnswerQuestion;
                result.Add("QuestionType", "SingleChoiceQuestion");
                result.Add("Title", q.Title);
                result.Add("Answers", q.Answers);
            }
            return result;
        }

        public override IEnumerable<Type> SupportedTypes
        {
            get
            {
                return new Type[] { typeof(OpenQuestion), typeof(SingleChoiceQuestion), typeof(MultipleChoiceQuestion), typeof(Question), typeof(ChooseAnswerQuestion) };
            }
        }
    }
}
