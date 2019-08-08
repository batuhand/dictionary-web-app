using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI3.Models;

namespace WebAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordRepository _repository;
        public WordController(IWordRepository repository)
        {
            this._repository = repository;
        }

        // GET: api/Word
        [HttpGet,Authorize]
        public IEnumerable<WordList> GetWords()
        {
            return _repository.GetAllItems().Take(100);
        }

        //[HttpGet("{Id}")]
        //public ObjectResult GetWord([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var item = _repository.GetItemById(id);

        //    return Ok(item);
        //}

        [HttpGet("{Id}"),Authorize]
        public ObjectResult GetWord([FromRoute] string id)
        {
            var item = _repository.GetWordByTr(id);
            return Ok(item);
        }

    }
}