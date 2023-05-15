using System;
using System.Text.RegularExpressions;
using static lab_4.StudentCollection;

namespace lab_4
{
	public class Journal
	{
		private List<JournalEntry> journalEntry = new List<JournalEntry>();


        public void StudentCountChanged(object source, StudentListHandlerEventArgs args)
        {
            journalEntry.Add( new JournalEntry(args.NameEvent, args.ChangeType, args.StudentChange.ToString()));
        }
        public void  StudentReferenceChanged(object source, StudentListHandlerEventArgs args)
        {
            journalEntry.Add(new JournalEntry(args.NameEvent, args.ChangeType, args.StudentChange.ToString()));

        }

        public override string ToString()
        {

            string str = string.Empty;
            foreach (JournalEntry journal in journalEntry)
            {
                str += journal + "\n";

            }
           
            return "\nJournal: \n" + str;
        }

    }
}

