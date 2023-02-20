using System;
using System.Xml.Linq;

namespace laboratory
{
	public class Exam
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

    
}
}

