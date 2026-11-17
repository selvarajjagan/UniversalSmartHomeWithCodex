namespace UniversalSmartHome.Application.ConnectorManagement;

/// <summary>Safe, non-secret summary of a configured connector.</summary>
public sealed record ConnectorDescriptor(Guid Id, string Name, string Type, bool IsConnected, DateTimeOffset? LastConnectedAt = null);
