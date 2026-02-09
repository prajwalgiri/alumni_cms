using MediatR;
using Alumni.Application.DTOs;
using Alumni.Domain.Interfaces;
using Alumni.Domain.Entities;

namespace Alumni.Application.UseCases.Content;

public record GetContentsQuery(ContentType? Type = null, bool OnlyPublished = true) : IRequest<ApiResponse<List<ContentDto>>>;

public class GetContentsQueryHandler : IRequestHandler<GetContentsQuery, ApiResponse<List<ContentDto>>>
{
    private readonly IContentRepository _contentRepository;

    public GetContentsQueryHandler(IContentRepository contentRepository)
    {
        _contentRepository = contentRepository;
    }

    public async Task<ApiResponse<List<ContentDto>>> Handle(GetContentsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<global::Alumni.Domain.Entities.Content> contents;

        if (request.OnlyPublished)
        {
            contents = await _contentRepository.GetPublishedContentsAsync(request.Type);
        }
        else
        {
            contents = await _contentRepository.GetAllAsync();
            if (request.Type.HasValue)
            {
                contents = contents.Where(c => c.Type == request.Type.Value);
            }
        }

        var response = contents.Select(c => new ContentDto(
            c.Id,
            c.Title,
            c.Body,
            c.Type,
            c.Status,
            c.PublishDate,
            c.CreatedBy,
            c.Creator != null ? $"{c.Creator.FirstName} {c.Creator.LastName}".Trim() : "Unknown",
            c.CreatedAt,
            c.UpdatedAt
        )).ToList();

        return new ApiResponse<List<ContentDto>>
        {
            Success = true,
            Data = response
        };
    }
}
