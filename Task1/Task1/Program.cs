using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Input students count");
                int n = 0;
                do
                {
                    n = Convert.ToInt32(Console.ReadLine());
                } while (!CheckOnNegativity(n));
                Student[] students = new Student[n];
                for (int i = 0; i < n; i++)
                {
                    students[i] = InputStudent();
                }
                bool exit = false;
                while (!exit)
                {

                    Console.Clear();
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Output student's average mark");
                    Console.WriteLine("2. Output personal info about student");
                    Console.WriteLine("3. Reset all marks");
                    Console.WriteLine("0. Exit");
                    int select = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (select)
                    {
                        case 1:
                            {
                                Console.WriteLine("Input student's number");
                                int stdntNmbr = 0;
                                do
                                {
                                    stdntNmbr = Convert.ToInt32(Console.ReadLine());
                                } while (!CheckStudent(students, stdntNmbr));
                                double average = students[stdntNmbr - 1].GetAvgMark();
                                Console.WriteLine("Average mark: " + average);
                                Console.WriteLine("Press any button to contunue");
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Input student's number");
                                int stdntNmbr = 0;
                                do
                                {
                                    stdntNmbr = Convert.ToInt32(Console.ReadLine());
                                } while (!CheckStudent(students, stdntNmbr));
                                Console.WriteLine("First name: " + students[stdntNmbr - 1].FirstName);
                                Console.WriteLine("Course: " + students[stdntNmbr - 1].Course);
                                Console.WriteLine("Group number: " + students[stdntNmbr - 1].GroupNumber);
                                Console.WriteLine("Press any button to contunue");
                                Console.ReadKey();
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Input student's number");
                                int stdntNmbr = 0;
                                do
                                {
                                    stdntNmbr = Convert.ToInt32(Console.ReadLine());
                                } while (!CheckStudent(students, stdntNmbr));
                                students[stdntNmbr - 1].ResetAllMarks();
                                Console.WriteLine("All marks were deleted");
                                Console.WriteLine("Press any button to contunue");
                                Console.ReadKey();
                                break;
                            }
                        case 0:
                            {
                                Console.Clear();
                                Console.WriteLine("Thank u for using this software. Good luck!");
                                Console.WriteLine("Press any button to exit");
                                Console.ReadKey();
                                exit = true;
                                break;
                            }
                        default: break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        static Student InputStudent()
        {
            Console.Clear();
            Console.WriteLine("Input student's first name");
            string fam = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Input student's course");
            int course = 0;
            do
            {
                course = Convert.ToInt32(Console.ReadLine());
                CheckCourse(course);
            } while (!CheckCourse(course));
            Console.WriteLine("Input student's number of group");
            int group = 0;
            do
            {
                group = Convert.ToInt32(Console.ReadLine());
                CheckOnNegativity(group);
            } while (!CheckOnNegativity(group));
            Console.WriteLine("Input marks count:");
            int n = 0;
            do
            {
                n = Convert.ToInt32(Console.ReadLine());
                CheckOnNegativity(n);
            } while (!CheckOnNegativity(n));
            Mark[] marks = new Mark[n];
            for (int i = 0; i < n; i++)
            {
                marks[i] = InputMark();
            }
            return (new Student(fam, course, group, marks));
        }

        static Mark InputMark()
        {
            Console.WriteLine("Input subject name");
            string name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Input subject mark");
            int mark = 0;
            do
            {
                mark = Convert.ToInt32(Console.ReadLine());
                CheckOnNegativity(mark);
            } while (!CheckOnNegativity(mark));
            return (new Mark(name, mark));
        }

        static bool CheckCourse(int course)
        {
            if (course < 1 || course > 5)
            {
                Console.WriteLine("Course vaule must be from 1 to 5. Re-check your input data.");
                return false;
            }
            else
                return true;
        }

        static bool CheckOnNegativity(int number)
        {
            if (number <= 0)
            {
                Console.WriteLine("Value must be more than 0");
                return false;
            }
            return true;
        }

        static bool CheckStudent(Student[] students, int number)
        {
            if (number < 1 || number > students.Length)
            {
                Console.WriteLine("The entered number doesn't fit. " +
                    "Enter the number from 1 to " + students.Length);
                return false;
            }
            return true;
        }
    }
}
