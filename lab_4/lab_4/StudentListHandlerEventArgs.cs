using System;
using System.Text.RegularExpressions;

namespace lab_4
{
    public class StudentListHandlerEventArgs : EventArgs
    {
        private string nameEvent = default!;
        private string changeType = default!;
        private Student studentChange = default!;

        public string NameEvent
        {
            get { return nameEvent; }
            set
            {
                nameEvent = value;
            }
        }

        public string ChangeType
        {
            get { return changeType; }
            set
            {
                changeType = value;
            }
        }
        public Student StudentChange
        {
            get { return studentChange; }
            set
            {
                studentChange = value;
            }
        }

        public StudentListHandlerEventArgs(string EventList, string ChangeList, Student Student)
        {
            NameEvent = EventList;
            ChangeType = ChangeList;
            StudentChange = Student;
        }

        public override string ToString()
        {
            return "\nName Event " + NameEvent + " ChangeType " + ChangeType + " StudentChange " + StudentChange.ToShortString();
        }

    }
}

