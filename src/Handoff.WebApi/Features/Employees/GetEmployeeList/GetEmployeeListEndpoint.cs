using Handoff.WebApi.Infrastructure;

namespace Handoff.WebApi.Features.Employees.GetEmployeeList;

public static class GetEmployeeListEndpoint
{
    public static IEndpointRouteBuilder MapGetEmployeeList(this IEndpointRouteBuilder app)
    {
        app.MapGet("/employees", (IEmployeeRepository repository) => GetEmployeeListHandler.Handle(repository))
            .WithName("GetEmployeeList")
            .WithTags("Employees");

        return app;
    }
}
