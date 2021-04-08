using System.Collections.Generic;
using BANKEST2.Core.Entities;
using BANKEST2.Core.Services;
using Xunit;

namespace UnitTesting
{
    public class UnitTest1
    {

        [Fact]
        public void Person_IsValidShouldComply()
        {
            //arrage
            var personToVerify = new Person {Height = (decimal) 6.5, Age = 20, Name = "Maai Ham"};
            var personVerifier = new PersonVerifier();
            
            //act
            var response = personVerifier.IsPersonValid(personToVerify);

            //asert
            Assert.IsAssignableFrom<bool>(response);
            Assert.False(response);
        }
    }
}