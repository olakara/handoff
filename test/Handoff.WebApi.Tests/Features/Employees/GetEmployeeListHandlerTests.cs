using Handoff.Domain.Aggregates;
using Handoff.Domain.Common;
using Handoff.Domain.Variants;
using Handoff.WebApi.Features.Employees.GetEmployeeList;
using Handoff.WebApi.Infrastructure;

namespace Handoff.WebApi.Tests.Features.Employees;

public class GetEmployeeListHandlerTests
{
    [Fact]
    public void Handle_WithNoEmployees_ReturnsEmptyList()
    {
        IEmployeeRepository repository = new InMemoryEmployeeRepository();

        var result = GetEmployeeListHandler.Handle(repository);

        Assert.Empty(result);
    }

    [Fact]
    public void Handle_WithEmployees_ReturnsSummaries()
    {
        IEmployeeRepository repository = new InMemoryEmployeeRepository();
        var employee = Employee.Hire(
            "Ada Lovelace",
            Email.Create("ada@handoff.dev"),
            "Engineering",
            new DateOnly(2026, 1, 5),
            new EmploymentType.FullTime());
        repository.Add(employee);

        var result = GetEmployeeListHandler.Handle(repository);

        var summary = Assert.Single(result);
        Assert.Equal(employee.Id, summary.Id);
        Assert.Equal("Ada Lovelace", summary.FullName);
        Assert.Equal("ada@handoff.dev", summary.Email);
        Assert.Equal("FullTime", summary.EmploymentType);
    }
}
