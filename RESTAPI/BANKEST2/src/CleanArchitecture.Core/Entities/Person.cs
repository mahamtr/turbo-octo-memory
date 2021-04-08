using System;

namespace BANKEST2.Core.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Decimal Height { get; set; }
        public int Age { get; set; }
        
    }
}