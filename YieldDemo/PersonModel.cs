using System;

namespace YieldDemo
{
    public class PersonModel
    {
        public PersonModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Console.WriteLine($"Initialized user {firstName} {lastName}");
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
