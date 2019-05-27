using PeopleSearchData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleSearch.Repository
{
    public interface IValueRepository
    {
        IList<Value> GetAll();
        int GetCount();
        Value GetValueById(int Id);
        IList<Value> GetMatches(string partialValue);
    }
}
