global using ChemistryApiTask.Models;
using ChemistryApiTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace ChemistryApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubstanceController : ControllerBase
    {
        private readonly ISubstanceService _substanceService;
        public SubstanceController(ISubstanceService substanceService)
        {
            _substanceService = substanceService;
        }

        [HttpGet(Name = "GetAllSubstances")]
        public async Task<IEnumerable<Substance>> GetAllSubstances()
        {
            var result = await _substanceService.GetAllAsync();
            return result;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Substance>> GetSingleSubstance(int Id)
        {
            var result = await _substanceService.GetSingleAsync(Id);
            if (result == null)
                return NotFound($"Sorry, the substance with Id({Id}) doesn't exist");
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Substance>> AddSubstance(Substance substance)
        {
            if (string.IsNullOrEmpty(substance.Name) || substance.Type == SubstanceType.None)
                return BadRequest("Please, add the name and type for your substance.");

            var result = await _substanceService.AddSubstanceAsync(substance);

            if (result is null)
                return BadRequest("Failed to add the substance.");

            return Ok(result);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Substance>> UpdateSubstance(int Id, Substance substance)
        {
            var result = await _substanceService.UpdateSubstanceAsync(Id, substance);
            if (result is null)
                return NotFound($"Sorry, the substance with Id({Id}) doesn't exist");
            if (string.IsNullOrEmpty(substance.Name) || substance.Type == SubstanceType.None)
                return BadRequest();
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Substance>> DeleteSubstance(int Id)
        {
            var result = await _substanceService.DeleteSubstanceAsync(Id);
            if (result is null)
                return NotFound($"Sorry, the substance with Id({Id}) doesn't exist");
            return Ok(result);
        }


    }
}
