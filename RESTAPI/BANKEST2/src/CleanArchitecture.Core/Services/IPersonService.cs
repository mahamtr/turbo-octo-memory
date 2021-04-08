using System.Collections.Generic;
using BANKEST2.Core.Entities;

namespace BANKEST2.Core.Services
{
    public interface IPersonService
    {
        void AddPerson(Person person);
        IEnumerable<Person> GetAllPersons();
    }
}