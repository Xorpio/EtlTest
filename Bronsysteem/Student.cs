using System;
using System.Collections.Generic;
using System.Linq;

namespace Bronsysteem
{
    public class Student
    {
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddelName { get; set; }
        public IList<Lesson> Lessons { get; set; }

        public Student(Guid? guid, string firstName, string lastName, string? middelName, IList<Lesson> lessons)
        {
            Guid = guid ?? Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            MiddelName = middelName;
            Lessons = lessons;
        }
        public Student()
        {
            FirstName = null!;
            LastName = null!;
            Lessons = null!;
        }

        public static Student FromStudentImport(StudentImport studentImport)
        {
            return new Student(
                studentImport.Guid,
                studentImport.FirstName,
                studentImport.LastName,
                studentImport.MiddelName,
                studentImport.Lessons.Split(',')
                    .Select(lessonString => lessonString.Split(':'))
                    .Select(lessonArray => new Lesson(lessonArray[0], Enum.Parse<Locatie>(lessonArray[1])))
                    .ToList()
            );
        }
    }

    public class Lesson
    {
        public Lesson()
        {
            Course = null!;
        }

        public Lesson(string course, Locatie location)
        {
            Course = course;
            Location = location;
        }

        public string Course { get; set; }
        public Locatie Location { get; set; }
    }
}
