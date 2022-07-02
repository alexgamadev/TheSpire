using Microsoft.AspNetCore.Mvc;
using TheSpire.Models;
using TheSpire.Repositories;

namespace TheSpire.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AscensionDataController : ControllerBase
{
    private readonly IAscensionDataRepo _repository;

    public AscensionDataController(IAscensionDataRepo repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AscensionData>>> GetAllAsync()
    {
        var data = await _repository.GetAllAsync();
        if ( data is null )
        {
            return NotFound();
        }
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AscensionData>> GetAsync(string id)
    {
        var result = await _repository.GetAsync(id);
        if (result is null)
        {
            return NotFound();
        }

        var rank = await _repository.GetRankAsync(id);
        result.Rank = rank;

        return Ok(result);

    }

    [HttpPost]
    public async Task<ActionResult<AscensionData>> CreateAsync([FromBody] AscensionData data)
    {
        await _repository.CreateAsync(data);
        var rank = await _repository.GetRankAsync(data.Id);
        data.Rank = rank;
        return CreatedAtAction(nameof(GetAsync), new { id = data.Id }, data);
    }

    [HttpPut]
    public async Task<ActionResult> PutAsync(string id, [FromBody] AscensionData data)
    {
        var existingData = await _repository.GetAsync(id);

        if (existingData is null)
        {
            return NotFound();
        }

        await _repository.UpdateAsync(id, data);

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAsync(string id)
    {
        var existingData = await _repository.GetAsync(id);

        if (existingData is null)
        {
            return NotFound();
        }

        await _repository.RemoveAsync(id);

        return Ok();
    }
}