using AutoMapper;
using Library.Api.PostModel;
using Library.Core.Entities;
using Library.Core.Repositories;
using Library.Core.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ourApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchServies;
        private readonly IMapper _mapper;

        public BranchController(IBranchService branchServies, IMapper mapper)
        {
            _branchServies = branchServies;
            _mapper = mapper;
        }
        // GET: api/<BreadController>
        [HttpGet]
        public async Task<IEnumerable<Branch>> GetAsync()
        {
            return await _branchServies.GetAllAsync();
        }


        // GET api/<BreadController>/5
        [HttpGet("{id}")]
        public ActionResult<Branch> Get(int id)
        {
            return Ok(_branchServies.GetById(id));
        }

        // POST api/<BreadController>
        [HttpPost]
        public async Task<ActionResult<Branch>> PostAsync([FromBody] BranchPostModel b)
        {
            var branch = _mapper.Map<Branch>(b);
            return Ok( await _branchServies.AddBAsync(branch));
        }

        // PUT api/<BreadController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Branch>> PutAsync(int id, [FromBody] BranchPostModel b)
        {
            var branch = _mapper.Map<Branch>(b);
            return Ok(await _branchServies.PutBAsync(id, branch));
        }

        // DELETE api/<BreadController>/5
        [HttpDelete("{id}")]
        public ActionResult<Branch> Delete(int id)
        {
            return Ok(_branchServies.DeleteB(id));
        }
    }
}
