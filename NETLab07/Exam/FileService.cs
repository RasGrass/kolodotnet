using System;
using System.IO;

namespace Exam
{
    public class FileService
    {
        public void WriteAllText(string filename, string content)
        {
            using (var writer = new StreamWriter(filename))
            {
                writer.Write(content);
            }
        }

        public string ReadAllText(string filename)
        {
            string result;
            using (var reader = new StreamReader(filename))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
