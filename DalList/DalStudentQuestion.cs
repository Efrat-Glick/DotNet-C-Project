using DalFacade;
using DalFacade.DO;
using DO;
using System.Collections.Generic;
using System.Linq;

namespace Dal;

/// <summary>
/// מימוש מחלקת ה-DAL עבור שאלות לנבחן (StudentQuestion) באמצעות רשימה בזיכרון
/// </summary>
public class DalStudentQuestion : IStudentQuestion
{
    public void Add(StudentQuestion studentQuestion)
    {
        // בדיקה האם הרשומה כבר קיימת עבור אותו תלמיד, בחינה ושאלה
        if (Read(studentQuestion.StudentId, studentQuestion.TestId, studentQuestion.QuestionId) != null)
            throw new Exception("StudentQuestion already exists.");
        DataSource.StudentQuestions.Add(studentQuestion);
    }

    // מתודת עזר המקבלת מזהים מרובים
    public StudentQuestion? Read(int studentId, int testId, int questionId)
    {
        return DataSource.StudentQuestions.FirstOrDefault(sq =>
            sq?.StudentId == studentId && sq?.TestId == testId && sq?.QuestionId == questionId);
    }

    // מימוש Read לפי מזהה בודד (אם נדרש בממשק לפי ID יחיד, ניתן להתאים לפי המבנה)
    public StudentQuestion? Read(int id)
    {
        return DataSource.StudentQuestions.FirstOrDefault(sq => sq?.StudentId == id);
    }

    public IEnumerable<StudentQuestion> ReadAll()
    {
        return DataSource.StudentQuestions.Where(a => a != null).Select(a => a!);
    }

    public void Update(StudentQuestion studentQuestion)
    {
        var existing = Read(studentQuestion.StudentId, studentQuestion.TestId, studentQuestion.QuestionId);
        if (existing == null)
            throw new Exception("StudentQuestion does not exist.");
        DataSource.StudentQuestions.Remove(existing);
        DataSource.StudentQuestions.Add(studentQuestion);
    }

    public void Delete(int studentId, int testId, int questionId)
    {
        var existing = Read(studentId, testId, questionId);
        if (existing == null)
            throw new Exception("StudentQuestion does not exist.");
        DataSource.StudentQuestions.Remove(existing);
    }

    public void Delete(int id)
    {
        var existing = Read(id);
        if (existing == null)
            throw new Exception($"StudentQuestion with ID {id} does not exist.");
        DataSource.StudentQuestions.Remove(existing);
    }
}