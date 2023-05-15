using System;
using System.Collections;
using System.Collections.Generic;
using lab_4;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;

namespace lab_4;

public class MainTest
{
    public static void Main()
    {

        Person person1 = new Person("Tanya", "Ivanova", new DateTime(2000, 1, 30));
        Person person2 = new Person("Ivan", "Ivanova", new DateTime(2002, 4, 30));
 

        Student student1 = new Student(person1, Education.Bachelor, 311);
        List<Exam> exams1 = new List<Exam>();
        List<Test> tests1 = new List<Test>();
        exams1.Add(new Exam("wed-programming", 4, new DateTime(2023, 1, 23)));
        exams1.Add(new Exam("system programming", 3, new DateTime(2023, 1, 17)));
        exams1.Add(new Exam("english", 4, new DateTime(2023, 1, 17)));
        tests1.Add(new Test("wed-programming", false));
        tests1.Add(new Test("programming", true));

        student1.Exam = exams1;
        student1.Test = tests1;

        Console.WriteLine(student1.ToString());

        Student student2 = new Student(person2, Education.Bachelor, 301);
        List<Exam> exams2 = new List<Exam> { new Exam(), new Exam("wed-programming", 5, new DateTime(2023, 1, 23)) };
        List<Test> tests2 = new List<Test> { new Test(), new Test("programming", true) };
        student2.Exam = exams2;
        student2.Test = tests2;
        Console.WriteLine(student2.ToString());

        Console.WriteLine("--------------------------------");

        //Student studentCopy = student2.DeepCopy();
        //Console.WriteLine($"Копія :\n {studentCopy}");
        //Console.WriteLine("\n----------------");
        //Console.WriteLine($"Оригінал :\n {student1}");

        Console.Write("Введть ім'я файлу: ");
        string fileName = Console.ReadLine()!;

        string filePath = @"/Users/mac/Documents/ПКІС/lab_5/lab_4/" + fileName;

        Console.WriteLine(filePath);
        //Student student = new Student();
        if (File.Exists(filePath))
        {
            Console.WriteLine($"Файл {fileName} вже існує");
            student1.Load(filePath);
        }
        else
        {

            if (string.IsNullOrEmpty(filePath))
            {
                fileName = "studentXML";
            }

            using (FileStream fs = new FileStream(filePath, FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(string.Empty);
            }

            Console.WriteLine($"Створено файл: {fileName}");
        }


        student1.AddFromConsole();
        Console.WriteLine(student1);
        student1.Save(fileName == String.Empty ? "k" : filePath);

        Student.Load(fileName == String.Empty ? "k" : filePath, student1);
        student1.AddFromConsole();
        Student.Save(fileName == String.Empty ? "k" : filePath, student1);


    }

}