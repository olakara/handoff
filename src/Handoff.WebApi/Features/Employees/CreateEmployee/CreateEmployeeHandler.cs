using Handoff.Domain.Aggregates;
using Handoff.Domain.Variants;
using Handoff.WebApi.Infrastructure;
using DomainEmail = Handoff.Domain.Common.Email;

namespace Handoff.WebApi.Features.Employees.CreateEmployee;

public static class CreateEmployeeHandler
{
    public static EmploymentType ParseEmploymentType(string value) => value.ToUpperInvariant() switch
    {
        "FULLTIME" => new EmploymentType.FullTime(),
        "PARTTIME" => new EmploymentType.PartTime(),
        "CONTRACTOR" => new EmploymentType.Contractor(),
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown employment type."),
    };

    public static Employee Handle(CreateEmployeeCommand command, IEmployeeRepository repository)
    {
        var employee = Employee.Hire(
            $"{command.FirstName} {command.LastName}",
            DomainEmail.Create(command.Email),
            command.Department,
            command.HireDate,
            ParseEmploymentType(command.EmploymentType));

        return repository.Add(employee);
    }
}
