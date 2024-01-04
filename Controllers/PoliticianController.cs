using Microsoft.AspNetCore.Mvc;

namespace Feladat_2023._01._04.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
        public class PoliticianController : ControllerBase
        {
            private readonly IPoliticianInterface politicianService;

            public PoliticianController(IPoliticianInterface politicianService)
            {
                this.politicianService = politicianService;
            }
        [HttpPost]
        public async Task<ActionResult> Post(UploadPoliticianDto uploadPoliticianDto)
        {
            await politicianService.PostPolitician(uploadPoliticianDto);
            try
            {
                return StatusCode(201, "A politikust sikeresen feltöltötte.");
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Politician>>> GetPoliticians()
        {
            try
            {
                return StatusCode(200, await politicianService.Get());
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
        [HttpGet("id")]
        public async Task<ActionResult<Politician>> GetById(Guid Id)
        {
            try
            {
                return StatusCode(200, await politicianService.GetById(Id));
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
        [HttpPut("id")]
        public async Task<ActionResult<Politician>> Put(Guid Id, UpdatePoliticianDto updatePoliticianDto)
        {
            try
            {
                var result = await politicianService.PutPolitician(Id, updatePoliticianDto);
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
                await politicianService.DeletePolitician(Id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
    }
}