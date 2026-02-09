using MediatR;
using Alumni.Application.DTOs;
using Alumni.Domain.Interfaces;
using Alumni.Domain.Entities;

namespace Alumni.Application.UseCases.Content;

public record CreateContentCommand(CreateContentDto Content, Guid CreatedBy) : IRequest<ApiResponse<ContentDto>>;

public class CreateContentCommandHandler : IRequestHandler<CreateContentCommand, ApiResponse<ContentDto>>
{
    private readonly IContentRepository _contentRepository;
    private readonly IUserRepository _userRepository;

    public CreateContentCommandHandler(IContentRepository contentRepository, IUserRepository userRepository)
    {
        _contentRepository = contentRepository;
        _userRepository = userRepository;
    }

    public async Task<ApiResponse<ContentDto>> Handle(CreateContentCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.CreatedBy);
        var creatorName = user != null ? $"{user.FirstName} {user.LastName}" : "Unknown";

        var content = new global::Alumni.Domain.Entities.Content(
            request.Content.Title,
            request.Content.Body,
            request.Content.Type,
            request.CreatedBy,
            request.Content.Status,
            request.Content.PublishDate
        );

        await _contentRepository.AddAsync(content);

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
                creatorName,
                content.CreatedAt,
                content.UpdatedAt
            )
        };
    }
}
