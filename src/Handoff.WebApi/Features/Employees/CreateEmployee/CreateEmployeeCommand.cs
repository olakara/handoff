namespace Handoff.WebApi.Features.Employees.CreateEmployee;

public sealed record CreateEmployeeCommand(
    string FirstName,
    string LastName,
    string Email,
    string Department,
    DateOnly HireDate,
    string EmploymentType);
