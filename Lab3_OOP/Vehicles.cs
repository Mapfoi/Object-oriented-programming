using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3_OOP;

/// <summary>
/// Interface that describes simple binary serialization contract.
/// </summary>
public interface IBinarySerializable
{
    /// <summary>
    /// Writes object state into binary writer.
    /// </summary>
    /// <param name="writer">Binary writer that receives object data.</param>
    void WriteTo(BinaryWriter writer);

    /// <summary>
    /// Reads object state from binary reader.
    /// </summary>
    /// <param name="reader">Binary reader that provides object data.</param>
    void ReadFrom(BinaryReader reader);
}

/// <summary>
/// Static registry that keeps mapping between type identifiers and vehicle factories.
/// This allows creation of correct derived type during deserialization without if/switch or reflection.
/// </summary>
public static class VehicleRegistry
{
    /// <summary>
    /// Internal description of one registered vehicle type.
    /// </summary>
    public sealed class VehicleFactoryInfo
    {
        public string TypeId { get; }
        public string DisplayName { get; }
        public Func<Vehicle> Factory { get; }

        public VehicleFactoryInfo(string typeId, string displayName, Func<Vehicle> factory)
        {
            TypeId = typeId;
            DisplayName = displayName;
            Factory = factory;
        }

        public override string ToString()
        {
            // This method is used by data binding components to display readable type name.
            return DisplayName;
        }
    }

    /// <summary>
    /// Dictionary that holds registered vehicle factories by type identifier.
    /// </summary>
    private static readonly Dictionary<string, VehicleFactoryInfo> _factories = new();

    /// <summary>
    /// Registers new vehicle type inside global registry.
    /// This method is usually called from static constructor of derived vehicle class.
    /// </summary>
    /// <param name="typeId">Stable identifier that will be written into file.</param>
    /// <param name="displayName">User friendly name that will be shown in UI.</param>
    /// <param name="factory">Factory delegate that creates empty instance of this type.</param>
    public static void Register(string typeId, string displayName, Func<Vehicle> factory)
    {
        // Simple guard against duplicated registrations.
        if (_factories.ContainsKey(typeId))
        {
            throw new InvalidOperationException($"Vehicle type with id '{typeId}' is already registered.");
        }

        _factories[typeId] = new VehicleFactoryInfo(typeId, displayName, factory);
    }

    /// <summary>
    /// Creates new vehicle instance using stored factory delegate.
    /// </summary>
    /// <param name="typeId">Identifier that was read from file.</param>
    /// <returns>Newly created vehicle instance.</returns>
    /// <exception cref="InvalidOperationException">Thrown when type identifier is unknown.</exception>
    public static Vehicle Create(string typeId)
    {
        if (!_factories.TryGetValue(typeId, out var info))
        {
            throw new InvalidOperationException($"Unknown vehicle type id '{typeId}'.");
        }

        return info.Factory();
    }

    /// <summary>
    /// Returns collection of all registered factories.
    /// UI can use it to build list of possible vehicle types dynamically.
    /// </summary>
    public static IReadOnlyCollection<VehicleFactoryInfo> GetAllFactories()
    {
        return _factories.Values;
    }
}

/// <summary>
/// Abstract base class for all vehicles in domain model.
/// </summary>
[Serializable]
public abstract class Vehicle : IBinarySerializable
{
    /// <summary>
    /// Identifier for type. Derived classes override it with stable value.
    /// </summary>
    public abstract string TypeId { get; }

    /// <summary>
    /// Producer of the vehicle (for example, "Toyota").
    /// </summary>
    public string Manufacturer { get; set; } = string.Empty;

    /// <summary>
    /// Model name of the vehicle (for example, "Corolla").
    /// </summary>
    public string Model { get; set; } = string.Empty;

    /// <summary>
    /// Year when vehicle was produced.
    /// </summary>
    public int Year { get; set; } = DateTime.Now.Year;

    /// <summary>
    /// Maximum speed in kilometers per hour.
    /// </summary>
    public int MaxSpeedKmh { get; set; } = 120;

