using MediatR;
using Alumni.Application.DTOs;
using Alumni.Domain.Interfaces;

namespace Alumni.Application.UseCases.Content;

public record GetContentByIdQuery(Guid Id) : IRequest<ApiResponse<ContentDto>>;

public class GetContentByIdQueryHandler : IRequestHandler<GetContentByIdQuery, ApiResponse<ContentDto>>
{
    private readonly IContentRepository _contentRepository;

    public GetContentByIdQueryHandler(IContentRepository contentRepository)
    {
        _contentRepository = contentRepository;
    }

    public async Task<ApiResponse<ContentDto>> Handle(GetContentByIdQuery request, CancellationToken cancellationToken)
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

        var response = new ContentDto(
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
        );

        return new ApiResponse<ContentDto>
        {
            Success = true,
            Data = response
        };
    }
}
