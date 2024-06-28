using ContactManager.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace ContactManager.Infrastructure
{
    public class CMContextSeed : IDbSeeder
    {
        public Contact AddInitalContact()
        {
            return new Contact
            {
                Id = 1,
                Name = "Test",
                Address = "Testing Address",
                City = "Manchester",
                Country = "UK",
                Email = "Test@gmail.com",
                Phone = "+44123456789",
                PostalCode = "",
                Region = ""
            };
        }
    }
}