    /// <summary>
    /// Writes vehicle data common for all derived classes and then calls derived specific method.
    /// </summary>
    /// <param name="writer">Binary writer that receives serialized data.</param>
    public void WriteTo(BinaryWriter writer)
    {
        // Base fields are always written in the same order.
        writer.Write(Manufacturer);
        writer.Write(Model);
        writer.Write(Year);
        writer.Write(MaxSpeedKmh);

        // Derived classes add their own data.
        WriteAdditionalData(writer);
    }

    /// <summary>
    /// Reads vehicle data common for all derived classes and then calls derived specific method.
    /// </summary>
    /// <param name="reader">Binary reader that provides serialized data.</param>
    public void ReadFrom(BinaryReader reader)
    {
        Manufacturer = reader.ReadString();
        Model = reader.ReadString();
        Year = reader.ReadInt32();
        MaxSpeedKmh = reader.ReadInt32();

        ReadAdditionalData(reader);
    }

    /// <summary>
    /// Derived classes implement this method to write their own fields.
    /// </summary>
    protected abstract void WriteAdditionalData(BinaryWriter writer);

    /// <summary>
    /// Derived classes implement this method to read their own fields.
    /// </summary>
    protected abstract void ReadAdditionalData(BinaryReader reader);

    /// <summary>
    /// Returns short text description that is convenient for list display.
    /// </summary>
    public override string ToString()
    {
        return $"{TypeId}: {Manufacturer} {Model} ({Year})";
    }
}

/// <summary>
/// Passenger car that extends basic vehicle with number of doors.
/// </summary>
[Serializable]
public class Car : Vehicle
{
    /// <summary>
    /// Unique type identifier used for serialization.
    /// </summary>
    public override string TypeId => "Car";

    /// <summary>
    /// Count of doors in car body.
    /// </summary>
    public int DoorsCount { get; set; } = 4;

    /// <summary>
    /// Static constructor registers type in global registry.
    /// </summary>
    static Car()
    {
        VehicleRegistry.Register("Car", "Car", () => new Car());
    }

    /// <inheritdoc />
    protected override void WriteAdditionalData(BinaryWriter writer)
    {
        writer.Write(DoorsCount);
    }

    /// <inheritdoc />
    protected override void ReadAdditionalData(BinaryReader reader)
    {
        DoorsCount = reader.ReadInt32();
    }
}

/// <summary>
/// Truck vehicle that can carry cargo.
/// </summary>
[Serializable]
public class Truck : Vehicle
{
    public override string TypeId => "Truck";

    /// <summary>
    /// Maximum mass of cargo in kilograms.
    /// </summary>
    public int MaxLoadKg { get; set; } = 5000;

    static Truck()
    {
        VehicleRegistry.Register("Truck", "Truck", () => new Truck());
    }

    protected override void WriteAdditionalData(BinaryWriter writer)
    {
        writer.Write(MaxLoadKg);
    }

    protected override void ReadAdditionalData(BinaryReader reader)
    {
        MaxLoadKg = reader.ReadInt32();
    }
}

/// <summary>
/// Bus vehicle that transports many passengers.
/// </summary>
[Serializable]
public class Bus : Vehicle
{
    public override string TypeId => "Bus";

    /// <summary>
    /// Maximum number of passengers that bus can carry.
    /// </summary>
    public int PassengerCapacity { get; set; } = 40;

    static Bus()
    {
        VehicleRegistry.Register("Bus", "Bus", () => new Bus());
    }

    protected override void WriteAdditionalData(BinaryWriter writer)
    {
        writer.Write(PassengerCapacity);
    }

    protected override void ReadAdditionalData(BinaryReader reader)
    {
        PassengerCapacity = reader.ReadInt32();
    }
}

/// <summary>
/// Motorcycle vehicle with information about sidecar.
/// </summary>
[Serializable]
public class Motorcycle : Vehicle
{
    public override string TypeId => "Motorcycle";

