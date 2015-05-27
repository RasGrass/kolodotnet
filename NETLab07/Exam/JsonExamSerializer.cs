using System;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Exam
{
    public class JsonExamSerializer : IExamSerializer
    {
        private readonly JavaScriptSerializer _serializer;

        public JsonExamSerializer()
        {
            _serializer = new JavaScriptSerializer();
            _serializer.RegisterConverters(new JavaScriptConverter[] { new QuestionConverter() });

        }

        public string SerializeExam(Exam exam)
        {
            return Task<string>.Factory.StartNew(() => _serializer.Serialize(exam)).Result;
             
        }

        public Exam DeserializeExam(string text)
        {
            return _serializer.Deserialize<Exam>(text);
        }

        public string SerializeGrade(StudentGrade exam)
        {
            return _serializer.Serialize(exam);
        }

        public StudentGrade DeserializeGrade(string text)
        {
            return _serializer.Deserialize<StudentGrade>(text);
        }
    }
}
