using HomeScheduler.Common.Dto;
using HomeScheduler.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace HomeScheduler.Controller;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    private readonly IAvailabilityService _availabilityService;

    public UserController(IUserService service, IAvailabilityService availabilityService)
    {
        _service = service;
        _availabilityService = availabilityService;
    }

    [HttpGet("")]
    public IActionResult GetUsers()
    {
        List<UserDto> result = _service.GetUsers();

        return Ok(new GetResponseDto<UserDto>(result));
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        UserDto? result = _service.GetUser(id);
        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpGet("{id}/availability")]
    public IActionResult GetUserAvailability(int id)
    {
        AvailabilityDto? result = _availabilityService.GetAvailabilityByUserId(id);
        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpPut("{id}/availability")]
    public IActionResult ToggleUserAvailability(int id, [FromBody] NoDataRequestDto request)
    {
        try
        {
            UpdateResponseDto<AvailabilityDto> result = _availabilityService.ToggleAvailability(id, request);
            if (result.Data == null) return StatusCode(422, "Failed to create User.");

            return Ok(new PostResponseDto<AvailabilityDto>
            {
                Data = result.Data,
                ChangeCount = result.ChangeCount
            });
        }
        catch (Exception ex)
        {
            return StatusCode(422, ex.InnerException?.Message ?? ex.Message);
        }
    }

    [HttpPost("")]
    public IActionResult AddUser([FromBody] RequestDto<UserRequestDto> request)
    {
        try
        {
            UpdateResponseDto<UserDto> result = _service.AddUser(request);
            if (result.Data == null) return StatusCode(422, "Failed to create User.");

            return Ok(new PostResponseDto<UserDto>
            {
                Data = result.Data,
                ChangeCount = result.ChangeCount
            });
        }
        catch (Exception ex)
        {
            return StatusCode(422, ex.InnerException?.Message ?? ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] RequestDto<UserRequestDto> request)
    {
        try
        {
            UpdateResponseDto<UserDto> result = _service.UpdateUser(id, request);
            if (result.Data == null) return NotFound();

            return Ok(new PostResponseDto<UserDto>
            {
                Data = result.Data,
                ChangeCount = result.ChangeCount
            });
        }
        catch (Exception ex)
        {
            return StatusCode(422, ex.InnerException?.Message ?? ex.Message);
        }
    }
}
