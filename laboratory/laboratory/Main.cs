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
        int nRows, nColumns, countElements=0;
        line = Console.ReadLine();

        nRows = Int32.Parse(line.Split(line[1])[0]);
        nColumns = Int32.Parse(line.Split(line[1])[1]);

        Student[] students = new Student[nRows * nColumns];
        Student[,] studentsTwo = new Student[nRows, nColumns];
        Student[][] studentsToothedArray = new Student[nRows][];

        Exam[] exams = new Exam[2];
        exams[0] = new Exam("wed-programming", 5, new DateTime(2023, 1, 23));
        exams[1] = new Exam("english", 4, new DateTime(2023, 1, 17));

        for (int i = 0; i < nRows * nColumns; i++)
        {
            students[i] = new Student();
            students[i].AddExams(exams);
        }

        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nColumns; j++)
            {
                studentsTwo[i, j] = new Student();
                studentsTwo[i, j].AddExams(exams);
            }
        }

        for (int i = 0; i < nRows; i++)
        {
             studentsToothedArray[i] = new Student[nColumns-i];
              countElements+= studentsToothedArray[i].Length;
        }
        
        if (countElements!= nRows* nColumns)
        {
            countElements = studentsToothedArray[0].Length + (nRows * nColumns - countElements);
            studentsToothedArray[0] = new Student[countElements];
        }

        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < studentsToothedArray[i].Length; j++)
            {
                studentsToothedArray[i][j] = new Student();
                studentsToothedArray[i][j].AddExams(exams);
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

        //Console.WriteLine("\nЗубчастий масив: ");
        //for (int i = 0; i < nRows; i++)
        //{
        //    for (int j = 0; j < studentsToothedArray[i].Length; j++)
        //    {
        //        Console.WriteLine(studentsToothedArray[i][j] + "\n");
        //    }
        //}


        int timeStart = System.Environment.TickCount;
        for (int i = 0; i < nRows * nColumns; i++)
        {
            students[i].AveregaMarks();
        }

        int timeEnd = System.Environment.TickCount;
        int time = timeEnd - timeStart;
        Console.WriteLine("\nЧас виконання одновимірного масиву: " + time);

        timeStart = System.Environment.TickCount;
        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nColumns; j++)
            {
                studentsTwo[i, j].AveregaMarks();

            }
        }
        timeEnd = System.Environment.TickCount;
        time = timeEnd - timeStart;
        Console.WriteLine("\nЧас виконання двовимірного масиву: " + time);

        timeStart = System.Environment.TickCount;
        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < studentsToothedArray[i].Length; j++)
            {
                studentsToothedArray[i][j].AveregaMarks();
            }
        }
        timeEnd = System.Environment.TickCount;
        time = timeEnd - timeStart;
        Console.WriteLine("\nЧас виконання зубчастого масиву: " + time);

    }
}