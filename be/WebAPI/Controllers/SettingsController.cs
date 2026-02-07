using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Alumni.Application.UseCases.Settings;
using Alumni.Application.DTOs;

namespace Alumni.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SettingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SettingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetSettings([FromQuery] string? type)
    {
        try
        {
            var query = new GetSettingsQuery { Type = type };
            var result = await _mediator.Send(query);

            return Ok(new ApiResponse<List<SystemSettingDTO>>
            {
                Success = true,
                Data = result,
                Message = "Settings retrieved successfully"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<List<SystemSettingDTO>>
            {
                Success = false,
                Message = "An error occurred while retrieving settings",
                Errors = new List<string> { ex.Message }
            });
        }
    }

    [HttpPut("{key}")]
    [Authorize(Roles = "Admin,SuperAdmin,ADMINMNGR")]
    public async Task<IActionResult> UpdateSetting(string key, [FromBody] UpdateSettingRequest request)
    {
        try
        {
            var command = new UpdateSettingCommand
            {
                Key = key,
                Value = request.Value
            };

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound(new ApiResponse<bool>
                {
                    Success = false,
                    Message = $"Setting with key '{key}' not found"
                });
            }

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Data = true,
                Message = "Setting updated successfully"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<bool>
            {
                Success = false,
                Message = "An error occurred while updating the setting",
                Errors = new List<string> { ex.Message }
            });
        }
    }
}
