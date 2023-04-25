using System;
using System.Collections;
using System.Text;

namespace lab_3
{
	public class StudentCollection
	{
        private List<Student> _students;

        public StudentCollection(List<Student> students)
        {
            _students = students;
        }
        public StudentCollection()
        {
        
        }
        public List<Student> Students {
            get => _students;
            set => _students = value;
        }


        public void AddDefaults()
		{
            Students = new List<Student>();
            Person person1 = new Person("Ivan", "Nivanova", new DateTime(2000, 1, 30));
            Person person2 = new Person("Tanya", "Ivanova", new DateTime(2003, 1, 30));

        
            List<Exam> exams1 = new List<Exam>();
            List<Test> tests1 = new List<Test>();
            exams1.Add(new Exam("wed-programming", 5, new DateTime(2023, 1, 23)));
            exams1.Add(new Exam("english", 3, new DateTime(2023, 1, 17)));

            tests1.Add(new Test("wed-programming", false));
            tests1.Add(new Test("english", true));

            Student student1 = new Student(person1, Education.Bachelor, 311);
            student1.Exam = exams1;
            student1.Test = tests1;

            List<Exam> exams2 = new List<Exam>();
            List<Test> tests2 = new List<Test>();
            exams2.Add(new Exam("programming", 4, new DateTime(2023, 1, 23)));
            exams2.Add(new Exam("german", 5, new DateTime(2023, 1, 17)));

            tests2.Add(new Test("programming", false));
            tests2.Add(new Test("german", true));

            Student student2 = new Student(person2, Education.Master, 301);
            student2.Exam = exams2;
            student2.Test = tests2;

            Students.Add(student1);
            Students.Add(student2);
        }

        public void AddStudents(params Student[] newStudents)
        {
            if (newStudents == null || newStudents.Length==0) { return; }
            if (Students == null) Students = new List<Student> { };
            Students.AddRange(newStudents);
        }

        public override string ToString()
        {
            if (Students==null || Students.Count == 0)
            {
                return "Список студентів порожній";
            }

            StringBuilder stringStudents = new StringBuilder();
            foreach (Student student in Students)
            {
                stringStudents.Append(student.ToString());
            }
            return stringStudents.ToString();

        }

        public  string ToShortString()
        {
            if (Students == null || Students.Count == 0)
            {
                return "Список студентів порожній";
            }

            StringBuilder stringStudents = new StringBuilder();
            foreach (Student student in Students)
            {
                stringStudents.Append(student.ToShortString());
                stringStudents.Append("Кількість екзаменів: " + student.Exam.Count+
                    "Кількість заліків: " + student.Test.Count);
            }
            return stringStudents.ToString();

        }

        public void SortByLastName()
        {
            Students.Sort();
        }

        public void SortByDateOfBirth()
        {
            Students.Sort(new Person().Compare);
        }

        public void SortByAveregaMarks()
        {
            Students.Sort(new Student().Compare);
        }

        public double MaxAveregaMark()
        {
            if (Students == null)
            {
                return 0;
            }
            return Students.Select(i => i.AveregaMarks()).Max();
        }

        public IEnumerable<Student> EducationMaster
        {

            get => Students.Where(education => education.Education == Education.Master);
        }

        public List<Student>? NGroup(double value)
        {
               var groupedStudents = Students?
                .GroupBy(u => u.AveregaMarks())
                .Where(u => u.Key == value)
                .SelectMany(u => u)
                .ToList();
            return groupedStudents;

        }


    }
}

