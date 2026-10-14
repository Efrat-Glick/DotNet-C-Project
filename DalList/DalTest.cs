using DalFacade;
using DalFacade.DO;
using DO;
using System.Collections.Generic;
using System.Linq;

namespace Dal;

/// <summary>
/// מימוש מחלקת ה-DAL עבור מבחנים (Test) באמצעות רשימה בזיכרון
/// </summary>
public class DalTest : ITest
{
    public void Add(Test test)
    {
        if (Read(test.Id) != null)
            throw new Exception($"Test with ID {test.Id} already exists.");
        DataSource.Tests.Add(test);
    }

    public Test? Read(int id)
    {
        return DataSource.Tests.FirstOrDefault(t => t?.Id == id);
    }

    public IEnumerable<Test> ReadAll()
    {
        return DataSource.Tests.Where(t => t != null).Select(t => t!);
    }

    public void Update(Test test)
    {
        var existing = Read(test.Id);
        if (existing == null)
            throw new Exception($"Test with ID {test.Id} does not exist.");
        DataSource.Tests.Remove(existing);
        DataSource.Tests.Add(test);
    }

    public void Delete(int id)
    {
        var existing = Read(id);
        if (existing == null)
            throw new Exception($"Test with ID {id} does not exist.");
        DataSource.Tests.Remove(existing);
    }
}