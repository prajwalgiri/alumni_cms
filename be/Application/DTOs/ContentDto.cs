using Alumni.Domain.Entities;

namespace Alumni.Application.DTOs;

public record ContentDto(
    Guid Id,
    string Title,
    string Body,
    ContentType Type,
    ContentStatus Status,
    DateTime? PublishDate,
    Guid CreatedBy,
    string CreatorName,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record CreateContentDto(
    string Title,
    string Body,
    ContentType Type,
    ContentStatus Status = ContentStatus.Draft,
    DateTime? PublishDate = null
);

public record UpdateContentDto(
    string Title,
    string Body,
    ContentType Type
);

public record PublishContentRequest(
    DateTime? PublishDate = null
);
