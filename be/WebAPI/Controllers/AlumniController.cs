using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Alumni.Application.DTOs;
using Alumni.Application.UseCases.Alumni;

namespace Alumni.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlumniController : ControllerBase
{
    private readonly IMediator _mediator;

    public AlumniController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<AlumniListResponse>>>> GetAll()
    {
        var query = new GetAllAlumniQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AlumniResponse>>> GetById(Guid id)
    {
        var query = new GetAlumniByIdQuery { Id = id };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ApiResponse<AlumniResponse>>> Create([FromBody] CreateAlumniRequest request)
    {
        var command = new CreateAlumniCommand
        {
            UserId = GetCurrentUserId(),
            GraduationYear = request.GraduationYear,
            Degree = request.Degree,
            Major = request.Major,
            Faculty = request.Faculty,
            CurrentCompany = request.CurrentCompany,
            CurrentPosition = request.CurrentPosition,
            Location = request.Location,
            Bio = request.Bio,
            LinkedinUrl = request.LinkedinUrl,
            GithubUrl = request.GithubUrl,
            WebsiteUrl = request.WebsiteUrl,
            IsPublic = request.IsPublic
        };

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<ApiResponse<AlumniResponse>>> Update(Guid id, [FromBody] UpdateAlumniRequest request)
    {
        var command = new UpdateAlumniCommand
        {
            Id = id,
            UserId = GetCurrentUserId(),
            GraduationYear = request.GraduationYear,
            Degree = request.Degree,
            Major = request.Major,
            Faculty = request.Faculty,
            CurrentCompany = request.CurrentCompany,
            CurrentPosition = request.CurrentPosition,
            Location = request.Location,
            Bio = request.Bio,
            LinkedinUrl = request.LinkedinUrl,
            GithubUrl = request.GithubUrl,
            WebsiteUrl = request.WebsiteUrl,
            IsPublic = request.IsPublic
        };

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("years")]
    public async Task<ActionResult<ApiResponse<List<int>>>> GetYears()
    {
        var query = new GetGraduationYearsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("degrees")]
    public async Task<ActionResult<ApiResponse<List<DegreeMajorsResponse>>>> GetDegrees()
    {
        var query = new GetDegreesWithMajorsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("majors")]
    public async Task<ActionResult<ApiResponse<List<string>>>> GetMajors([FromQuery] string? degree)
    {
        var query = new GetMajorsQuery { Degree = degree };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    private Guid GetCurrentUserId()
    {
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
        if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userId))
        {
            throw new UnauthorizedAccessException("User not authenticated");
        }
        return userId;
    }
}
