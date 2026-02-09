using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Alumni.Application.DTOs;
using Alumni.Application.UseCases.Content;
using Alumni.Domain.Entities;
using System.Security.Claims;

namespace Alumni.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContentController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<ContentDto>>>> GetPublished([FromQuery] ContentType? type)
    {
        var query = new GetContentsQuery(type, true);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("admin")]
    [Authorize(Roles = "Admin,SuperAdmin,Staff,Moderator")]
    public async Task<ActionResult<ApiResponse<List<ContentDto>>>> GetAllForAdmin([FromQuery] ContentType? type)
    {
        var query = new GetContentsQuery(type, false);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<ContentDto>>> GetById(Guid id)
    {
        var query = new GetContentByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin,SuperAdmin,Staff,Moderator")]
    public async Task<ActionResult<ApiResponse<ContentDto>>> Create([FromBody] CreateContentDto request)
    {
        var command = new CreateContentCommand(request, GetCurrentUserId());
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,SuperAdmin,Staff,Moderator")]
    public async Task<ActionResult<ApiResponse<ContentDto>>> Update(Guid id, [FromBody] UpdateContentDto request)
    {
        var command = new UpdateContentCommand(id, request);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,SuperAdmin,Moderator")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
    {
        var command = new DeleteContentCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("{id}/publish")]
    [Authorize(Roles = "Admin,SuperAdmin,Moderator")]
    public async Task<ActionResult<ApiResponse<ContentDto>>> Publish(Guid id, [FromBody] PublishContentRequest request)
    {
        var command = new PublishContentCommand(id, request.PublishDate);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    private Guid GetCurrentUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userId))
        {
            throw new UnauthorizedAccessException("User not authenticated");
        }
        return userId;
    }
}
