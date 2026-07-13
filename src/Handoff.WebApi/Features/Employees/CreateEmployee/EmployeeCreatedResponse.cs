namespace Handoff.WebApi.Features.Employees.CreateEmployee;

public sealed record EmployeeCreatedResponse(
    Guid Id,
    string FullName,
    string Email,
    string Department,
    DateOnly HireDate,
    string EmploymentType);
