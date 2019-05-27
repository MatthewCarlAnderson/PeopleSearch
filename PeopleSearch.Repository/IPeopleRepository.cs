using PeopleSearchData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleSearch.Repository
{
    public interface IPeopleRepository
    {
        IList<Person> GetAll();
        int GetCount();
        Person GetValueById(int Id);
        IList<Person> GetMatches(string partialValue);
    }
}
