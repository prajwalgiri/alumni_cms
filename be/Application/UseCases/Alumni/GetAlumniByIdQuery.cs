using MediatR;
using Alumni.Application.DTOs;
using Alumni.Domain.Interfaces;
using System.Data.SqlTypes;

namespace Alumni.Application.UseCases.Alumni;

public record GetAlumniByIdQuery : IRequest<ApiResponse<AlumniResponse>>
{
    public Guid Id { get; init; }
}

public class GetAlumniByIdQueryHandler : IRequestHandler<GetAlumniByIdQuery, ApiResponse<AlumniResponse>>
{
    private readonly IAlumniRepository _alumniRepository;
    private readonly IUserRepository _userRepository;

    public GetAlumniByIdQueryHandler(IAlumniRepository alumniRepository,IUserRepository userRepository)
    {
        _alumniRepository = alumniRepository;
        _userRepository = userRepository;
    }

    public async Task<ApiResponse<AlumniResponse>> Handle(GetAlumniByIdQuery request, CancellationToken cancellationToken)
    {
        var alumni = await _alumniRepository.GetByIdAsync(request.Id);

        


        if (alumni == null)
        {
            return new ApiResponse<AlumniResponse>
            {
                Success = false,
                Message = "Alumni not found"
            };
        }

        if (!alumni.IsPublic)
        {
            return new ApiResponse<AlumniResponse>
            {
                Success = false,
                Message = "Alumni profile is private"
            };
        }
        var user = await _userRepository.GetByIdAsync(alumni.UserId);
        if(user is null)
        {
            return new ApiResponse<AlumniResponse>
            {
                Success = false,
                Message = "User not found for the alumni profile"
            };
        }
        var response = new AlumniResponse
        {
            Id = alumni.Id,
            UserId = alumni.UserId,
            Email = user?.Email ?? string.Empty,
            FirstName = user?.FirstName ?? string.Empty,
            LastName = user?.LastName ?? string.Empty,
            GraduationYear = alumni.GraduationYear,
            Degree = alumni.Degree,
            Major = alumni.Major,
            Faculty = alumni.Faculty,
            CurrentCompany = alumni.CurrentCompany,
            CurrentPosition = alumni.CurrentPosition,
            Location = alumni.Location,
            Bio = alumni.Bio,
            LinkedinUrl = alumni.LinkedinUrl,
            GithubUrl = alumni.GithubUrl,
            WebsiteUrl = alumni.WebsiteUrl,
            ProfileImageUrl = alumni.ProfileImageUrl,
            IsPublic = alumni.IsPublic,
            CreatedAt = alumni.CreatedAt,
            UpdatedAt = alumni.UpdatedAt
        };


        
            return new ApiResponse<AlumniResponse>
            {
                Success = true,
                Data = response
            };
    }
}
