namespace Handoff.Domain.Variants;

public abstract record EmploymentType
{
    public abstract string Name { get; }

    public abstract decimal CalculateGrossPay(decimal hoursWorked, decimal rate);

    public sealed record FullTime : EmploymentType
    {
        public override string Name => "FullTime";

        public override decimal CalculateGrossPay(decimal hoursWorked, decimal rate) => rate;
    }

    public sealed record PartTime : EmploymentType
    {
        public override string Name => "PartTime";

        public override decimal CalculateGrossPay(decimal hoursWorked, decimal rate) => hoursWorked * rate;
    }

    public sealed record Contractor(decimal OvertimeMultiplier = 1.5m) : EmploymentType
    {
        private const decimal StandardWeeklyHours = 40m;

        public override string Name => "Contractor";

        public override decimal CalculateGrossPay(decimal hoursWorked, decimal rate)
        {
            if (hoursWorked <= StandardWeeklyHours)
            {
                return hoursWorked * rate;
            }

            var overtimeHours = hoursWorked - StandardWeeklyHours;
            return (StandardWeeklyHours * rate) + (overtimeHours * rate * OvertimeMultiplier);
        }
    }
}
