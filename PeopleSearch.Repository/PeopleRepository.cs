using PeopleSearchData;
using PeopleSearchData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeopleSearch.Repository
{
    public class PeopleRepository: IPeopleRepository
    {
        readonly ApiContext context;
        public PeopleRepository(ApiContext context)
        {
            this.context = context;
        }

        public IList<Person> GetAll()
        {
            return context.People.ToList();
        }

        public int GetCount()
        {
            return context.People.Count();
        }

        public IList<Person> GetMatches(string partialValue)
        {
            // I relealize that the tolower is not necessary in a case insensitve database context but I need it for my in memory tests
            return context.People.Where
                (p => p.FirstName.ToLower().Contains(partialValue.ToLower()) || p.LastName.ToLower().Contains(partialValue.ToLower()))
                .OrderBy(p => p.Id)
                .ToList();
        }

        public Person GetValueById(int Id)
        {
            return context.People.SingleOrDefault(p => p.Id == Id);
        }
    }
}
