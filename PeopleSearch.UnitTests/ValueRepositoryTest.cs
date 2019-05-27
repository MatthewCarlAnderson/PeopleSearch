using Microsoft.EntityFrameworkCore;
using PeopleSearch.Repository;
using PeopleSearchData;
using System;
using System.Linq;
using Xunit;

namespace PeopleSearch.UnitTests
{
    public class ValueRepositoryTest
    {

        private ApiContext context;

        public ValueRepositoryTest()
        {
            context = SeedData();
        }

        [Fact]
        public void CanGetValueById()
        {
            IValueRepository valueRepository = new ValueRepository(context);
            var value = valueRepository.GetValueById(1);
            Assert.Equal("First", value.stringValue);
        }

        [Fact]
        public void CanGetCount()
        {
            IValueRepository valueRepository = new ValueRepository(context);
            var value = valueRepository.GetCount();
            Assert.Equal(4, value);
        }

        [Fact]
        public void CanGetMatch()
        {
            IValueRepository valueRepository = new ValueRepository(context);
            var values = valueRepository.GetMatches("d");
            Assert.Equal(2, values.Count());
            Assert.Equal(2, values.First().Id);
            Assert.Equal(3, values.Last().Id);
        }


        private ApiContext SeedData()
        {
            var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseInMemoryDatabase();
            var options = builder.Options;


            
            ApiContext context = new ApiContext(options);

            if (!context.Values.Any())
            {
                context.Values.Add(new PeopleSearchData.Models.Value() { Id = 1, stringValue = "First" });
                context.Values.Add(new PeopleSearchData.Models.Value() { Id = 2, stringValue = "Second" });
                context.Values.Add(new PeopleSearchData.Models.Value() { Id = 3, stringValue = "Third" });
                context.Values.Add(new PeopleSearchData.Models.Value() { Id = 4, stringValue = "Fourth" });
                context.SaveChanges();
            }
            return context;
        }

    }


    
}
