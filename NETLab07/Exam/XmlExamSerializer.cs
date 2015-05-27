using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exam
{
    public class XmlExamSerializer : IExamSerializer
    {
        private readonly XmlSerializer _examSerializer;
        private readonly XmlSerializer _gradeSerializer;

        public XmlExamSerializer()
        {
            _gradeSerializer = new XmlSerializer( typeof(StudentGrade));
            _examSerializer = new XmlSerializer(typeof(Exam), 
                new Type[]{
                    typeof(OpenQuestion),
                    typeof(SingleChoiceQuestion),
                    typeof(MultipleChoiceQuestion),
                    typeof(Question),
                    typeof(ChooseAnswerQuestion)
                });
        }

        public string SerializeExam(Exam exam)
        {
            var temp = new StringBuilder();
            using (var writer = new StringWriter(temp))
            {
                _examSerializer.Serialize(writer,exam);
            }
            return temp.ToString();
        }

        public Exam DeserializeExam(string text)
        {
            Exam result = null;
            using (var reader = new StringReader(text))
            {
                result = _examSerializer.Deserialize(reader) as Exam;
            }
            return result;
        }

        public string SerializeGrade(StudentGrade exam)
        {
            var temp = new StringBuilder();
            using (var writer = new StringWriter(temp))
            {
                Task.Factory.StartNew(() =>_gradeSerializer.Serialize(writer,exam));
            }
            return temp.ToString();
        }

        public StudentGrade DeserializeGrade(string text)
        {
            StudentGrade grade = null;
            using (var rader = new StringReader(text))
            {
                grade =_gradeSerializer.Deserialize(rader) as StudentGrade;
            }
            return grade;
        }
    }
}
