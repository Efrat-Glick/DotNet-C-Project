namespace DalFacade;

using DO;
using global::DO;

public interface IStudent
{
    void Add(Student student);
    Student? Read(int id);
    IEnumerable<Student> ReadAll();
    void Update(Student student);
    void Delete(int id);
}