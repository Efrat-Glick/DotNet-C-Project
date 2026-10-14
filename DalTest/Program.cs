using Dal;
using DalFacade;
using DalFacade.DO;
using DO;

namespace DalTest;

internal class Program
{
    static readonly ITest s_dalTest = new Dal.DalTest();
    static readonly IQuestion s_dalQuestion = new DalQuestion();
    static readonly IAnswer s_dalAnswer = new DalAnswer();
    static readonly IStudent s_dalStudent = new DalStudent();
    static readonly IStudentQuestion s_dalStudentQuestion = new DalStudentQuestion();

    static void Main(string[] args)
    {
        Console.WriteLine("=== Starting DAL Tests for Exam System ===");

        TestTest();
        TestQuestion();
        TestAnswer();
        TestStudent();
        TestStudentQuestion();

        Console.WriteLine("\n=== All Tests Completed Successfully! ===");
    }

    private static void TestTest()
    {
        Console.WriteLine("\n--- Testing Test ---");
        Test t = new(1, Subject.Math, DateTime.Now, 10);
        s_dalTest.Add(t);

        var readT = s_dalTest.Read(1);
        Console.WriteLine($"Read Test: {readT}");
    }

    private static void TestQuestion()
    {
        Console.WriteLine("\n--- Testing Question ---");
        Question q = new(10, Subject.Math, "What is 2 + 2?", 100);
        s_dalQuestion.Add(q);

        var readQ = s_dalQuestion.Read(10);
        Console.WriteLine($"Read Question: {readQ}");
    }

    private static void TestAnswer()
    {
        Console.WriteLine("\n--- Testing Answer ---");
        Answer a = new(100, 10, "4");
        s_dalAnswer.Add(a);

        var readA = s_dalAnswer.Read(100);
        Console.WriteLine($"Read Answer: {readA}");
    }

    private static void TestStudent()
    {
        Console.WriteLine("\n--- Testing Student ---");
        Student s = new(123456789, "Israel Israelite", 1, 95);
        s_dalStudent.Add(s);

        var readS = s_dalStudent.Read(123456789);
        Console.WriteLine($"Read Student: {readS}");
    }

    private static void TestStudentQuestion()
    {
        Console.WriteLine("\n--- Testing StudentQuestion ---");
        StudentQuestion sq = new(123456789, 1, 10, 100);
        s_dalStudentQuestion.Add(sq);

        var readSq = s_dalStudentQuestion.Read(123456789, 1, 10);
        Console.WriteLine($"Read StudentQuestion: {readSq}");
    }
}