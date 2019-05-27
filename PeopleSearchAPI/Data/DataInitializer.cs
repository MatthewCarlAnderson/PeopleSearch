using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PeopleSearchData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PeopleSearchAPI.Data
{
    public class DataInitializer
    {
        IHostingEnvironment env;
        public DataInitializer(IHostingEnvironment env)
        {
            this.env = env;
        }
        public void SeedData(ApiContext context)
        {
            context.Database.EnsureCreated();

            if (context.Values.Any())
            {
                //db is already created
                return;
            }

            context.Values.Add(new PeopleSearchData.Models.Value { Id=1, stringValue = "one" });
            context.Values.Add(new PeopleSearchData.Models.Value { Id=2, stringValue = "two" });
            context.Values.Add(new PeopleSearchData.Models.Value { Id=77, stringValue = "seventy seven" });
            context.SaveChanges();

            context.People.Add(new PeopleSearchData.Models.Person {
                Id = 1,
                FirstName = "Matthew",
                LastName = "Anderson",
                Age = 8,
                Address = "3911 CountrySide Dr",
                Interests = "Family, Bicycling",
                Image = System.IO.File.ReadAllBytes(this.env.ContentRootPath + "/Images/1.jpg")
        });

            context.People.Add(new PeopleSearchData.Models.Person
            {
                Id = 2,
                FirstName = "Patrick",
                LastName = "Anderson",
                Age = 28,
                Address = "111 Seaside Dr",
                Interests = "Board Games, Lacrosse",
                Image = System.IO.File.ReadAllBytes(this.env.ContentRootPath + "/Images/2.jpg")
            });

            context.People.Add(new PeopleSearchData.Models.Person
            {
                Id = 4,
                FirstName = "Jane",
                LastName = "Doe",
                Age = 18,
                Address = "91234 Pearl St.",
                Interests = "Triathlete, Trivia Contents",
                Image = System.IO.File.ReadAllBytes(this.env.ContentRootPath + "/Images/4.jpg")
            });

            context.People.Add(new PeopleSearchData.Models.Person
            {
                Id = 37,
                FirstName = "Tobias",
                LastName = "Sammet",
                Age = 28,
                Address = "132 Main St",
                Interests = "Playing Music, Sleeping",
                Image = System.IO.File.ReadAllBytes(this.env.ContentRootPath + "/Images/37.jpg")
            });

            
            context.SaveChanges();

        }
    }
}
