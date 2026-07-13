using Handoff.Domain.Common;
using Handoff.Domain.Variants;

namespace Handoff.Domain.Aggregates;

public sealed class Employee : Entity
{
    public string FullName { get; private set; }

    public Email Email { get; private set; }

    public string Department { get; private set; }

    public DateOnly HireDate { get; private set; }

    public EmploymentType EmploymentType { get; private set; }

    private Employee(string fullName, Email email, string department, DateOnly hireDate, EmploymentType employmentType)
    {
        FullName = fullName;
        Email = email;
        Department = department;
        HireDate = hireDate;
        EmploymentType = employmentType;
    }

    public static Employee Hire(string fullName, Email email, string department, DateOnly hireDate, EmploymentType employmentType)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentException("Full name is required.", nameof(fullName));
        }

        if (string.IsNullOrWhiteSpace(department))
        {
            throw new ArgumentException("Department is required.", nameof(department));
        }

        var employee = new Employee(fullName, email, department, hireDate, employmentType);
        employee.Raise(new EmployeeHiredEvent(employee.Id, DateTimeOffset.UtcNow));
        return employee;
    }

    public void ChangeDepartment(string department)
    {
        if (string.IsNullOrWhiteSpace(department))
        {
            throw new ArgumentException("Department is required.", nameof(department));
        }

        Department = department;
    }
}
