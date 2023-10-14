using HomeScheduler.Common.Dto;
using HomeScheduler.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace HomeScheduler.Service.Controller;

[Route("api/[controller]")]
[ApiController]
public class AvailabilityController : ControllerBase
{
    private readonly IAvailabilityService _service;

    public AvailabilityController(IAvailabilityService service)
    {
        _service = service;
    }

    [HttpGet("")]
    public IActionResult GetAvailabilities()
    {
        List<AvailabilityDto> result = _service.GetAvailabilities();

        return Ok(new GetResponseDto<AvailabilityDto>(result));
    }
}
