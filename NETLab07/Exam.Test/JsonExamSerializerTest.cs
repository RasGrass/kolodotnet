using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exam.Test
{
    [TestClass]
    public class JsonExamSerializerTest : SerializerTest
    {
        protected override IExamSerializer GetSerializer()
        {
            return new JsonExamSerializer();
        }
    }
}
