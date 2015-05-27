using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exam.Test
{
    [TestClass]
    public class XmlExamSerializerTest : SerializerTest
    {
        protected override IExamSerializer GetSerializer()
        {
            return new XmlExamSerializer();
        }
    }
}
