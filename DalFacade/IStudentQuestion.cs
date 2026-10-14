namespace DalFacade;

using DO;
using global::DO;

public interface IStudentQuestion
{
    void Add(StudentQuestion studentQuestion);
    StudentQuestion? Read(int studentId, int testId, int questionId);
    IEnumerable<StudentQuestion> ReadAll();
    void Update(StudentQuestion studentQuestion);
    void Delete(int studentId, int testId, int questionId);
}