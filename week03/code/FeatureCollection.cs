/// <summary>
/// Represents the top-level GeoJSON object returned by the USGS earthquake API.
/// Maps to: { "features": [ ... ] }
/// </summary>
public class FeatureCollection
{
    public List<Feature> Features { get; set; } = [];
}

/// <summary>
/// Represents a single earthquake event.
/// Maps to: { "properties": { ... } }
/// </summary>
public class Feature
{
    public EarthquakeProperties Properties { get; set; } = new();
}

/// <summary>
/// Represents the properties of a single earthquake.
/// Maps to: { "place": "...", "mag": 2.5 }
/// </summary>
public class EarthquakeProperties
{
    public string Place { get; set; } = "";
    public double Mag { get; set; }
}