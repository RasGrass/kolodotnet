
namespace Exam
{
    public interface IExamSerializer
    {
        string SerializeExam(Exam exam);
        Exam DeserializeExam(string text);

        string SerializeGrade(StudentGrade exam);
        StudentGrade DeserializeGrade(string text);
    }
}
