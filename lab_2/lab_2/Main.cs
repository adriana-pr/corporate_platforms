using System;
using System.Collections;
using lab_2;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace laboratory;

public class MainTest
{
    public static void Main()
    {

        Person person1 = new Person("Tanya", "Ivanova", new DateTime(2000, 1, 30));
        Person person2 = new Person("Tanya", "Ivanova", new DateTime(2000, 1, 30));
        //Console.WriteLine(person1.Equals(person2));

        //Console.WriteLine("Хеш код person1" + person1.GetHashCode());
        //Console.WriteLine("Хеш код person2" + person2.GetHashCode());

        Student student = new Student(person1, Education.Bachelor, 311);
        ArrayList exams = new ArrayList();
        ArrayList tests = new ArrayList();
        exams.Add(new Exam("wed-programming", 4, new DateTime(2023, 1, 23)));
        exams.Add(new Exam("system programming", 3, new DateTime(2023, 1, 17)));
        exams.Add(new Exam("english",4, new DateTime(2023, 1, 17)));
        tests.Add(new Test());
        tests.Add(new Test("wed-programming", false));
        tests.Add(new Test("programming", true));

        student.Exam = exams;
        student.Test = tests;

        Console.WriteLine(student.ToString());
        Console.WriteLine(student.Person);
        Student studentCopy = (Student)student.DeepCopy();
        student.Name = "Katya";
        Console.WriteLine(student.ToString());
        Console.WriteLine("\n Копія ----------------\n" + studentCopy.ToString());


        try
        {

            student.Group = 80;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
        }

        foreach (Exam exam in student.GetExamMoreThan(3))
        {
            Console.WriteLine(exam);
        }

        foreach (object examAndTest in student)
        {
            Console.WriteLine(examAndTest);
        }

        foreach (object examAndTest in student.PassedTestsAndExams())
        {
            Console.WriteLine(examAndTest);
        }

        foreach (object examAndTest in student.PassedTestsWithExams())
        {
            Console.WriteLine(examAndTest);
        }
    }
}