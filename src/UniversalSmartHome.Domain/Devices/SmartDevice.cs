namespace UniversalSmartHome.Domain.Devices;

/// <summary>Unified device identity independent of the provider's protocol and data model.</summary>
public sealed record SmartDevice
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public string? Manufacturer { get; init; }
    public string? Model { get; init; }
    public DeviceType DeviceType { get; init; } = DeviceType.Other;
    public Guid? HomeId { get; init; }
    public required Guid ConnectorId { get; init; }
    public required string ExternalDeviceId { get; init; }
    public DeviceConnectionStatus ConnectionStatus { get; init; } = DeviceConnectionStatus.Unknown;
    public IReadOnlyCollection<DeviceCapability> Capabilities { get; init; } = Array.Empty<DeviceCapability>();
    public DateTimeOffset? LastSeenAt { get; init; }
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>Current normalized state snapshot for a device capability.</summary>
public sealed record DeviceState(
    Guid DeviceId,
    Guid CapabilityId,
    IReadOnlyDictionary<string, string> StateProperties,
    DateTimeOffset LastUpdatedAt,
    bool IsAvailable);

/// <summary>A requested operation on one explicitly supported device capability.</summary>
public sealed record DeviceCommand(
    string Name,
    Guid CapabilityId,
    IReadOnlyDictionary<string, string> Parameters);
