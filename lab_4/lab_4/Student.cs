using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Xml.Linq;
using lab_4;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab_4
{
    public class Student: Person, IDateAndCopy, IEnumerable, IComparer<Student>
    {
        private Education _education;
        private int _group;
        private List<Exam> _exam;
        private List<Test> _test;

        public Student( Person person, Education education, int group):base(person.Name, person.LastName, person.DateOfBirth)
        {
            Education = education;
            Group = group;
        }

        public Student() : this(person: new Person(), education: new Education(), group: 311)
        {

        }
        public Education Education
        {
            get { return _education; }
            set
            {
                _education = value;
            }
        }

        public int Group
        {
            get { return _group; }
            set
            {
                if (value<=100 || value > 699)
                {
                    throw new ArgumentException("Group value must be between 100 and 699");
                }
                _group = value;
            }
        }

        public Person Person
        {
            get { return (Person)base.DeepCopy(); }
            
        }

        public List<Exam> Exam
        {

            get { return _exam; }
            set
            {
                _exam = value;
            }
        }
        public List<Test> Test
        {

            get { return _test; }
            set
            {
                _test = value;
            }
        }

        public bool this[Education index]
        {
            get { return Education == index; }
        }

        public override string ToString()
        {
            if (Exam == null && Test == null)
                return "Student: \n" + base.ToString() + " \n" + Education + " \n" + Group;

            string examsString = string.Empty;
            foreach (Exam element in Exam)
            {
                examsString += element.ToString();

            }
            examsString +="\n";
            foreach (Test element in Test)
            {
                examsString += element.ToString();

            }

            return "\nStudent: \n" + base.ToString() + " \n" + Education + " \n" + Group+ " \n" + examsString;
        }

        public new string ToShortString()
        {
            return "Student: \n" + base.ToShortString() + " \n" + Education + " \n" + Group + " \n" + AveregaMarks();
        }

        public double AveregaMarks()
        {
            if (Exam == null)
                return 0;

             int sumMarks =0;
      
            foreach (Exam exam in Exam)
            {
                sumMarks += exam.Mark;
            }
            return ((double)sumMarks/ (double)Exam.Count);
        }


        public void AddExams(Exam[] examsNew)
        {
            if (Exam != null)
            {
                int n = Exam.Count;
                Exam[] examsArray = new Exam[n];

                for (int i = 0; i < n; i++)
                {
                    examsArray[i] = (Exam)Exam[i];
                }
                Exam = new List<Exam>();

                for (int i = 0; i < examsArray.Length; i++)
                {
                    Exam[i] = examsArray[i];
                }

                for (int i = 0; i < examsNew.Length; i++)
                {
                    Exam[i + n] = examsNew[i];
                }
            }

            else
            {
                Exam = new List<Exam>();
                for (int i = 0; i < examsNew.Length; i++)
                {
                    Exam[i] = examsNew[i];
                }
            }
        }


        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Student))
            {
                return false;
            }
            return (base.Equals( obj))
                && (this.Education == ((Student)obj).Education)
            && (this.Group == ((Student)obj).Group);
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return student1.Equals(student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !student1.Equals(student2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Education, Group);
        }


        public override object DeepCopy()
        {
            Person person = (Person)base.DeepCopy();
            Student tempstudent = new Student(person, Education, Group);
            if (Exam != null)
            {
                List<Exam> examsArray = new List<Exam>();
                foreach (Exam exam in Exam)
                {
                    examsArray.Add(exam);
                }
                tempstudent.Exam = examsArray;
            }
            if (Test != null)
            {
                List<Test> testsArray = new List<Test>();
                foreach (Test test in Test)
                {
                    testsArray.Add(test);
                }
                tempstudent.Test = testsArray;
            }
            return tempstudent;
        }


        public IEnumerable GetExamsAndTests()
        {

            if (Exam != null)
            {
                foreach (Exam exam in Exam)
                {
                    yield return exam;
                }
            }
            if (Test != null)
            {
                foreach (Test test in Test)
                {
                    yield return test;
                }
            }
        }

        public IEnumerable GetExamMoreThan(int mark)
        {

            if (Exam != null)
            {
                foreach (Exam exam in Exam)
                {
                    if(exam.Mark > mark)
                    yield return exam;
                }
            }
        }


        public IEnumerator GetEnumerator()
        {
            return new StudentEnumerator(this);
        }


        public IEnumerable PassedTestsAndExams()
        {
            if (Exam != null)
            {
                foreach (Exam exam in Exam)
                {
                    if (exam.Mark > 2)
                        yield return exam;
                }
            }
            if (Test != null)
            {
                foreach (Test test in Test)
                {
                    if (test.Credit == true)
                        yield return test;
                }
            }
        }

        public IEnumerable PassedTestsWithExams()
        {
            if (Test != null)
            {
                foreach (Test test in Test)
                {
                    foreach (Exam exam in Exam)
                    {
                        if (exam.NameSubject.Equals(test.NameSubject))
                            if(exam.Mark > 2 && test.Credit == true)
                            yield return test;
                    }
                }
            }
        }

        public int Compare(Student? x, Student? y)
        {
            if (x == null) return -1;
            if (y == null) return 1;
            if (x == null && y == null) return 0;
            return x.AveregaMarks().CompareTo(y.AveregaMarks()); ;
        }

    }


}

