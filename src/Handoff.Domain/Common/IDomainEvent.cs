namespace Handoff.Domain.Common;

public interface IDomainEvent
{
    DateTimeOffset OccurredOn { get; }
}
