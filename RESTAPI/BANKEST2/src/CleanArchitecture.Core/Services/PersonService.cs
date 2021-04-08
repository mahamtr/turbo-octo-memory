using System;
using System.Collections.Generic;
using BANKEST2.Core.Entities;
using BANKEST2.Core.Interfaces;

namespace BANKEST2.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IPersonVerifier _personVerifier;

        public PersonService(IRepository<Person> personRepository, IPersonVerifier personVerifier)
        {
            _personRepository = personRepository;
            _personVerifier = personVerifier;
        }

        public void AddPerson(Person person)
        {
            if (!_personVerifier.IsPersonValid(person)) throw new Exception("PERSON IS NOT VALID");
            _personRepository.Add(person);
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _personRepository.GetAll();
        }
    }
}