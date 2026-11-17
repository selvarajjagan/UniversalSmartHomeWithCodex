using UniversalSmartHome.Domain.Devices;

namespace UniversalSmartHome.Domain.Tests;

public sealed class SmartDeviceTests
{
    [Fact]
    public void DeviceCanExposeOnlyItsDeclaredCapabilities()
    {
        var power = new DeviceCapability(Guid.NewGuid(), new PowerCapability(),
            [new SupportedCommand("turn_on"), new SupportedCommand("turn_off")],
            [new SupportedProperty("is_on", "boolean", true)]);
        var device = new SmartDevice
        {
            Id = Guid.NewGuid(), Name = "Desk lamp", ConnectorId = Guid.NewGuid(),
            ExternalDeviceId = "light.desk", Capabilities = [power]
        };

        Assert.Single(device.Capabilities);
        Assert.Equal(CapabilityType.Power, device.Capabilities.Single().Definition.Type);
        Assert.DoesNotContain(device.Capabilities, c => c.Definition.Type == CapabilityType.Temperature);
    }

    [Fact]
    public void DeviceDefaultsToUnknownConnectionAndEmptyMetadata()
    {
        var device = new SmartDevice
        {
            Id = Guid.NewGuid(), Name = "Unknown device", ConnectorId = Guid.NewGuid(), ExternalDeviceId = "external-1"
        };

        Assert.Equal(DeviceConnectionStatus.Unknown, device.ConnectionStatus);
        Assert.Empty(device.Metadata);
    }
}
