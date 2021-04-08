using System.Collections.Generic;
using BANKEST2.Core.Entities;

namespace BANKEST2.Core.Services
{
    public class PersonVerifier: IPersonVerifier
    {
        public bool IsPersonValid(Person person)
        {
            if (person.Age > 100) return false;
            if (person.Height > (decimal) 5.0d) return false;
            return !string.IsNullOrWhiteSpace(person.Name);
        }
    }
}