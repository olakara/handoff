using Handoff.Domain.Aggregates;
using Handoff.Domain.Common;
using Handoff.Domain.Variants;

namespace Handoff.Domain.Tests.Aggregates;

public class EmployeeTests
{
    private static Employee CreateEmployee(EmploymentType? employmentType = null) =>
        Employee.Hire(
            "Ada Lovelace",
            Email.Create("ada@handoff.dev"),
            "Engineering",
            new DateOnly(2026, 1, 5),
            employmentType ?? new EmploymentType.FullTime());

    [Fact]
    public void Hire_WithValidData_CreatesEmployeeAndRaisesEvent()
    {
        var employee = CreateEmployee();

        Assert.Equal("Ada Lovelace", employee.FullName);
        Assert.Equal("Engineering", employee.Department);
        Assert.Single(employee.DomainEvents);
        Assert.IsType<EmployeeHiredEvent>(employee.DomainEvents[0]);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Hire_WithMissingFullName_Throws(string fullName)
    {
        Assert.Throws<ArgumentException>(() => Employee.Hire(
            fullName,
            Email.Create("ada@handoff.dev"),
            "Engineering",
            new DateOnly(2026, 1, 5),
            new EmploymentType.FullTime()));
    }

    [Fact]
    public void Hire_WithMissingDepartment_Throws()
    {
        Assert.Throws<ArgumentException>(() => Employee.Hire(
            "Ada Lovelace",
            Email.Create("ada@handoff.dev"),
            " ",
            new DateOnly(2026, 1, 5),
            new EmploymentType.FullTime()));
    }

    [Fact]
    public void ChangeDepartment_WithValidValue_UpdatesDepartment()
    {
        var employee = CreateEmployee();

        employee.ChangeDepartment("Platform");

        Assert.Equal("Platform", employee.Department);
    }

    [Fact]
    public void ChangeDepartment_WithEmptyValue_Throws()
    {
        var employee = CreateEmployee();

        Assert.Throws<ArgumentException>(() => employee.ChangeDepartment(""));
    }
}
