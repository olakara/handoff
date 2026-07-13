using Handoff.WebApi.Infrastructure;

namespace Handoff.WebApi.Features.Employees.CreateEmployee;

public static class CreateEmployeeEndpoint
{
    public static IEndpointRouteBuilder MapCreateEmployee(this IEndpointRouteBuilder app)
    {
        app.MapPost("/employees", (CreateEmployeeCommand command, IEmployeeRepository repository) =>
        {
            var errors = CreateEmployeeValidator.Validate(command);
            if (errors.Count > 0)
            {
                return Results.ValidationProblem(new Dictionary<string, string[]> { ["command"] = errors.ToArray() });
            }

            try
            {
                var employee = CreateEmployeeHandler.Handle(command, repository);
                var response = new EmployeeCreatedResponse(
                    employee.Id,
                    employee.FullName,
                    employee.Email.Value,
                    employee.Department,
                    employee.HireDate,
                    employee.EmploymentType.Name);
                return Results.Created($"/employees/{employee.Id}", response);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        })
        .WithName("CreateEmployee")
        .WithTags("Employees");

        return app;
    }
}
