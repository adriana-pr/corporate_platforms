using System;
using System.Collections;
using lab_4;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab_4;

public class MainTest
{
    public static void Main()
    {

        StudentCollection students1 = new StudentCollection("students1");
        StudentCollection students2 = new StudentCollection("students2");
       
        Journal journal1 = new Journal();
        Journal journal2 = new Journal();

        students1.StudentCountChanged += journal1.StudentCountChanged;
        students1.StudentCountChanged += journal1.StudentReferenceChanged;

        students1.StudentCountChanged += journal2.StudentCountChanged;
        students1.StudentCountChanged += journal2.StudentReferenceChanged;
        students2.StudentCountChanged += journal2.StudentCountChanged;
        students2.StudentCountChanged += journal2.StudentReferenceChanged;


        students1.AddDefaults();
        students2.AddDefaults();

        students1.Remove(0);
        students2.Remove(1);

        //students1[0]= new Student();
        //students2[1] = new Student();

        Console.WriteLine(journal1);
        Console.WriteLine("\n---------------------------------\n");
        Console.WriteLine(journal2);

    }

}