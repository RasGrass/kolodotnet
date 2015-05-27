using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exam.Test
{
    [TestClass]
    public class FileServiceTest : ExamTestBase
    {
        private FileService _fileService;

        [TestInitialize]
        public void Init()
        {
            _fileService = new FileService();
        }

        [TestMethod]
        public void WriteAllText_Test()
        {
            var filePath = System.IO.Path.GetTempFileName();
            var textToBeWriten = GetRandomText(20);

            _fileService.WriteAllText(filePath, textToBeWriten);

            var textRead = System.IO.File.ReadAllText(filePath);
            Assert.AreEqual(textToBeWriten, textRead);
        }

        [TestMethod]
        public void ReadAllText_Test()
        {
            var filePath = System.IO.Path.GetTempFileName();
            var textToBeWriten = GetRandomText(20);
            System.IO.File.WriteAllText(filePath, textToBeWriten);

            var textRead = _fileService.ReadAllText(filePath);  
            
            Assert.AreEqual(textRead, textToBeWriten);
        }
    }
}
