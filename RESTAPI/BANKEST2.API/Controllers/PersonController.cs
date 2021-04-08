using System.Collections.Generic;
using System.Threading.Tasks;
using BANKEST2.Core.Entities;
using BANKEST2.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BANKEST2.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }


        [HttpGet]
        public IEnumerable<Person> GetPersons()
        {
            return _personService.GetAllPersons();
        }
        
        
        [HttpPost]
        
        public async Task AddPerson([FromBody] Person person)
        {
             _personService.AddPerson(person);
        }
    }
}
