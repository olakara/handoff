# Handoff

Employee management API built with .NET 10, ASP.NET Core Minimal APIs, and Vertical Slice
Architecture.

## Folder structure

```
handoff/
├── deploy/                       # docker-compose files for running the API in a container
├── docs/                         # architecture decisions and documentation
├── src/
│   ├── Handoff.Domain/           # domain layer: aggregates, value objects, domain events
│   │   ├── Common/               # base Entity, ValueObject, IDomainEvent
│   │   ├── Aggregates/           # Employee aggregate root + domain events
│   │   └── Variants/             # polymorphic domain variants (EmploymentType)
│   └── Handoff.WebApi/           # ASP.NET Core 10 Minimal API, Vertical Slice Architecture
│       ├── Features/Employees/   # one folder per use case: endpoint, command, handler, validator
│       └── Infrastructure/       # repository abstraction + in-memory implementation
├── test/
│   ├── Handoff.Domain.Tests/     # xUnit tests for domain logic
│   └── Handoff.WebApi.Tests/     # xUnit tests for feature handlers
└── Handoff.slnx                  # solution file
```

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Build

```bash
dotnet build
```

## Test

```bash
dotnet test
```

## Run locally

```bash
dotnet run --project src/Handoff.WebApi
```

The API listens on the URL printed in the console (see
`src/Handoff.WebApi/Properties/launchSettings.json`). Example requests:

```bash
curl -X POST http://localhost:5237/employees \
  -H "Content-Type: application/json" \
  -d '{"firstName":"Ada","lastName":"Lovelace","email":"ada@handoff.dev","department":"Engineering","hireDate":"2026-01-05","employmentType":"FullTime"}'

curl http://localhost:5237/employees
```

## Run via Docker Compose

```bash
docker compose -f deploy/docker-compose.yml -f deploy/docker-compose.override.yml up --build
```

The API will be available at `http://localhost:8080`.

## Documentation

See [`docs/architecture-decisions.md`](docs/architecture-decisions.md) for the reasoning behind
the folder layout and architectural choices.
