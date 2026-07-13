namespace Handoff.WebApi.Features.Employees.CreateEmployee;

public static class CreateEmployeeValidator
{
    private static readonly string[] KnownEmploymentTypes = ["FullTime", "PartTime", "Contractor"];

    public static IReadOnlyList<string> Validate(CreateEmployeeCommand command)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(command.FirstName))
        {
            errors.Add("FirstName is required.");
        }

        if (string.IsNullOrWhiteSpace(command.LastName))
        {
            errors.Add("LastName is required.");
        }

        if (string.IsNullOrWhiteSpace(command.Department))
        {
            errors.Add("Department is required.");
        }

        if (!KnownEmploymentTypes.Contains(command.EmploymentType, StringComparer.OrdinalIgnoreCase))
        {
            errors.Add($"EmploymentType must be one of: {string.Join(", ", KnownEmploymentTypes)}.");
        }

        return errors;
    }
}
