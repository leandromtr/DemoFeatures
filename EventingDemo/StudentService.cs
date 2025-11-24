using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventingDemo
{
    internal class StudentService
    {
        private readonly StudentEventBroker studentEventBroker;

        public StudentService(StudentEventBroker studentEventBroker) =>
            this.studentEventBroker = studentEventBroker;

        public async ValueTask<Student> AddStudentAsync(Student student) =>
            await this.studentEventBroker.PublishAsync(student);
    }
}