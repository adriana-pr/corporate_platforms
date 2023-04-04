using System;
using System.Xml.Linq;
using System;
using lab_2;

namespace laboratory
{
    public class Person: IDateAndCopy
    {
        protected string _name;
        protected string _lastName;
        protected DateTime _dateOfBirth;

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


        public virtual bool Equals(object? obj)
        {
            if (obj == null || !(obj is Person))
            {
                return false;
            }

            return (this.Name == ((Person)obj).Name)
                && (this.LastName == ((Person)obj).LastName)
            && (this.DateOfBirth == ((Person)obj).DateOfBirth);
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return person1.Equals(person2);
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return !person1.Equals(person2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, LastName, DateOfBirth);
        }

        public virtual object DeepCopy()
        {
            Person tempPerson = new Person();
            tempPerson.Name = Name;
            tempPerson.LastName = LastName;
            tempPerson.DateOfBirth = DateOfBirth;
            return tempPerson;
        }
    }


}
