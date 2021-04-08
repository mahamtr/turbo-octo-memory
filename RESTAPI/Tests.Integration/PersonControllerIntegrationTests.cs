using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using BANKEST2.Core.Entities;
using Xunit;

namespace IntegrationTesting
{
    public class PersonControllerIntegrationTests : BaseClient
    {

        
        [Fact]
        public async void GetAll_Should_Succeed()
        {
            //arr
            
            //act
            var response = await _client.GetAsync("http://localhost:63790/Person");

            //assert
             Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }
        
        [Fact]
        public async void AddPerson_ShouldSucceed()
        {
            //arr
            var data = new Person{Name = "asdf",Height = (decimal) 8.8,Age = 20, Id = Guid.NewGuid()};
   
            //act
            var response = await _client.PostAsJsonAsync("http://localhost:63790/Person", data);
            var body  = await response.Content.ReadAsAsync<IEnumerable<Person>>();
        
            //assert
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }

  
    }
}