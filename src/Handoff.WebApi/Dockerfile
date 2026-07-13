FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY Handoff.slnx ./
COPY src/Handoff.Domain/Handoff.Domain.csproj src/Handoff.Domain/
COPY src/Handoff.WebApi/Handoff.WebApi.csproj src/Handoff.WebApi/
RUN dotnet restore src/Handoff.WebApi/Handoff.WebApi.csproj

COPY src/Handoff.Domain/ src/Handoff.Domain/
COPY src/Handoff.WebApi/ src/Handoff.WebApi/
RUN dotnet publish src/Handoff.WebApi/Handoff.WebApi.csproj -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Handoff.WebApi.dll"]
