using MediatR;
using Alumni.Application.DTOs;
using Alumni.Domain.Interfaces;

namespace Alumni.Application.UseCases.Content;

public record UpdateContentCommand(Guid Id, UpdateContentDto Content) : IRequest<ApiResponse<ContentDto>>;

public class UpdateContentCommandHandler : IRequestHandler<UpdateContentCommand, ApiResponse<ContentDto>>
{
    private readonly IContentRepository _contentRepository;

    public UpdateContentCommandHandler(IContentRepository contentRepository)
    {
        _contentRepository = contentRepository;
    }

    public async Task<ApiResponse<ContentDto>> Handle(UpdateContentCommand request, CancellationToken cancellationToken)
    {
        var content = await _contentRepository.GetByIdAsync(request.Id);

        if (content == null)
        {
            return new ApiResponse<ContentDto>
            {
                Success = false,
                Message = "Content not found"
            };
        }

        content.Update(request.Content.Title, request.Content.Body, request.Content.Type);
        await _contentRepository.UpdateAsync(content);

        return new ApiResponse<ContentDto>
        {
            Success = true,
            Data = new ContentDto(
                content.Id,
                content.Title,
                content.Body,
                content.Type,
                content.Status,
                content.PublishDate,
                content.CreatedBy,
                content.Creator != null ? $"{content.Creator.FirstName} {content.Creator.LastName}".Trim() : "Unknown",
                content.CreatedAt,
                content.UpdatedAt
            )
        };
    }
}
