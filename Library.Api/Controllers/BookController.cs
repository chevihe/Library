using Microsoft.AspNetCore.Mvc;
using Library.Core;
using Library.Core.Service;
using Library.Core.Entities;
using AutoMapper;
using Library.Api;
using Library.Api.PostModel;
using Microsoft.Extensions.Hosting;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ourApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _iBookServies;
        private readonly IMapper _mapper;

        public BookController(IBookService iBookServies,IMapper mapper)
        {
            _iBookServies = iBookServies;
            _mapper = mapper;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IEnumerable<Book>> GetAsync(string? name, int? status, int? branchId)
        {
            return await _iBookServies.GetAllAsync(name, status, branchId);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return  _iBookServies.GetById(id);
        }


        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] BookPostModel book)
        {
            var b = _mapper.Map<Book>(book);
            return  Ok(await _iBookServies.AddBAsync(b));
        }

        // PUT api/<BookController>/5
        //[HttpPut("status/{id}")]
        //public ActionResult Put(int id)
        //{
        //    return Ok(_iBookServies.PutB(id, "status"));
        //}

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] BookPostModel book)
        {
            var b = _mapper.Map<Book>(book);
            var bb = await _iBookServies.PutBAsync(id, b, "");
            return Ok(bb);
        }


        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(_iBookServies.DeleteB(id));
        }
    }
}
