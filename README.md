# Universal Smart Home

Universal Smart Home is a modular smart device management platform. The initial implementation is establishing a reusable .NET 10 core; device communication belongs in connector projects, not in the desktop UI.

## Solution layout

- `UniversalSmartHome.Domain`: provider independent devices, capabilities, commands and states.
- `UniversalSmartHome.Application`: use case and connector management contracts.
- `UniversalSmartHome.Infrastructure`: persistence, security and platform services (planned).
- `UniversalSmartHome.Connectors.Abstractions`: connector lifecycle and device operations.
- `UniversalSmartHome.Connectors.HomeAssistant`: Home Assistant integration (planned).
- `UniversalSmartHome.Connectors.MCP`: generic MCP integration (planned).
- `UniversalSmartHome.Connectors.Matter`: reserved boundary for a researched controller integration; no fake connector is included.
- `UniversalSmartHome.Edge`: independent background host.
- `UniversalSmartHome.Api`: versioned HTTP API boundary.
- `UniversalSmartHome.Desktop`: Windows WPF client.
- `tests/`: domain, application and connector test projects.

## Build and run

Install the .NET 10 SDK. Build with `dotnet build UniversalSmartHome.sln` and run tests with `dotnet test UniversalSmartHome.sln`. The WPF desktop project targets Windows. At this phase, the API and Edge projects are host skeletons; no device integration is configured yet.

## Architecture rules

Domain has no framework or provider references. Application depends on the domain and connector contracts. Provider implementations depend on connector abstractions. Edge is the composition root. Connector-specific external identifiers remain separate from application device IDs, and only declared capabilities should drive UI controls.
