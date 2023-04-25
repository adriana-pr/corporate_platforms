using System;
using System.Collections;
using lab_3;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab_3;

public class MainTest
{
    public static void Main()
    {

        StudentCollection students = new StudentCollection();
        students.AddDefaults();
        students.AddDefaults();
        students.AddDefaults();
        students.AddDefaults();
        Console.WriteLine(students);

        students.SortByLastName();
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Сортування за прізвищем: ");
        Console.WriteLine(students);
        Console.WriteLine("-------------------------------------");

        students.SortByDateOfBirth();
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Сортування за датою: ");
        Console.WriteLine(students);
        Console.WriteLine("-------------------------------------");

        students.SortByAveregaMarks();
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Сортування за середнім балом: ");
        Console.WriteLine(students);
        Console.WriteLine("-------------------------------------\n\n");

        Console.WriteLine("Максимальний середній бал: " + students.MaxAveregaMark());
        Console.WriteLine("-------------------------------------\n");


        Console.WriteLine("\nФорма навчання Education Master:");
        IEnumerable<Student> educationMaster = students.EducationMaster;
        foreach (Student student in educationMaster)
        {
            Console.WriteLine(student);
        }
        Console.WriteLine("-------------------------------------\n");

        Console.WriteLine("\nГрупування: ");
        //IEnumerable<Student> nGroup = students.NGroup(4.5);
        foreach (Student student in students.NGroup(4))
        {
            Console.WriteLine(student);
        }
        Console.WriteLine("-------------------------------------\n\n");


        TestCollections test = TestCollections.CreateCollection(6);
        Console.WriteLine("Перший елемент:");
        test.TimeSearching(test.PersonList[0], test.PersonList[0].Name, test.PersonStudent[test.PersonList[0]]);
        Console.WriteLine("-------------------------------------\n\n");

        int i = test.PersonList.Count / 2;
        Console.WriteLine("Центральний елемент:");
        test.TimeSearching(test.PersonList[i], test.PersonList[i].Name, test.PersonStudent[test.PersonList[i]]);
        Console.WriteLine("-------------------------------------\n\n");

        int k = test.PersonList.Count-1;
        Console.WriteLine("Останній елемент:");
        test.TimeSearching(test.PersonList[k], test.PersonList[k].Name, test.PersonStudent[test.PersonList[k]]);
        Console.WriteLine("-------------------------------------\n\n");

        Console.WriteLine("Неіснуючий елемент:");
        test.TimeSearching(new Person("name","name",new DateTime(1990, 01, 01)), "name-1", new Student());
        Console.WriteLine("-------------------------------------\n\n");
    }

}