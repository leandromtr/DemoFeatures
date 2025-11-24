using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventingDemo
{
    internal class PAStudentService
    {
        private readonly StudentEventBroker studentEventBroker;

        public PAStudentService(StudentEventBroker studentEventBroker) =>
            this.studentEventBroker = studentEventBroker;

        public void SubscribeToStudentAddEvent() =>
            this.studentEventBroker.Subscribe(CreateStudentPARecordAsync);

        public async ValueTask<Student> CreateStudentPARecordAsync(Student student)
        {
            Console.WriteLine($"Student {student.Name} PA Record was created!");

            return student;
        }
    }
}