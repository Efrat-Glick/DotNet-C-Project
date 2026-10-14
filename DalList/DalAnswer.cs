using DalFacade;
using DalFacade.DO;
using DO;
using System.Collections.Generic;
using System.Linq;


namespace Dal;

/// <summary>
/// מימוש מחלקת ה-DAL עבור תשובות (Answer) באמצעות רשימה בזיכרון
/// </summary>
public class DalAnswer : IAnswer
{
    public void Add(Answer answer)
    {
        if (Read(answer.Id) != null)
            throw new Exception($"Answer with ID {answer.Id} already exists.");
        DataSource.Answers.Add(answer);
    }

    public Answer? Read(int id)
    {
        return DataSource.Answers.FirstOrDefault(a => a?.Id == id);
    }

    public IEnumerable<Answer> ReadAll()
    {
        return DataSource.Answers.Where(a => a != null).Select(a => a!);
    }

    public void Update(Answer answer)
    {
        var existing = Read(answer.Id);
        if (existing == null)
            throw new Exception($"Answer with ID {answer.Id} does not exist.");
        DataSource.Answers.Remove(existing);
        DataSource.Answers.Add(answer);
    }

    public void Delete(int id)
    {
        var existing = Read(id);
        if (existing == null)
            throw new Exception($"Answer with ID {id} does not exist.");
        DataSource.Answers.Remove(existing);
    }
}