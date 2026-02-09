using MediatR;
using Alumni.Application.DTOs;
using Alumni.Domain.Interfaces;

namespace Alumni.Application.UseCases.Alumni;

public record GetGraduationYearsQuery : IRequest<ApiResponse<List<int>>>;

public class GetGraduationYearsQueryHandler : IRequestHandler<GetGraduationYearsQuery, ApiResponse<List<int>>>
{
    private readonly IAlumniRepository _alumniRepository;

    public GetGraduationYearsQueryHandler(IAlumniRepository alumniRepository)
    {
        _alumniRepository = alumniRepository;
    }

    public async Task<ApiResponse<List<int>>> Handle(GetGraduationYearsQuery request, CancellationToken cancellationToken)
    {
        var years = await _alumniRepository.GetUniqueGraduationYearsAsync();

        return new ApiResponse<List<int>>
        {
            Success = true,
            Data = years.ToList()
        };
    }
}
