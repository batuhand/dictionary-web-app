using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI3.Models;

namespace WebAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly dictUserContext _context;

        public DefaultController(dictUserContext context)
        {
            _context = context;
        }
        // GET: api/Default
        [HttpGet]
        public IEnumerable<UserList> Get()
        {
            return _context.UserList.ToList();
        }

        // GET: api/Default/5
        [HttpGet("{id}", Name = "Get")]
        public IEnumerable<UserList> Get(string id)
        {
            List<UserList> list = new List<UserList>();
            UserList user = _context.UserList.FirstOrDefault(cus => cus.UserName == id);
            if (user != null)
            {
                list.Add(user);
            }
            return list;
        }

        // POST: api/Default
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Default/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
