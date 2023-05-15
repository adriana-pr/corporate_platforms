using lab_4;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace lab_4
{
	public class StudentEnumerator: IEnumerator
    {
        private ArrayList _examsAndTests;
        int position = -1;

        public StudentEnumerator(Student student)
		{
            _examsAndTests = new ArrayList();
            foreach (Exam exam in student.Exam)
                {
                foreach (Test test in student.Test)
                {
                    if (exam.NameSubject.Equals(test.NameSubject))
                    {
                        _examsAndTests.Add(exam);
                        _examsAndTests.Add(test);
                    }
                }
            }
        }
      
        public object Current
        {
            get
            {
             return _examsAndTests[position];
            }
        }


        bool IEnumerator.MoveNext()
        {
            position++;
            return (position < _examsAndTests.Count);
        }

        void IEnumerator.Reset()
        {
            position = -1;
        }
    }
}

