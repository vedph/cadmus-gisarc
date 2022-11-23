﻿using Cadmus.Core;
using Cadmus.Gisarc.Parts;
using Fusi.Tools.Config;
using System;
using System.Reflection;
using Xunit;

namespace Cadmus.Seed.Gisarc.Parts.Test
{
    public sealed class EpiWritingPartSeederTest
    {
        private static readonly PartSeederFactory _factory =
        TestHelper.GetFactory();
        private static readonly SeedOptions _seedOptions =
            _factory.GetSeedOptions();
        private static readonly IItem _item =
            _factory.GetItemSeeder().GetItem(1, "facet");

        [Fact]
        public void TypeHasTagAttribute()
        {
            Type t = typeof(EpiWritingPartSeeder);
            TagAttribute? attr = t.GetTypeInfo().GetCustomAttribute<TagAttribute>();
            Assert.NotNull(attr);
            Assert.Equal("seed.it.vedph.gisarc.epi-writing", attr!.Tag);
        }

        [Fact]
        public void Seed_Ok()
        {
            EpiWritingPartSeeder seeder = new();
            seeder.SetSeedOptions(_seedOptions);

            IPart? part = seeder.GetPart(_item, null, _factory);

            Assert.NotNull(part);

            EpiWritingPart? p = part as EpiWritingPart;
            Assert.NotNull(p);

            TestHelper.AssertPartMetadata(p!);
        }
    }
}
