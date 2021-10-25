using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> studets = new List<Student>();

        public Classroom(int capacity)
        {
            Capacity = capacity;
        }

        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return studets.Count;
            }
        }

        public List<Student> Students { get => studets; set => studets = value; }

        public string RegisterStudent(Student student)
        {
            if (Students.Count < Capacity)
            {
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }
        public string DismissStudent(string firstName, string lastName)
        {
            var returnedStudent = Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (Students.Contains(returnedStudent))
            {
                Students.Remove(returnedStudent);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            if (Students.Any(x => x.Subject == subject))
            {
                Console.WriteLine($"Subject: {subject}");

                foreach (var item in Students.Where(x => x.Subject == subject))
                {
                    return $"{item.FirstName} {item.LastName}";
                }
            }

            return "No students enrolled for the subject";

        }
        public int GetStudentsCount()
        {
            return Students.Count();
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
