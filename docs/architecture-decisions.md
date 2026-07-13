# Architecture Decisions

## Vertical Slice Architecture for the WebApi

`Handoff.WebApi` organizes code by feature under `Features/<Aggregate>/<UseCase>/` rather than by
technical layer (controllers, services, repositories). Each use case (e.g. `CreateEmployee`,
`GetEmployeeList`) owns its endpoint, command/query, handler, and validator. This keeps related
code together, avoids a shared "service layer" that accretes unrelated logic, and makes it easy to
delete or evolve one feature without touching others.

## Domain layer isolation

`Handoff.Domain` has no dependency on ASP.NET Core, EF Core, or any infrastructure concern. It is
organized as:

- `Common/` — base building blocks (`Entity`, `ValueObject`, `IDomainEvent`) reused across
  aggregates.
- `Aggregates/` — aggregate roots and the domain events they raise (e.g. `Employee`,
  `EmployeeHiredEvent`).
- `Variants/` — polymorphic domain concepts modeled as a closed set of record types (e.g.
  `EmploymentType.FullTime` / `PartTime` / `Contractor`), so behavior that varies by type (like pay
  calculation) lives on the variant itself instead of in conditional branches scattered across the
  codebase.

## In-memory persistence for now

`Infrastructure/InMemoryEmployeeRepository` backs `IEmployeeRepository` for this initial scaffold.
No database is wired up yet — the interface boundary is in place so a real persistence
implementation (e.g. EF Core + a real datastore) can be swapped in without touching the feature
handlers.