    /// <summary>
    /// Flag that indicates if motorcycle has additional sidecar.
    /// </summary>
    public bool HasSidecar { get; set; }

    static Motorcycle()
    {
        VehicleRegistry.Register("Motorcycle", "Motorcycle", () => new Motorcycle());
    }

    protected override void WriteAdditionalData(BinaryWriter writer)
    {
        writer.Write(HasSidecar);
    }

    protected override void ReadAdditionalData(BinaryReader reader)
    {
        HasSidecar = reader.ReadBoolean();
    }
}

/// <summary>
/// Electric car that extends normal car with battery capacity.
/// </summary>
[Serializable]
public class ElectricCar : Car
{
    public override string TypeId => "ElectricCar";

    /// <summary>
    /// Battery capacity in kilo-watt hours.
    /// </summary>
    public int BatteryCapacityKwh { get; set; } = 60;

    static ElectricCar()
    {
        VehicleRegistry.Register("ElectricCar", "Electric car", () => new ElectricCar());
    }

    protected override void WriteAdditionalData(BinaryWriter writer)
    {
        // First call base method to write all car-specific data.
        base.WriteAdditionalData(writer);
        writer.Write(BatteryCapacityKwh);
    }

    protected override void ReadAdditionalData(BinaryReader reader)
    {
        base.ReadAdditionalData(reader);
        BatteryCapacityKwh = reader.ReadInt32();
    }
}

/// <summary>
/// Sports car that focuses on acceleration.
/// </summary>
[Serializable]
public class SportsCar : Car
{
    public override string TypeId => "SportsCar";

    /// <summary>
    /// Time from 0 to 100 km/h in seconds.
    /// </summary>
    public double ZeroToHundredSeconds { get; set; } = 5.0;

    static SportsCar()
    {
        VehicleRegistry.Register("SportsCar", "Sports car", () => new SportsCar());
    }

    protected override void WriteAdditionalData(BinaryWriter writer)
    {
        base.WriteAdditionalData(writer);
        writer.Write(ZeroToHundredSeconds);
    }

    protected override void ReadAdditionalData(BinaryReader reader)
    {
        base.ReadAdditionalData(reader);
        ZeroToHundredSeconds = reader.ReadDouble();
    }
}

/// <summary>
/// Helper static class that knows how to serialize and deserialize list of vehicles to binary file.
/// </summary>
public static class VehicleBinarySerializer
{
    /// <summary>
    /// Saves collection of vehicles into binary file.
    /// </summary>
    /// <param name="filePath">Path to target file.</param>
    /// <param name="vehicles">Vehicles that will be serialized.</param>
    public static void Save(string filePath, IEnumerable<Vehicle> vehicles)
    {
        // Using statement ensures that file stream and writers are always properly closed.
        using var fileStream = File.Create(filePath);
        using var writer = new BinaryWriter(fileStream);

        // We need materialized list to know count and enumerate items twice if needed.
        var list = new List<Vehicle>(vehicles);

        // First write number of elements.
        writer.Write(list.Count);

        // For each vehicle write its type identifier and then object data.
        foreach (var vehicle in list)
        {
            writer.Write(vehicle.TypeId);
            vehicle.WriteTo(writer);
        }
    }

    /// <summary>
    /// Loads vehicles from binary file.
    /// </summary>
    /// <param name="filePath">Path to file that contains serialized vehicles.</param>
    /// <returns>List with deserialized vehicle objects.</returns>
    public static List<Vehicle> Load(string filePath)
    {
        using var fileStream = File.OpenRead(filePath);
        using var reader = new BinaryReader(fileStream);

        var result = new List<Vehicle>();

        // Number of elements is stored at the beginning of file.
        int count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
        {
            // Read type identifier and create empty instance using registry.
            string typeId = reader.ReadString();
            var vehicle = VehicleRegistry.Create(typeId);

            // Let instance read its own state.
            vehicle.ReadFrom(reader);

            result.Add(vehicle);
        }

        return result;
    }
}

