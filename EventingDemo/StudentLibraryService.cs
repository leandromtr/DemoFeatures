using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventingDemo
{
    internal class StudentLibraryService
    {
        private readonly StudentEventBroker studentEventBroker;

        public StudentLibraryService(StudentEventBroker studentEventBroker) =>
            this.studentEventBroker = studentEventBroker;

        public void SubscribeToStudentAddEvent() =>
            this.studentEventBroker.Subscribe(CreateStudentLibraryCardAsync);

        public async ValueTask<Student> CreateStudentLibraryCardAsync(Student student)
        {
            Console.WriteLine($"Student {student.Name} Library Card was created!");

            return student;
        }
    }
}