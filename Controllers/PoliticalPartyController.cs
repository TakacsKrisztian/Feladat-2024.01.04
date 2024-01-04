using Microsoft.AspNetCore.Mvc;

namespace Feladat_2023._01._04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliticalPartyController : ControllerBase
    {
        private readonly IPoliticalPartyInterface politicalpartyService;

        public PoliticalPartyController(IPoliticalPartyInterface politicalpartyService)
        {
            this.politicalpartyService = politicalpartyService;
        }
        [HttpPost]
        public async Task<ActionResult> Post(UploadPoliticalPartyDto uploadPoliticalPartyDto)
        {
            await politicalpartyService.PostPoliticalParty(uploadPoliticalPartyDto);
            try
            {
                return StatusCode(201, "A politikai pártot sikeresen feltöltötte.");
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoliticalParty>>> GetPoliticalParty()
        {
            try
            {
                return StatusCode(200, await politicalpartyService.Get());
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
        [HttpGet("id")]
        public async Task<ActionResult<PoliticalParty>> GetById(Guid Id)
        {
            try
            {
                return StatusCode(200, await politicalpartyService.GetById(Id));
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
        [HttpPut("id")]
        public async Task<ActionResult<PoliticalParty>> Put(Guid Id, UpdatePoliticalPartyDto updatePoliticalPartyDto)
        {
            try
            {
                var result = await politicalpartyService.PutPoliticalParty(Id, updatePoliticalPartyDto);
                return StatusCode(201, result);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid Id)
        {
            try
            {
                await politicalpartyService.DeletePoliticalParty(Id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
    }
}