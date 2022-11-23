using Cadmus.Core.Config;
using Cadmus.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using SimpleInjector;
using Cadmus.Gisarc.Parts;
using Xunit;
using Fusi.Microsoft.Extensions.Configuration.InMemoryJson;

namespace Cadmus.Seed.Gisarc.Parts.Test
{
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

        static public PartSeederFactory GetFactory()
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

            // container
            Container container = new();
            PartSeederFactory.ConfigureServices(
                container,
                new StandardPartTypeProvider(map),
                new[]
                {
                    // Cadmus.Seed.Gisarc.Parts
                    typeof(LocationPartSeeder).Assembly
                });

            // config
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddInMemoryJson(LoadResourceText("SeedConfig.json"));
            var configuration = builder.Build();

            return new PartSeederFactory(container, configuration);
        }

        static public void AssertPartMetadata(IPart part)
        {
            Assert.NotNull(part.Id);
            Assert.NotNull(part.ItemId);
            Assert.NotNull(part.UserId);
            Assert.NotNull(part.CreatorId);
        }
    }
}
