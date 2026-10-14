using DalFacade;
using DalFacade.DO;
using DO;
using System.Collections.Generic;
using System.Linq;


namespace Dal;

/// <summary>
/// מימוש מחלקת ה-DAL עבור תלמידים (Student) באמצעות רשימה בזיכרון
/// </summary>
public class DalStudent : IStudent
{
    public void Add(Student student)
    {
        if (Read(student.Id) != null)
            throw new Exception($"Student with ID {student.Id} already exists.");
        DataSource.Students.Add(student);
    }

    public Student? Read(int id)
    {
        return DataSource.Students.FirstOrDefault(s => s?.Id == id);
    }

    public IEnumerable<Student> ReadAll()
    {
        return DataSource.Students.Where(s => s != null).Select(s => s!);
    }

    public void Update(Student student)
    {
        var existing = Read(student.Id);
        if (existing == null)
            throw new Exception($"Student with ID {student.Id} does not exist.");
        DataSource.Students.Remove(existing);
        DataSource.Students.Add(student);
    }

    public void Delete(int id)
    {
        var existing = Read(id);
        if (existing == null)
            throw new Exception($"Student with ID {id} does not exist.");
        DataSource.Students.Remove(existing);
    }
}