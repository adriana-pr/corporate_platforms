using System;
using System.Text.RegularExpressions;

namespace lab_4
{
    public class StudentListHandlerEventArgs : EventArgs
    {
        public string nameEvent;
        public string changeType;
        public Student studentChange;

        public StudentListHandlerEventArgs(string EventList, string ChangeList, Student StudentChange)
        {
            nameEvent = EventList;
            changeType = ChangeList;
            studentChange = StudentChange;
        }

        public override string ToString()
        {
            return "\nName Event " + nameEvent + " ChangeType " + changeType + " StudentChange " + studentChange.ToShortString();
        }

    }
}

