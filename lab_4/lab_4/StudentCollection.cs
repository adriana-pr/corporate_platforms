using System;
using System.Collections;
using System.Text;

namespace lab_4
{
	public class StudentCollection
	{
        private List<Student> _students = default!;

        public delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);
        public string NameCollection { get; set; } = default!;

        public event StudentListHandler StudentCountChanged = default!;
        public event StudentListHandler StudentReferenceChanged = default!;

        public StudentCollection(List<Student> students)
        {
            _students = students;
        }

        public StudentCollection( string name)
        {
            NameCollection = name;
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
            Person person3 = new Person("Katya", "Ivanova", new DateTime(2003, 1, 30));


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

            Student student3 = new Student(person3, Education.Master, 301);
            student3.Exam = exams1;
            student3.Test = tests1;

            Students.Add(student1);
            Students.Add(student2);
            Students.Add(student3);

            StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(NameCollection, "added element", student1));
            StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(NameCollection, "added element", student2));
            StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(NameCollection, "added element", student3));

        }

        public void AddStudents(params Student[] newStudents)
        {
            if (Students == null) Students = new List<Student> { };
            if (newStudents == null) { return; }
            foreach (Student student in newStudents)
            {
                Students.Add(student);
                StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(NameCollection, "added element", student));

            }


        }

        public override string ToString()
        {
            if (Students==null)
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
            if (Students == null)
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

        public bool Remove(int index)
        {
            if (index >= Students.Count)
            {
                return false;
            }
            Student student = Students[index];
            Students.RemoveAt(index);
            StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(NameCollection, "removed element", student));
            return true;
        }

        public Student this[int index]
        {
            get { return Students[index]; }
            set
            {
                Students[index] = value;
                StudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(NameCollection, "changed element", Students[index]));

            }
        }

    }
}

