﻿using Cadmus.Core.Config;
using Cadmus.Core;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using Cadmus.Gisarc.Parts;
using Xunit;
using Fusi.Microsoft.Extensions.Configuration.InMemoryJson;
using Microsoft.Extensions.Hosting;

namespace Cadmus.Seed.Gisarc.Parts.Test;

static internal class TestHelper
{
    static public string LoadResourceText(string name)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));

        using StreamReader reader = new(
            Assembly.GetExecutingAssembly().GetManifestResourceStream(
                $"Cadmus.Seed.Gisarc.Parts.Test.Assets.{name}")!,
            Encoding.UTF8);
        return reader.ReadToEnd();
    }

    private static IHost GetHost(string config)
    {
        // map
        TagAttributeToTypeMap map = new();
        map.Add(new[]
        {
            // Cadmus.Core
            typeof(StandardItemSortKeyBuilder).Assembly,
            // Cadmus.Gisarc.Parts
            typeof(LocationPart).Assembly
        });

        return new HostBuilder().ConfigureServices((hostContext, services) =>
        {
            PartSeederFactory.ConfigureServices(services,
                new StandardPartTypeProvider(map),
                new[]
                {
                    // Cadmus.Seed.Gisarc.Parts
                    typeof(LocationPartSeeder).Assembly
                });
            })
            // extension method from Fusi library
            .AddInMemoryJson(config)
            .Build();
    }

    static public PartSeederFactory GetFactory()
    {
        return new PartSeederFactory(GetHost(LoadResourceText("SeedConfig.json")));
    }

    static public void AssertPartMetadata(IPart part)
    {
        Assert.NotNull(part.Id);
        Assert.NotNull(part.ItemId);
        Assert.NotNull(part.UserId);
        Assert.NotNull(part.CreatorId);
    }
}
