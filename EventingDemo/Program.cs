namespace EventingDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var studentEventBroker = new StudentEventBroker();
            var studentService = new StudentService(studentEventBroker);
            var studentLibraryService = new StudentLibraryService(studentEventBroker);
            var paStudentService = new PAStudentService(studentEventBroker);

            studentLibraryService.SubscribeToStudentAddEvent();
            paStudentService.SubscribeToStudentAddEvent();

            await studentService.AddStudentAsync(student: new Student
            {
                Name = "Kailu"
            });
        }
    }
}