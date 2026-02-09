using MediatR;
using Alumni.Application.DTOs;
using Alumni.Domain.Interfaces;

namespace Alumni.Application.UseCases.Content;

public record DeleteContentCommand(Guid Id) : IRequest<ApiResponse<bool>>;

public class DeleteContentCommandHandler : IRequestHandler<DeleteContentCommand, ApiResponse<bool>>
{
    private readonly IContentRepository _contentRepository;

    public DeleteContentCommandHandler(IContentRepository contentRepository)
    {
        _contentRepository = contentRepository;
    }

    public async Task<ApiResponse<bool>> Handle(DeleteContentCommand request, CancellationToken cancellationToken)
    {
        var content = await _contentRepository.GetByIdAsync(request.Id);

        if (content == null)
        {
            return new ApiResponse<bool>
            {
                Success = false,
                Message = "Content not found",
                Data = false
            };
        }

        await _contentRepository.DeleteAsync(content);

        return new ApiResponse<bool>
        {
            Success = true,
            Message = "Content deleted successfully",
            Data = true
        };
    }
}
