using Handoff.Domain.Aggregates;

namespace Handoff.WebApi.Infrastructure;

public interface IEmployeeRepository
{
    Employee Add(Employee employee);

    IReadOnlyList<Employee> GetAll();
}
