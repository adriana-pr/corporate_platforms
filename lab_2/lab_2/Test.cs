﻿using System;
using System.Xml.Linq;
using lab_2;
using laboratory;

namespace lab_2
{
	public class Test
	{
        private string _nameSubject;
        private bool _credit;

        public Test(string name, bool credit)
        {
            NameSubject = name;
            Credit = credit;

        }

        public Test() : this(name: "english", credit: true)
        {
        }

        public string NameSubject
        {
            get { return _nameSubject; }
            set { _nameSubject = value; }
        }

        public bool Credit
        {
            get { return _credit; }
            set { _credit = value; }
        }

        public override string ToString()
        {
            return "\nTest: " + NameSubject + " " + Credit;
        }

        public static bool operator ==(Test test1, Test test2)
        {
            return test1.Equals(test2);
        }

        public static bool operator !=(Test test1, Test test2)
        {
            return !test1.Equals(test2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NameSubject, Credit);
        }
    }

}

