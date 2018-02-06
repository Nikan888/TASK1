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
                int n = CheckOnNegativity();
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
                                int stdntNmbr = CheckStudent(students);
                                double average = students[stdntNmbr - 1].GetAvgMark();
                                Console.WriteLine("Average mark: " + average);
                                Console.WriteLine("Press any button to contunue");
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Input student's number");
                                int stdntNmbr = CheckStudent(students);
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
                                int stdntNmbr = CheckStudent(students);
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
            int course = CheckCourse();
            Console.WriteLine("Input student's number of group");
            int group = CheckOnNegativity();
            Console.WriteLine("Input marks count:");
            int n = CheckOnNegativity();
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
            int mark = CheckOnNegativity();
            return (new Mark(name, mark));
        }

        static int CheckCourse()
        {
            int course = 0;
            do
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out course))
                {
                    if (course < 1 || course > 5)
                        Console.WriteLine("Course vaule must be from 1 to 5. Re-check your input data");
                }
                else
                    Console.WriteLine("Course must be int32. Please try again.");
            } while (course < 1 || course > 5);
            return course;
        }

        static int CheckOnNegativity()
        {
            int i = 0;
            do
            {
                var input = Console.ReadLine();
                try
                {
                    int.TryParse(input, out i);
                    if (i <= 0)
                    {
                        Console.WriteLine("Value must be more than 0");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Value must be Int32");
                }
            } while (i <= 0);
            return i;
        }

        static int CheckStudent(Student[] students)
        {
            int number = 0;
            do
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    if (number < 1 || number > students.Length)
                        Console.WriteLine("The entered number doesn't fit. " +
                            "Enter the number from 1 to " + students.Length);
                }
                else
                    Console.WriteLine("Number must be int32. Please try again.");
            } while (number < 1 || number > students.Length);
            return number;
        }
    }
}