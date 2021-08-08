using System.Collections.Generic;

namespace YieldDemo
{
    public class DataAccess
    {
        public static IEnumerable<PersonModel> GetPeople()
        {
            List<PersonModel> output = new();

            output.Add(new PersonModel("Leandro", "Reis"));
            output.Add(new PersonModel("Lucas", "Sousa"));
            output.Add(new PersonModel("Teteus", "Reis"));

            return output;
        }
    }

}
