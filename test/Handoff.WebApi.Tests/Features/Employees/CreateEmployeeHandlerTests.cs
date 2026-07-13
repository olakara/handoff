using Handoff.WebApi.Features.Employees.CreateEmployee;
using Handoff.WebApi.Infrastructure;

namespace Handoff.WebApi.Tests.Features.Employees;

public class CreateEmployeeHandlerTests
{
    [Fact]
    public void Handle_WithValidCommand_AddsEmployeeToRepository()
    {
        IEmployeeRepository repository = new InMemoryEmployeeRepository();
        var command = new CreateEmployeeCommand("Ada", "Lovelace", "ada@handoff.dev", "Engineering", new DateOnly(2026, 1, 5), "FullTime");

        var employee = CreateEmployeeHandler.Handle(command, repository);

        Assert.Equal("Ada Lovelace", employee.FullName);
        Assert.Single(repository.GetAll());
    }

    [Fact]
    public void Handle_WithInvalidEmail_Throws()
    {
        IEmployeeRepository repository = new InMemoryEmployeeRepository();
        var command = new CreateEmployeeCommand("Ada", "Lovelace", "not-an-email", "Engineering", new DateOnly(2026, 1, 5), "FullTime");

        Assert.Throws<ArgumentException>(() => CreateEmployeeHandler.Handle(command, repository));
    }

    [Theory]
    [InlineData("FullTime")]
    [InlineData("PartTime")]
    [InlineData("Contractor")]
    public void ParseEmploymentType_WithKnownValue_ReturnsMatchingVariant(string value)
    {
        var employmentType = CreateEmployeeHandler.ParseEmploymentType(value);

        Assert.Equal(value, employmentType.Name);
    }

    [Fact]
    public void ParseEmploymentType_WithUnknownValue_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => CreateEmployeeHandler.ParseEmploymentType("Intern"));
    }
}
