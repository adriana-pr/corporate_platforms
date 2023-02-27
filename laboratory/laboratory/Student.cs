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
            if (Exam == null)
                return "Student: \n" + Person + " \n" + Education + " \n" + Group;

            string examsString = string.Empty;
            foreach (Exam element in Exam)
            {
                examsString += element.ToString();

            }

                return "Student: \n" + Person + " \n" + Education + " \n" + Group+ " \n" + examsString;
        }

        public string ToShortString()
        {
            return "Student: \n" + Person + " \n" + Education + " \n" + Group + " \n" + AveregaMarks();
        }

        public double AveregaMarks()
        {
            if (Exam == null)
                return 0;

             int sumMarks =0;
      
            for (int i=0; i< Exam.Length;i++)
            {
                sumMarks += Exam[i].Mark;
            }
            return ((double)sumMarks/ (double)Exam.Length);
        }


        public void AddExams(Exam[] examsNew)
        {
            if (Exam != null)
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

            else
            {
                Exam = new Exam[examsNew.Length];
                for (int i = 0; i < examsNew.Length; i++)
                {
                    Exam[i] = examsNew[i];
                }
            }
        }
    }

}

