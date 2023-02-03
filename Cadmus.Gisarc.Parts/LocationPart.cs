using System.Collections.Generic;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Configuration;

namespace Cadmus.Gisarc.Parts;

/// <summary>
/// Minimalist geographic location. This just includes a point and an
/// optional set of geometries.
/// <para>Tag: <c>it.vedph.gisarc.location</c>.</para>
/// </summary>
[Tag("it.vedph.gisarc.location")]
public sealed class LocationPart : PartBase
{
    /// <summary>
    /// Gets or sets the latitude.
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Gets or sets the longitude.
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Gets or sets the optional altitude.
    /// </summary>
    public double? Altitude { get; set; }

    /// <summary>
    /// Gets or sets zero or more geometries used to represent the region
    /// covered by this location.
    /// </summary>
    public List<string> Geometries { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LocationPart"/> class.
    /// </summary>
    public LocationPart()
    {
        Geometries = new List<string>();
    }

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins.</returns>
    public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        DataPinBuilder builder = new(new StandardDataPinTextFilter());

        builder.AddValue("lat", Latitude);
        builder.AddValue("lon", Longitude);
        if (Altitude != null) builder.AddValue("alt", Altitude.Value);

        return builder.Build(this);
    }

    /// <summary>
    /// Gets the definitions of data pins used by the implementor.
    /// </summary>
    /// <returns>Data pins definitions.</returns>
    public override IList<DataPinDefinition> GetDataPinDefinitions()
    {
        return new List<DataPinDefinition>(new[]
        {
             new DataPinDefinition(DataPinValueType.Decimal,
                "lat",
                "The latitude."),
             new DataPinDefinition(DataPinValueType.Decimal,
                "lon",
                "The longitude."),
             new DataPinDefinition(DataPinValueType.Decimal,
                "alt",
                "The altitude."),
        });
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        StringBuilder sb = new();

        sb.Append("[Location] lat=")
            .Append(Latitude)
            .Append(" lon=")
            .Append(Longitude);

        if (Altitude != null) sb.Append(" alt=").Append(Altitude.Value);

        return sb.ToString();
    }
}