using System.Collections.Concurrent;
using Handoff.Domain.Aggregates;

namespace Handoff.WebApi.Infrastructure;

public sealed class InMemoryEmployeeRepository : IEmployeeRepository
{
    private readonly ConcurrentDictionary<Guid, Employee> _employees = new();

    public Employee Add(Employee employee)
    {
        _employees[employee.Id] = employee;
        return employee;
    }

    public IReadOnlyList<Employee> GetAll() => _employees.Values.ToList();
}
