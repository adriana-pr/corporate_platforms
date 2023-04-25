using System;
using System.IO;

namespace lab_4
{
	public class TestCollections
	{
		public TestCollections()
		{
		}

        private List<Person> _person = new List<Person>();
        private List<string> _string = new List<string>();
        private Dictionary<Person, Student> _personStudent = new Dictionary<Person, Student>();
        private Dictionary<string, Student> _stringStudent = new Dictionary<string, Student>();

        public List<Person> PersonList {
            get => _person;
            init => _person = value;
        }
        public List<string> StringList {
            get => _string;
            init => _string = value;
        }
        public Dictionary<Person, Student> PersonStudent
        {
            get => _personStudent;
            init => _personStudent = value;
        }
        public Dictionary<string, Student> StringStudent
        {
            get => _stringStudent;
            init => _stringStudent = value;
        }

        public TestCollections(int n)
        {
            PersonList = new List<Person>(n);
            StringList = new List<string>(n);
            PersonStudent = new Dictionary<Person, Student>(n);
            StringStudent = new Dictionary<string, Student>(n);
        }


        public static TestCollections CreateCollection(int n)
        {
            var collection = new TestCollections(n);

            for (int i = 1; i < n; i++)
            {
                Person  person = new Person("name"+i, "lastName"+i, new DateTime(1990+i, 0+i, 0+i));
                Student student = new Student(person, Education.Master, 300 + i);

                
                collection.PersonList.Add(person);
                collection.StringList.Add(person.Name.ToString());
                collection.PersonStudent.Add(person, student);
                collection.StringStudent.Add(person.Name.ToString(), student);
            }
            return collection;
        }


        public void TimeSearching(Person person, string str, Student student)
        {
            int start = Environment.TickCount;
            bool isFound = PersonList.Contains(person);
            int duration = Environment.TickCount - start;
            Console.WriteLine($"PersonList, Час пошуку елемента: {duration}. Чи є елемент: {isFound}");

            start = Environment.TickCount;
            isFound = StringList.Contains(str);
            duration = Environment.TickCount - start;
            Console.WriteLine($"StringList, Час пошуку елемента:  {duration}. Чи є елемент: {isFound}");

            start = Environment.TickCount;
            isFound = PersonStudent.ContainsKey(person);
            duration = Environment.TickCount - start;
            Console.WriteLine($"Dictionary<Person, Student>, Час пошуку елемента:  {duration}. Чи є елемент: {isFound}");

            start = Environment.TickCount;
            isFound = StringStudent.ContainsKey(str);
            duration = Environment.TickCount - start;
            Console.WriteLine($"Dictionary<string, ResearchTeam>,Час пошуку елемента:  {duration}. Чи є елемент: {isFound}");
        }

    }


}


