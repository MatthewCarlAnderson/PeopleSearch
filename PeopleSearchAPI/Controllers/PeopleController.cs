using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleSearch.Repository;
using PeopleSearchData.Models;

namespace PeopleSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        IPeopleRepository peopleRepository;
        public PeopleController(IPeopleRepository peopleRepository)
        {
            this.peopleRepository = peopleRepository;
        }

        // GET api/people
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return Ok(new List<Person>());

        }

        // GET api/people
        [HttpGet("all")]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            return Ok(peopleRepository.GetAll());

        }

        // GET api/people/id/5
        [HttpGet("id/{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = peopleRepository.GetValueById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }


        // GET api/people/abc123
        [HttpGet("{value}")]
        public ActionResult<Person> Get(string value)
        {
            //arbitrarily decided to not allow spaces
            if (value.IndexOf(' ') >= 0)
            {
                return BadRequest();
            }

            var people = peopleRepository.GetMatches(value);
            if (!people.Any()) {
                return NotFound();
            }
            return Ok(people);
        }

    }
}