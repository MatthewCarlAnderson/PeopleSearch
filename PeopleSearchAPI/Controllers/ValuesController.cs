using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeopleSearch.Repository;
using PeopleSearchAPI.Data;
using PeopleSearchData;
using PeopleSearchData.Models;

namespace PeopleSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IValueRepository valueRepository;
        public ValuesController(IValueRepository valueRepository)
        {
            this.valueRepository = valueRepository;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Value>> Get()
        {
            return Ok(valueRepository.GetAll());

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Value> Get(int id)
        {
            return Ok(valueRepository.GetValueById(id));
        }
    }
}
