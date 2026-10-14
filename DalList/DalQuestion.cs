using Dal;
using DalFacade;
using DalFacade.DO;
using DO;
using System.Collections.Generic;
using System.Linq;
namespace DalFacade.DO;


/// <summary>
/// מימוש מחלקת ה-DAL עבור שאלות (Question) באמצעות רשימה בזיכרון
/// </summary>
public class DalQuestion : IQuestion
{
    /// <summary>
    /// מוסיף שאלה חדשה לרשימה
    /// </summary>
    /// <param name="question">השאלה להוספה</param>
    /// <exception cref="Exception">נזרק אם כבר קיימת שאלה עם מזהה זהה</exception>
    public void Add(Question question)
    {
        if (Read(question.Id) != null)
            throw new Exception($"Question with ID {question.Id} already exists.");
        DataSource.Questions.Add(question);
    }

    /// <summary>
    /// מחזיר שאלה לפי מזהה
    /// </summary>
    /// <param name="id">מזהה השאלה המבוקשת</param>
    /// <returns>השאלה שנמצאה, או null אם אינה קיימת</returns>
    public Question? Read(int id)
    {
        return DataSource.Questions.FirstOrDefault(q => q?.Id == id);
    }

    /// <summary>
    /// מחזיר את כל השאלות במערכת
    /// </summary>
    /// <returns>אוסף של כל השאלות</returns>
    public IEnumerable<Question> ReadAll()
    {
        return DataSource.Questions.Where(q => q != null).Select(q => q!);
    }

    /// <summary>
    /// מעדכן פרטי שאלה קיימת במערכת
    /// </summary>
    /// <param name="question">השאלה עם הפרטים המעודכנים</param>
    /// <exception cref="Exception">נזרק אם השאלה אינה קיימת במערכת</exception>
    public void Update(Question question)
    {
        var existing = Read(question.Id);
        if (existing == null)
            throw new Exception($"Question with ID {question.Id} does not exist.");
        DataSource.Questions.Remove(existing);
        DataSource.Questions.Add(question);
    }

    /// <summary>
    /// מוחק שאלה מהמערכת לפי מזהה
    /// </summary>
    /// <param name="id">מזהה השאלה למחיקה</param>
    /// <exception cref="Exception">נזרק אם השאלה אינה קיימת במערכת</exception>
    public void Delete(int id)
    {
        var existing = Read(id);
        if (existing == null)
            throw new Exception($"Question with ID {id} does not exist.");
        DataSource.Questions.Remove(existing);
    }
}