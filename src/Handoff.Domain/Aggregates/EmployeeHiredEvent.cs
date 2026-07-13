using Handoff.Domain.Common;

namespace Handoff.Domain.Aggregates;

public sealed record EmployeeHiredEvent(Guid EmployeeId, DateTimeOffset OccurredOn) : IDomainEvent;
