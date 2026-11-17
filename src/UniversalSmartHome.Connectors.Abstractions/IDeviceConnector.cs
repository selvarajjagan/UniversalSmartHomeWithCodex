using UniversalSmartHome.Domain.Devices;

namespace UniversalSmartHome.Connectors.Abstractions;

/// <summary>Common asynchronous lifecycle, discovery, state, and command contract for device connectors.</summary>
public interface IDeviceConnector : IAsyncDisposable
{
    Guid ConnectorId { get; }
    string ConnectorName { get; }
    string ConnectorType { get; }
    bool IsConnected { get; }
    Task ConnectAsync(CancellationToken cancellationToken = default);
    Task DisconnectAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<SmartDevice>> DiscoverDevicesAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<DeviceState>> GetStateAsync(Guid deviceId, CancellationToken cancellationToken = default);
    Task ExecuteCommandAsync(Guid deviceId, DeviceCommand command, CancellationToken cancellationToken = default);
    IAsyncEnumerable<DeviceState> SubscribeToStateChangesAsync(CancellationToken cancellationToken = default);
}
