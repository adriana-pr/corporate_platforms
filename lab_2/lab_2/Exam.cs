using System;
using System.Xml.Linq;
using lab_2;

namespace laboratory
{
	public class Exam: IDateAndCopy
    {
		private string _nameSubject;
		private int _mark;
        private DateTime _dateExam;

        public Exam(string nameSubject, int mark, DateTime dateExam)
        {
            NameSubject = nameSubject;
            Mark = mark;
            DateExam = dateExam;

        }

        public Exam():this(nameSubject: "math", mark: 5, dateExam: new DateTime(2023, 1, 17))
        {
        }

        public string NameSubject
        {
            get { return _nameSubject; }
            set { _nameSubject = value; }
        }

        public int Mark
        {
            get { return _mark; }
            set { _mark = value; }
        }

        public DateTime DateExam
        {
            get { return _dateExam; }
            set { _dateExam = value; }
        }

        public override string ToString()
        { 
            return "Exam: " + "\nname: " + NameSubject + "\nmark: "+ Mark + "\ndate: " + DateExam;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Exam))
            {
                return false;
            }

            return (this.NameSubject == ((Exam)obj).NameSubject)
                && (this.Mark == ((Exam)obj).Mark)
                && (this.DateExam == ((Exam)obj).DateExam);
        }

        public static bool operator ==(Exam exam1, Exam exam2)
        {
            return exam1.Equals(exam2);
        }

        public static bool operator !=(Exam exam1, Exam exam2)
        {
            return !exam1.Equals(exam2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NameSubject, Mark, DateExam);
        }

        public object DeepCopy()
        {
            Exam tempExam = new Exam();
            tempExam.NameSubject = NameSubject;
            tempExam.Mark = Mark;
            tempExam.DateExam = DateExam;
            return tempExam;
        }

    }
}

