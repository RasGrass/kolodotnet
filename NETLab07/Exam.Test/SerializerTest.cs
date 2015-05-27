using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Exam.Test
{
    public abstract class SerializerTest : ExamTestBase
    {
        private IExamSerializer _serializer;

        protected abstract IExamSerializer GetSerializer();

        [TestInitialize]
        public void InitTest()
        {
            _serializer = GetSerializer();
        }
        
        [TestMethod]
        public void StudentGrade_Serialization()
        {
            var beforeSerialization = new StudentGrade { 
                ExamId = _random.Next(), 
                StudentId = _random.Next(), 
                Grade = _random.Next() 
            };

            var serialized = _serializer.SerializeGrade(beforeSerialization);
            var afterSerialzation = _serializer.DeserializeGrade(serialized);

            Assert.AreEqual(beforeSerialization, afterSerialzation);
        }

        [TestMethod]
        public void MultipleChoiceQuestion_SerializeDeserialize()
        {
            PerformTest(CreateMultiChoiceQuestion);               
        }

        [TestMethod]
        public void OpenQuestion_SerializeDeserialize()
        {
            PerformTest(CreateOpenQuestion);            
        }

        [TestMethod]
        public void SingleChoiceQuestion_SerializeDeserialize()
        {
            PerformTest(CreateSingleChoiceQuestion);            
        }

        [TestMethod]
        public void AllQuestionTypes_SerializeDeserialize()
        {
            PerformTest(() =>
            {
                var rand = _random.Next(3);

                switch (rand)
                {
                    case 0: return CreateSingleChoiceQuestion();
                    case 1: return CreateOpenQuestion();
                    case 2: return CreateMultiChoiceQuestion();                        
                }

                throw new NotImplementedException();
            }, 30);  
        }

        private void PerformTest(Func<Question> factory, int maxItemsCount = 3)
        {
            var beforeSerialization = new Exam
            {
                ExamId = _random.Next()
            };
            beforeSerialization.Questions.AddRange(Enumerable.Range(0, maxItemsCount).Select(_ => factory()));
            
            var serialized = _serializer.SerializeExam(beforeSerialization);
            var afterSerialzation = _serializer.DeserializeExam(serialized);

            Assert.AreEqual(beforeSerialization, afterSerialzation);
        }

        private Question CreateSingleChoiceQuestion()
        {
            return new SingleChoiceQuestion
            {
                Title = GetRandomText(20),
                CorrectAnswer = _random.Next(4),
                Answers = new System.Collections.Generic.List<string> { GetRandomText(), GetRandomText(), GetRandomText(), GetRandomText() }
            };
        }

        private OpenQuestion CreateOpenQuestion()
        {
            return new OpenQuestion
            {
                Title = GetRandomText(20),
                CorrectAnswer = GetRandomText(1)
            };
        }

        private MultipleChoiceQuestion CreateMultiChoiceQuestion()
        {
            return new MultipleChoiceQuestion
            {
                Title = GetRandomText(20),
                CorrectAnswers = new System.Collections.Generic.List<int> { _random.Next(2), _random.Next(2) + 2 },
                Answers = new System.Collections.Generic.List<string> { GetRandomText(), GetRandomText(), GetRandomText(), GetRandomText() }
            };
        }
    }
}
