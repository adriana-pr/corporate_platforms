using System;
using System.Xml.Linq;
using System;
namespace laboratory
{
    public class Person
    {
        private string _name;
        private string _lastName;
        private DateTime _dateOfBirth;

        public Person(string name, string lastName, DateTime dateOfBirth)
        {
            Name = name;
            LastName = lastName;
            DateOfBirth = dateOfBirth;

        }

        public Person():this(name: "Ivan", lastName: "Ivanov", dateOfBirth: new DateTime(2000, 3, 17))
        {
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public int YearOfBirth
        {
            get { return _dateOfBirth.Year; }
            set { _dateOfBirth = new DateTime(value, DateOfBirth.Month, DateOfBirth.Day); }
        }

        public override string ToString()
        {
            return "Person: " + Name + " " + LastName + " " + DateOfBirth;
        }

        public string ToShortString()
        {
            return "Person: " + Name + " " + LastName;
        }

    }
}
