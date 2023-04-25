using System;
namespace lab_4
{
	public class JournalEntry
	{
        public string nameCollection { get; set; }
        public string changeCollection { get; set; }
        public string dataStudent { get; set; }

        public JournalEntry(string NameCollection, string ChangeCollection, string DataStudent)
		{
            nameCollection = NameCollection;
            changeCollection = ChangeCollection;
            dataStudent = DataStudent;

        }

        public override string ToString()
        {
            return "\nname Collection " + nameCollection + " change Collection " + changeCollection + " data Student " + dataStudent;
        }
    }
}

