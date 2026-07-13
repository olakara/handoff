using Handoff.Domain.Variants;

namespace Handoff.Domain.Tests.Variants;

public class EmploymentTypeTests
{
    [Fact]
    public void FullTime_CalculateGrossPay_ReturnsFlatRate()
    {
        EmploymentType employmentType = new EmploymentType.FullTime();

        var pay = employmentType.CalculateGrossPay(hoursWorked: 60, rate: 5000m);

        Assert.Equal(5000m, pay);
    }

    [Fact]
    public void PartTime_CalculateGrossPay_MultipliesHoursByRate()
    {
        EmploymentType employmentType = new EmploymentType.PartTime();

        var pay = employmentType.CalculateGrossPay(hoursWorked: 20, rate: 25m);

        Assert.Equal(500m, pay);
    }

    [Fact]
    public void Contractor_CalculateGrossPay_WithinStandardHours_MultipliesHoursByRate()
    {
        EmploymentType employmentType = new EmploymentType.Contractor();

        var pay = employmentType.CalculateGrossPay(hoursWorked: 35, rate: 50m);

        Assert.Equal(1750m, pay);
    }

    [Fact]
    public void Contractor_CalculateGrossPay_WithOvertime_AppliesMultiplier()
    {
        EmploymentType employmentType = new EmploymentType.Contractor(OvertimeMultiplier: 2m);

        var pay = employmentType.CalculateGrossPay(hoursWorked: 45, rate: 50m);

        Assert.Equal((40 * 50m) + (5 * 50m * 2m), pay);
    }
}
