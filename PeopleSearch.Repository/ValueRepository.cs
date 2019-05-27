using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeopleSearchData;
using PeopleSearchData.Models;

namespace PeopleSearch.Repository
{
    public class ValueRepository : IValueRepository
    {
        readonly ApiContext context;

        public ValueRepository(ApiContext context)
        {
            this.context = context;
        }
        
        public IList<Value> GetAll()
        {
            return context.Values.ToList();
        }

        public int GetCount()
        {
            return context.Values.Count();
        }

        public IList<Value> GetMatches(string partialValue)
        {
            return context.Values.Where(x => x.stringValue.ToLower().Contains(partialValue.ToLower()))
                .OrderBy(v => v.Id)
                .ToList();
        }

        public Value GetValueById(int Id)
        {
            var item = context.Values.SingleOrDefault(x => x.Id == Id);
            return context.Values.SingleOrDefault(x => x.Id == Id);
        }
    }
}
