using System;
using System.Text;

namespace Exam.Test
{
    public abstract class ExamTestBase
    {
        protected readonly Random _random;
        private const string LoremIpsum = "Lorem ipsum dolor sit amet consectetur adipiscing elit sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur Excepteur sint occaecat cupidatat non proident sunt in culpa qui officia deserunt mollit anim id est laborum";
        private static string[] LoremIpsumWords = LoremIpsum.Split(' ');

        protected ExamTestBase()
        {
            _random = new Random((int)DateTime.Now.Ticks);
        }

        protected string GetRandomText(int maxWordNo = 5)
        {
            var wordsNo = _random.Next(maxWordNo) + 1;
            var sb = new StringBuilder();

            for (int i = 0; i < wordsNo; i++)
            {
                sb.Append(LoremIpsumWords[_random.Next(LoremIpsumWords.Length)]);
                sb.Append(" ");
            }

            return sb.ToString();
        } 
    }
}
