// Controllers/MontyHallController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MontyHallController : ControllerBase
{
    private readonly MontyHallService _montyHallService;

    public MontyHallController(MontyHallService montyHallService)
    {
        _montyHallService = montyHallService;
    }

    [HttpPost("simulate")]
    public ActionResult<SimulationResult> Simulate([FromBody] SimulationRequest request)
    {
        var result = _montyHallService.RunSimulations(request.NumberOfSimulations, request.SwitchDoor);
        return Ok(result);
    }
}

public class SimulationRequest
{
    public int NumberOfSimulations { get; set; }
    public bool SwitchDoor { get; set; }
}
