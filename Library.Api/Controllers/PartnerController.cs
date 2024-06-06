using AutoMapper;
using Library.Api.PostModel;
using Library.Core.Entities;
using Library.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ourApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PartnerController : ControllerBase
    {

        private readonly IPartnerService _PartnerService;
        private readonly IMapper _mapper;

        public PartnerController(IPartnerService partnerServies, IMapper mapper)
        {
            _PartnerService = partnerServies;
            _mapper = mapper;
        }
        // GET: api/<BreadController>
        [HttpGet]
        public async Task<IEnumerable<Partner>> GetAsync()
        {
            return await _PartnerService.GetAllAsync();
        }

        // GET api/<BreadController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_PartnerService.GetById(id));
        }

        // POST api/<BreadController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PartnerPostModel p)
        {
            var Partner = _mapper.Map<Partner>(p);
            return Ok(await _PartnerService.AddPAsync(Partner));
        }

        // PUT api/<BreadController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] PartnerPostModel p)
        {
            var Partner = _mapper.Map<Partner>(p);
            return Ok(await _PartnerService.PutPAsync(id, Partner));
        }

        // DELETE api/<BreadController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(_PartnerService.DeleteP(id));
        }


    }
}
