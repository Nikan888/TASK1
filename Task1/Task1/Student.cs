using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Student
    {
        private string firstName;
        private int course;
        private int groupNumber;
        private Mark[] marks;

        public string FirstName { get => firstName; set => firstName = value; }
        public int Course { get => course; set => course = value; }
        public int GroupNumber { get => groupNumber; set => groupNumber = value; }
        public Mark[] Marks { get => marks; set => marks = value; }

        public Student(string firstName, int course, int groupNumber, Mark[] marks)
        {
            this.firstName = firstName;
            this.course = course;
            this.groupNumber = groupNumber;
            this.marks = marks;
        }

        public double GetAvgMark()
        {
            double average = 0, sum = 0;
            if (Marks.Length > 0)
            {
                foreach (var mark in Marks) { sum += mark.SubjectMark; }
                average = sum / Marks.Length;
            }
            else Console.WriteLine("Mark array is empty.");
            return average;
        }

        public void ResetAllMarks()
        {
            foreach (var mark in Marks) { mark.SubjectMark = 0; }
        }
    }
}
