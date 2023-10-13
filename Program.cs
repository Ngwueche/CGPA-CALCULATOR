using System;
using System.Collections.Generic;




class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter student name: ");
        string studentName = Console.ReadLine();

        Console.Write("Enter the number of subjects: ");
        int numSubjects = int.Parse(Console.ReadLine());

        Student student = new Student { Name = studentName };

        for (int i = 1; i <= numSubjects; i++)
        {
            Console.Write($"Enter the name of subject {i}: ");
            string subjectName = Console.ReadLine().ToUpper();

            Console.Write($"Enter the score for subject {subjectName}: ");
            double subjectScore = double.Parse(Console.ReadLine());

            Console.Write($"Enter the Unit for subject {subjectName}: ");
            double subjectUnit = double.Parse(Console.ReadLine());

            student.Subjects.Add(new Subject { Name = subjectName, Score = subjectScore, Unit = subjectUnit });
        }

        Console.WriteLine("Student Report:");

        Console.WriteLine("Subject\t\tScore\tGrade\tUnit Load");

        foreach (var subject in student.Subjects)
        {
            char grade = GPAcalculator.GetGrade(subject.Score);
            Console.WriteLine($"{subject.Name}\t\t{subject.Score}\t{grade}\t{subject.Unit}");
        }

        Console.WriteLine();

        GPAcalculator.CalculateGPA(student);
    }

    class Subject
    {
        public string Name;
        public double Score;
        public double Unit;
    }

    class Student
    {
        public string Name;
        public List<Subject> Subjects;
        public Student()
        {
            Subjects = new List<Subject>();
        }
    }

    class GPAcalculator
    {

        public static void CalculateGPA(Student student)
        {
            double totalScore = 0;
            double totalCredits = 0;

            foreach (var subject in student.Subjects)
            {
                double TQP = Getpoint(subject.Score) * subject.Unit;
                totalScore += TQP;
                totalCredits += subject.Unit;

            }

            double gpa = totalScore / totalCredits;

            Console.WriteLine($"GPA: {gpa:F2}");
        }


        public static char GetGrade(double score)
        {
            if (score >= 70)
                return 'A';
            else if (score >= 69)
                return 'B';
            else if (score >= 59)
                return 'C';
            else if (score >= 49)
                return 'D';
            else if (score >= 39)
                return 'E';
            else
                return 'F';
        }
        public static double Getpoint(double point)
        {
            if (point >= 70)
                return 5;
            else if (point >= 69)
                return 4;
            else if (point >= 59)
                return 3;
            else if (point >= 49)
                return 2;
            else if (point >= 39)
                return 1;
            else
                return 0;
        }

    }
}
