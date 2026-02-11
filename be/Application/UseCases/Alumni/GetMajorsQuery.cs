using MediatR;
using Alumni.Application.DTOs;
using Alumni.Domain.Interfaces;

namespace Alumni.Application.UseCases.Alumni;

public record GetMajorsQuery : IRequest<ApiResponse<List<string>>>
{
    public string? Degree { get; init; }
}

public class GetMajorsQueryHandler : IRequestHandler<GetMajorsQuery, ApiResponse<List<string>>>
{
    private readonly IAlumniRepository _alumniRepository;

    public GetMajorsQueryHandler(IAlumniRepository alumniRepository)
    {
        _alumniRepository = alumniRepository;
    }

    public async Task<ApiResponse<List<string>>> Handle(GetMajorsQuery request, CancellationToken cancellationToken)
    {
        var result = await _alumniRepository.GetUniqueMajorsAsync(request.Degree);

        return new ApiResponse<List<string>>
        {
            Success = true,
            Data = result.ToList()
        };
    }
}
