using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Mark
    {
        private string subject;
        private int subjectMark;

        public string Subject { get => subject; set => subject = value; }
        public int SubjectMark { get => subjectMark; set => subjectMark = value; }

        public Mark(string subject, int subjectMark)
        {
            this.subject = subject;
            this.subjectMark = subjectMark;
        }
    }
}
