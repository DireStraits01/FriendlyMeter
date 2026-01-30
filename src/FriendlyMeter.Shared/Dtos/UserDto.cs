using FriendlyMeter.Shared.Models;

namespace FriendlyMeter.Shared.Dtos;
public record UserDto
(
    string Name,
    RoleType Role,
    string PhoneNumber,
    string? Email,
    DateTime DateCreated
);
