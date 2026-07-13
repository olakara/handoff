using Handoff.WebApi.Infrastructure;

namespace Handoff.WebApi.Features.Employees.GetEmployeeList;

public static class GetEmployeeListHandler
{
    public static IReadOnlyList<EmployeeSummary> Handle(IEmployeeRepository repository) =>
        repository.GetAll()
            .Select(e => new EmployeeSummary(
                e.Id,
                e.FullName,
                e.Email.Value,
                e.Department,
                e.HireDate,
                e.EmploymentType.Name))
            .ToList();
}
