using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace laboratory;

public class Test
{
    public static void Main()
    {
        //Student student = new Student();
        //Console.WriteLine(student.ToShortString());
        //Console.WriteLine("Education.Master " + student[Education.Master]);
        //Console.WriteLine("Education.Bachelor " + student[Education.Bachelor]);
        //Console.WriteLine("Education.SecondEducation " + student[Education.SecondEducation]);

        //Person person = new Person("Tanya", "Ivanova", new DateTime(2000, 1, 30));
        //Student student2 = new Student(person, Education.Bachelor, 311);
        //Console.WriteLine(student2.ToString());
        //Exam[] exams = new Exam[2];
        //exams[0] = new Exam("wed-programming", 4, new DateTime(2023, 1, 23));
        //exams[1] = new Exam("english",4, new DateTime(2023, 1, 17));

        //student2.addExams(exams);
        //Console.WriteLine(student2.ToString());


        Console.WriteLine("Ведіть кількість рядків і стовпців, числа розділені пробілом.");
        string line;
        int nRows, nColumns;
        line = Console.ReadLine();

        nRows = Int32.Parse(line.Split(' ')[0]);
        nColumns = Int32.Parse(line.Split(' ')[1]);

        Student[] students = new Student[nRows * nColumns];
        Student[,] studentsTwo = new Student[nRows, nColumns];
        Exam[] exams = new Exam[2];
        exams[0] = new Exam("wed-programming", 4, new DateTime(2023, 1, 23));
        exams[1] = new Exam("english", 4, new DateTime(2023, 1, 17));

        for (int i = 0; i < nRows * nColumns; i++)
        {
            students[i] = new Student();
            students[i].addExams(exams);
        }

        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nColumns; j++)
            {
                studentsTwo[i, j] = new Student();
                studentsTwo[i, j].addExams(exams);
            }
        }

        //Console.WriteLine("\nОдновимірний масив: ");
        //for (int i = 0; i < nRows * nColumns; i++)
        //{
        //    Console.WriteLine(students[i]);
        //}

        //Console.WriteLine("\nДвовимірний масив: ");
        //for (int i = 0; i < nRows; i++)
        //{
        //    for (int j = 0; j < nColumns; j++)
        //    {
        //        Console.WriteLine(studentsTwo[i, j]);
        //    }
        //}

        int timeStart = System.Environment.TickCount;
        for (int i = 0; i < nRows * nColumns; i++)
        {
            students[i].averegaMarks(students[i].Exam);
        }
        int timeEnd = System.Environment.TickCount;
        int time = timeEnd - timeStart;

        Console.WriteLine("\nЧас виконання одновимірного масиву: " + time);

        timeStart = System.Environment.TickCount;
        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nColumns; j++)
            {
                studentsTwo[i, j].averegaMarks(studentsTwo[i, j].Exam);
            }
        }
        timeEnd = System.Environment.TickCount;
        time = timeEnd - timeStart;
        Console.WriteLine("\nЧас виконання диовимірного масиву: " + time);

    }
}