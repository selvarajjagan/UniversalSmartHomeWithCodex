# Development progress

## Phase 1 – Solution foundation

- [x] Created .NET 10 solution and project boundaries for domain, application, infrastructure, connector abstractions and providers, Edge, API, WPF, and tests.
- [x] Enabled nullable reference types, implicit usings, documentation generation, and warnings as errors centrally.
- [x] Added normalized device, connection, capability, state, and command models.
- [x] Added asynchronous connector lifecycle, discovery, state, command, subscription, and disposal contracts.
- [x] Added initial domain tests and setup/architecture documentation.
- [x] Restored packages and built the complete solution with zero warnings and errors.
- [x] Ran the domain test project: 2 meaningful tests passed (the template placeholder was removed).

## Build status

`dotnet build UniversalSmartHome.sln --no-restore -m:1`: succeeded, 0 warnings, 0 errors. `dotnet test UniversalSmartHome.sln -m:1`: succeeded; 2 domain tests passed. Application and connector test projects currently contain no test cases. In this environment, NuGet restore and test-host execution required escalation because network access and test-host process connections were blocked inside the sandbox.

## Pending work

- Implement application device and connector lifecycle use cases.
- Select and implement Home Assistant REST/WebSocket support in Phase 2.
- Implement Edge API hosting, persistence, authentication, and real-time updates in Phase 3.
- Implement functional desktop screens in Phase 4.
- Evaluate the official MCP SDK before implementing Phase 5.

## Decisions and limitations

- MCP, Matter, Home Assistant and infrastructure projects are boundaries only; they do not claim working integrations.
- Capabilities use typed definition records, while connector/provider metadata uses string-valued extension maps to avoid coupling domain to protocol schemas.
- The initial test setup is xUnit 2.9.3 with Microsoft.NET.Test.Sdk 17.14.1 and xUnit Visual Studio adapter 3.1.4. The API template uses Microsoft.AspNetCore.OpenApi 10.0.15.
