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
    public ActionResult<IEnumerable<AscensionData>> GetAll()
    {
        return Ok(_repository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<AscensionData> Get(string id)
    {
        var result = _repository.Get(id);
        if (result is null)
        {
            return NotFound();
        }

        var rank = _repository.GetRank(id);
        result.Rank = rank;

        return Ok(result);

    }

    [HttpPost]
    public ActionResult<AscensionData> Create([FromBody] AscensionData data)
    {
        _repository.Create(data);
        var rank = _repository.GetRank(data.Id);
        data.Rank = rank;
        return CreatedAtAction(nameof(Get), new { id = data.Id }, data);
    }

    [HttpPut]
    public ActionResult Put(string id, [FromBody] AscensionData data)
    {
        var existingData = _repository.Get(id);

        if (existingData is null)
        {
            return NotFound();
        }

        _repository.Update(id, data);

        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(string id)
    {
        var existingData = _repository.Get(id);

        if (existingData is null)
        {
            return NotFound();
        }

        _repository.Remove(id);

        return Ok();
    }
}