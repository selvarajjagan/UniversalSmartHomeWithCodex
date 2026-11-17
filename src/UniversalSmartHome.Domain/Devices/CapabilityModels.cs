namespace UniversalSmartHome.Domain.Devices;

/// <summary>Base contract for strongly typed, normalized capability definitions.</summary>
public abstract record CapabilityDefinition(CapabilityType Type);
public sealed record PowerCapability(bool CanTurnOn = true, bool CanTurnOff = true) : CapabilityDefinition(CapabilityType.Power);
public sealed record LightingCapability(bool SupportsOnOff = true) : CapabilityDefinition(CapabilityType.Lighting);
public sealed record BrightnessCapability(int Minimum = 0, int Maximum = 100) : CapabilityDefinition(CapabilityType.Brightness);
public sealed record ColorCapability(bool SupportsColorTemperature = false, bool SupportsRgb = false) : CapabilityDefinition(CapabilityType.Color);
public sealed record TemperatureCapability(decimal Minimum, decimal Maximum, decimal Step = 1m, string Unit = "°C") : CapabilityDefinition(CapabilityType.Temperature);
public sealed record ThermostatCapability(IReadOnlyCollection<string> SupportedModes) : CapabilityDefinition(CapabilityType.Thermostat);
public sealed record FanCapability(int MinimumSpeed = 0, int MaximumSpeed = 100) : CapabilityDefinition(CapabilityType.Fan);
public sealed record MediaCapability(IReadOnlyCollection<string> SupportedFeatures) : CapabilityDefinition(CapabilityType.Media);
public sealed record VolumeCapability(int Minimum = 0, int Maximum = 100) : CapabilityDefinition(CapabilityType.Volume);
public sealed record PlaybackCapability(IReadOnlyCollection<string> SupportedActions) : CapabilityDefinition(CapabilityType.Playback);
public sealed record EnergyMonitoringCapability(string EnergyUnit = "kWh", string PowerUnit = "W") : CapabilityDefinition(CapabilityType.EnergyMonitoring);
public sealed record SensorCapability(string Measurement, string? Unit = null) : CapabilityDefinition(CapabilityType.Sensor);

/// <summary>Describes one supported operation and its named parameters.</summary>
public sealed record SupportedCommand(string Name, IReadOnlyDictionary<string, string>? ParameterTypes = null);

/// <summary>Describes one readable or writable property exposed by a capability.</summary>
public sealed record SupportedProperty(string Name, string DataType, bool IsReadOnly = false);

/// <summary>A capability instance attached to a device.</summary>
public sealed record DeviceCapability(
    Guid Id,
    CapabilityDefinition Definition,
    IReadOnlyCollection<SupportedCommand> SupportedCommands,
    IReadOnlyCollection<SupportedProperty> SupportedProperties);
