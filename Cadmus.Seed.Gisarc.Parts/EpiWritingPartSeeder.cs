﻿using Bogus;
using Cadmus.Core;
using Cadmus.Gisarc.Parts;
using Cadmus.Refs.Bricks;
using Fusi.Tools.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cadmus.Seed.Gisarc.Parts;

/// <summary>
/// Seeder for <see cref="EpiWritingPart"/>.
/// Tag: <c>seed.it.vedph.gisarc.epi-writing</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.gisarc.epi-writing")]
public sealed class EpiWritingPartSeeder : PartSeederBase
{
    private static IList<string> GetFigFeatures(int count, Faker f)
    {
        string[] features = new string[]
        {
            "fish", "dove", "leaf", "chrismon",
            "cross", "sheperd",
        };
        if (count >= features.Length) return features;

        HashSet<string> picked = new();
        while (picked.Count < count)
        {
            picked.Add(f.PickRandom(features));
        }
        return picked.ToList();
    }

    private static IList<string> GetScriptFeatures(int count, Faker f)
    {
        string[] features = new string[]
        {
            "text", "digit", "punctuation", "ligature",
            "abbreviation", "monogram", "single-letter", "undef-letter",
            "undef-drawing"
        };
        if (count >= features.Length) return features;

        HashSet<string> picked = new();
        while (picked.Count < count)
        {
            picked.Add(f.PickRandom(features));
        }
        return picked.ToList();
    }

    private List<DecoratedCount> GetCounts(Faker f)
    {
        return new List<DecoratedCount>
        {
            new DecoratedCount
            {
                Id = "row",
                Value = f.Random.Number(1, 50)
            },
            new DecoratedCount
            {
                Id = "col",
                Value = f.Random.Number(1, 5)
            }
        };
    }

    /// <summary>
    /// Creates and seeds a new part.
    /// </summary>
    /// <param name="item">The item this part should belong to.</param>
    /// <param name="roleId">The optional part role ID.</param>
    /// <param name="factory">The part seeder factory. This is used
    /// for layer parts, which need to seed a set of fragments.</param>
    /// <returns>A new part.</returns>
    /// <exception cref="ArgumentNullException">item or factory</exception>
    public override IPart? GetPart(IItem item, string? roleId,
        PartSeederFactory? factory)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        EpiWritingPart part = new Faker<EpiWritingPart>()
           .RuleFor(p => p.System, f => f.PickRandom("latn", "grek"))
           .RuleFor(p => p.Type, f => f.PickRandom("-", "capital"))
           .RuleFor(p => p.Technique,
                f => f.PickRandom("graffiti", "ink", "paint"))
           .RuleFor(p => p.Tool, f => f.PickRandom("-", "blade", "pen"))
           .RuleFor(p => p.FrameType,
                f => f.PickRandom("-", "rectangle", "ellipse"))
           .RuleFor(p => p.Counts, GetCounts)
           .RuleFor(p => p.FigType,
                f => f.PickRandom("-", "cross", "heart", "geometric"))
           .RuleFor(p => p.FigFeatures,
                f => GetFigFeatures(f.Random.Number(1, 3), f))
           .RuleFor(p => p.ScriptFeatures,
                f => GetScriptFeatures(f.Random.Number(1, 3), f))
           .RuleFor(p => p.Languages, f => new List<string>
                { f.PickRandom("lat", "grc") })
           .RuleFor(p => p.HasPoetry, f => f.Random.Bool())
           .RuleFor(p => p.Metres, f => new List<string>
                { f.PickRandom(new[] { "3ia", "6da^", "4tr" }) })
           .Generate();
        SetPartMetadata(part, roleId, item);

        return part;
    }
}
