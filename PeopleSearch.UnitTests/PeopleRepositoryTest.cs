using Microsoft.EntityFrameworkCore;
using PeopleSearch.Repository;
using PeopleSearchData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PeopleSearch.UnitTests
{
    public class PeopleRepositoryTest
    {
        private ApiContext context;

        public PeopleRepositoryTest()
        {
            context = SeedData();
        }


        [Fact]
        public void CanGetValueById()
        {
            IPeopleRepository peopleRepository = new PeopleRepository(context);
            var people = peopleRepository.GetValueById(1);
            Assert.Equal("Trent", people.FirstName);
            Assert.Equal("Wignall", people.LastName);
        }

        [Fact]
        public void CanGetCount()
        {
            IPeopleRepository peopleRepository = new PeopleRepository(context);
            int count = peopleRepository.GetCount();
            Assert.Equal(4, count);
        }

        [Fact]
        public void CanGetPeopleMatches_ReturnsAll()
        {
            IPeopleRepository peopleRepository = new PeopleRepository(context);
            var people = peopleRepository.GetMatches("a");
            Assert.Equal(4, people.Count());
        }

        [Fact]
        public void CanGetPeopleMatches_ReturnsFirstName()
        {
            IPeopleRepository peopleRepository = new PeopleRepository(context);
            var people = peopleRepository.GetMatches("Trent");
            Assert.Single(people);
            Assert.Equal("Trent", people.Single().FirstName);
            Assert.Equal(1, people.Single().Id);
        }

        [Fact]
        public void CanGetPeopleMatches_ReturnsLastName()
        {
            IPeopleRepository peopleRepository = new PeopleRepository(context);
            var people = peopleRepository.GetMatches("Wig");
            Assert.Single(people);
            Assert.Equal("Wignall", people.Single().LastName);
            Assert.Equal(1, people.Single().Id);
        }

        [Fact]
        public void CanGetPeopleMatches_ReturnsBoth()
        {
            IPeopleRepository peopleRepository = new PeopleRepository(context);
            var people = peopleRepository.GetMatches("ll");
            Assert.Equal(3, people.Count());
            Assert.Equal("Wignall", people.First().LastName);
            Assert.Equal(1, people.First().Id);
            Assert.Equal("Holly", people.ElementAt(1).FirstName);
            Assert.Equal(3, people.ElementAt(1).Id);
            Assert.Equal("Nelli", people.Last().LastName);
            Assert.Equal(4, people.Last().Id);
        }

        [Fact]
        public void CanGetPeopleMatches_ReturnsNothing()
        {
            IPeopleRepository peopleRepository = new PeopleRepository(context);
            var people = peopleRepository.GetMatches("x");
            Assert.Empty(people);
        }

        [Fact]
        public void CanGetPeopleMatches_CaseInsensitive()
        {
            IPeopleRepository peopleRepository = new PeopleRepository(context);
            var people = peopleRepository.GetMatches("TRENT");
            Assert.Single(people);
            Assert.Equal("Trent", people.Single().FirstName);
            Assert.Equal(1, people.Single().Id);
        }


        private ApiContext SeedData()
        {
            var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseInMemoryDatabase();
            var options = builder.Options;



            ApiContext context = new ApiContext(options);

            if (!context.People.Any())
            {
                context.People.Add(new PeopleSearchData.Models.Person() {
                    Id = 1,
                    FirstName ="Trent",
                    LastName ="Wignall",
                    Address ="123 Main St.",
                    Age =30,
                    Interests ="Golfing",
                    Image =null
                });

                context.People.Add(new PeopleSearchData.Models.Person()
                {
                    Id = 2,
                    FirstName = "Dan",
                    LastName = "Burton",
                    Address = "456 Second St.",
                    Age = 31,
                    Interests = "Fishing, Skiing",
                    Image = null
                });

                context.People.Add(new PeopleSearchData.Models.Person()
                {
                    Id = 3,
                    FirstName = "Holly",
                    LastName = "Rimmasch",
                    Address = "328 Holly Ave.",
                    Age = 28,
                    Interests = "Golfing",
                    Image = null
                });

                context.People.Add(new PeopleSearchData.Models.Person()
                {
                    Id = 4,
                    FirstName = "Patrick",
                    LastName = "Nelli",
                    Address = "333 Oak St.",
                    Age = 35,
                    Interests = "Board Games, Extreme Sports",
                    Image = null
                });
                context.SaveChanges();
            }
            return context;
        }

    }
}
