using Bogus;
using Cadmus.Core;
using Cadmus.Gisarc.Parts;
using Fusi.Tools.Configuration;
using System;

namespace Cadmus.Seed.Gisarc.Parts;

/// <summary>
/// Seeder for Location part.
/// Tag: <c>seed.it.vedph.gisarc.location</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.gisarc.location")]
public sealed class LocationPartSeeder : PartSeederBase
{
    /// <summary>
    /// Creates and seeds a new part.
    /// </summary>
    /// <param name="item">The item this part should belong to.</param>
    /// <param name="roleId">The optional part role ID.</param>
    /// <param name="factory">The part seeder factory. This is used
    /// for layer parts, which need to seed a set of fragments.</param>
    /// <returns>A new part or null.</returns>
    /// <exception cref="ArgumentNullException">item or factory</exception>
    public override IPart? GetPart(IItem item, string? roleId,
        PartSeederFactory? factory)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));

        LocationPart part = new Faker<LocationPart>()
           .RuleFor(p => p.Latitude, f => f.Address.Latitude())
           .RuleFor(p => p.Longitude, f => f.Address.Longitude())
           .RuleFor(p => p.Altitude, f => f.PickRandom(10, 1000))
           .Generate();
        SetPartMetadata(part, roleId, item);

        return part;
    }
}
