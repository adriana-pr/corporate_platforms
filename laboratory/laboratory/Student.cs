using System;
using System.Drawing;
using System.Xml.Linq;

namespace laboratory
{
    public class Student
    {
        private Person _person;
        private Education _education;
        private int _group;
        private Exam[] _exam;

        public Student( Person person, Education education, int group)
        {
            Person = person;
            Education = education;
            Group = group;

            Exam = new Exam[1];
            Exam[0] = new Exam();
        }

        public Student() : this(person: new Person(), education: new Education(), group: 311)
        {

        }

        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
            }
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
                _group = value;
            }
        }

        public Exam[] Exam
        {

            get { return _exam; }
            set
            {
                _exam = value;
            }
        }

        public bool this[Education index]
        {
            get { return Education == index; }
        }

        public override string ToString()
        {
            string examsString = string.Empty;
            foreach (Exam element in Exam)
            {
                    examsString += element.ToString();

            }

            return "Student: \n" + Person + " \n" + Education + " \n" + Group+ " \n" + examsString;
        }

        public string ToShortString()
        {
            return "Student: \n" + Person + " \n" + Education + " \n" + Group + " \n" + averegaMarks(Exam);
        }

        public double averegaMarks(Exam []exams)
        {
            int sumMarks=0;
      
            for (int i=0; i< exams.Length;i++)
            {
                sumMarks += exams[i].Mark;
            }
            return ((double)sumMarks/ (double)exams.Length);
        }

        public void addExams(Exam[] examsNew)
        {
            int n = Exam.Length;
            Exam[] examsArray = new Exam[n];

            for (int i = 0; i < n; i++)
            {
                examsArray[i] = Exam[i];
            }

            Exam = new Exam[examsNew.Length + n];

            for (int i = 0; i < examsArray.Length; i++)
            {
                Exam[i] = examsArray[i];
            }

            for (int i = 0; i < examsNew.Length; i++)
            {
                Exam[i + n] = examsNew[i];
            }
        }
    }

}

