namespace Handoff.WebApi.Features.Employees.GetEmployeeList;

public sealed record EmployeeSummary(
    Guid Id,
    string FullName,
    string Email,
    string Department,
    DateOnly HireDate,
    string EmploymentType);
