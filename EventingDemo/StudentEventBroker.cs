using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventingDemo
{
    internal class StudentEventBroker
    {
        private event OnStudentAdded onStudentAdded;

        private event OnStudentAdded OnStudentAddedEvent
        {
            add
            {
                Console.WriteLine($"{value.Method.Name} Registered");
                onStudentAdded += value;
            }

            remove
            {
                onStudentAdded -= value;
            }
        }

        public delegate ValueTask<Student> OnStudentAdded(Student student);

        public void Subscribe(OnStudentAdded onStudentAdded) =>
            OnStudentAddedEvent += onStudentAdded;

        public void UnSubscribe(OnStudentAdded onStudentAdded) =>
            OnStudentAddedEvent -= onStudentAdded;

        public async ValueTask<Student> PublishAsync(Student student) =>
            await this.onStudentAdded.Invoke(student);
    }
}