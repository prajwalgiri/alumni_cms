using MediatR;
using Alumni.Application.DTOs;
using Alumni.Domain.Interfaces;

namespace Alumni.Application.UseCases.Alumni;

public record GetDegreesWithMajorsQuery : IRequest<ApiResponse<List<DegreeMajorsResponse>>>;

public class GetDegreesWithMajorsQueryHandler : IRequestHandler<GetDegreesWithMajorsQuery, ApiResponse<List<DegreeMajorsResponse>>>
{
    private readonly IAlumniRepository _alumniRepository;

    public GetDegreesWithMajorsQueryHandler(IAlumniRepository alumniRepository)
    {
        _alumniRepository = alumniRepository;
    }

    public async Task<ApiResponse<List<DegreeMajorsResponse>>> Handle(GetDegreesWithMajorsQuery request, CancellationToken cancellationToken)
    {
        var data = await _alumniRepository.GetDegreesWithMajorsAsync();

        var degreesWithMajors = data.Select(x => new DegreeMajorsResponse
        {
            Degree = x.Key,
            Majors = x.Value.ToList()
        }).ToList();

        return new ApiResponse<List<DegreeMajorsResponse>>
        {
            Success = true,
            Data = degreesWithMajors
        };
    }
}
