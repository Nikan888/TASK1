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
        private int course, groupNumber, age, entUniver;
        private Mark[] marks;

        public string FirstName { get => firstName; set => firstName = value; }
        public int Course { get => course; set => course = value; }
        public int GroupNumber { get => groupNumber; set => groupNumber = value; }
        public Mark[] Marks { get => marks; set => marks = value; }
        public int Age { get => age; set => age = value; }
        public int EntUniver { get => entUniver; set => entUniver = value; }

        public Student(string firstName, int course, int groupNumber, Mark[] marks, int age, int entUniver)
        {
            this.firstName = firstName;
            this.course = course;
            this.groupNumber = groupNumber;
            this.marks = marks;
            this.age = age;
            this.entUniver = entUniver;
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

        public int GetGraduateYear(params int[] array) //params (2-nd task)
        {
            int gradYear = array[0] + 5 - array[1];
            return gradYear;
        }

        public void CheckMarks(Mark[] marks)
        {
            bool badMark = false;
            foreach (var mark in marks)
            {
                Console.WriteLine(mark.Subject);
                if (mark.SubjectMark >= 4)
                    continue; //continue
                badMark = true;
            }
            if (badMark)
            {
                Console.WriteLine("Student has a bad marks");
            }
            else
            {
                Console.WriteLine("Student has a acceptable marks");
            }
        }

        public void CheckScholarship(out int? scholarship) // out/ref (2-nd task)
        {
            double average = GetAvgMark();
            int scholarGroup = 0;
            try
            {
                if (average < 4)
                    scholarGroup = 0;
                else if (average >= 4 && average < 5)
                    scholarGroup = 1;
                else if (average >= 5 && average < 8)
                    scholarGroup = 2;
                else if (average == 0)
                    throw new CustomException("Marks are not exist for this student or it's nulled");
                else scholarGroup = 3;
            }
            catch (CustomException ex) { Console.WriteLine(ex.Message); }

            switch (scholarGroup) // goto (2-nd task)
            {
                case 0:
                    goto default;
                case 1:
                    scholarship = 40;
                    break;
                case 2:
                    scholarship = 60;
                    break;
                case 3:
                    scholarship = 80;
                    break;
                default:
                    scholarship = null;
                    Console.WriteLine("Expelling is coming");
                    break;
            }
        }
    }
}
