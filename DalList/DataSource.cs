using DO;
using System.Collections.Generic;
using DalFacade;
using DalFacade.DO;

namespace Dal;

/// <summary>
/// מחלקה סטטית המרכזת את כל רשימות הנתונים בזיכרון עבור מערכת הבחינות
/// </summary>
internal static class DataSource
{
    internal static List<Test?> Tests { get; set; } = [];
    internal static List<Question?> Questions { get; set; } = [];
    internal static List<Answer?> Answers { get; set; } = [];
    internal static List<Student?> Students { get; set; } = [];
    internal static List<StudentQuestion?> StudentQuestions { get; set; } = [];
}