namespace UniversalSmartHome.Domain.Devices;

/// <summary>Normalized kind of a physical or logical smart device.</summary>
public enum DeviceType { Television, AirConditioner, Refrigerator, Fan, Light, Switch, Thermostat, Speaker, Sensor, Other }

/// <summary>Observed connectivity of a device through its connector.</summary>
public enum DeviceConnectionStatus { Unknown, Online, Offline, Unavailable, Connecting, Error }

/// <summary>Normalized capability families supported by devices.</summary>
public enum CapabilityType { Power, Lighting, Brightness, Color, Temperature, Thermostat, Fan, Media, Volume, Playback, EnergyMonitoring, Sensor }
