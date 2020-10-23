using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPITutorial.Models;

namespace WebAPITutorial.Controllers
{
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();

        public PeopleController()
        {
            people.Add(new Person { FirstName ="Panth", LastName = "Shah", Id = 1});
        }
        // GET: api/People
        public List<Person> Get()
        {
            return people;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return people.FirstOrDefault(x => x.Id == id);
        }

        // POST: api/People
        public void Post(Person val)
        {
            people.Add(val);
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}
