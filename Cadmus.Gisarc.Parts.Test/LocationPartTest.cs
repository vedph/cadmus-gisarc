using System;
using Xunit;
using Cadmus.Core;
using Cadmus.Seed.Gisarc.Parts;
using System.Linq;

namespace Cadmus.Gisarc.Parts.Test
{
    public sealed class LocationPartTest
    {
        private static LocationPart GetPart()
        {
            LocationPartSeeder seeder = new();
            IItem item = new Item
            {
                FacetId = "default",
                CreatorId = "zeus",
                UserId = "zeus",
                Description = "Test item",
                Title = "Test Item",
                SortKey = ""
            };
            return (LocationPart)seeder.GetPart(item, null, null)!;
        }

        private static LocationPart GetEmptyPart()
        {
            return new LocationPart
            {
                ItemId = Guid.NewGuid().ToString(),
                RoleId = "some-role",
                CreatorId = "zeus",
                UserId = "another",
            };
        }

        [Fact]
        public void Part_Is_Serializable()
        {
            LocationPart part = GetPart();

            string json = TestHelper.SerializePart(part);
            LocationPart part2 = TestHelper.DeserializePart<LocationPart>(json)!;

            Assert.Equal(part.Id, part2.Id);
            Assert.Equal(part.TypeId, part2.TypeId);
            Assert.Equal(part.ItemId, part2.ItemId);
            Assert.Equal(part.RoleId, part2.RoleId);
            Assert.Equal(part.CreatorId, part2.CreatorId);
            Assert.Equal(part.UserId, part2.UserId);
        }

        [Fact]
        public void GetDataPins_Ok()
        {
            LocationPart part = GetEmptyPart();
            part.Latitude = 41.9028;
            part.Longitude = 12.4964;
            part.Altitude = 21;

            Assert.Equal(3, part.GetDataPins().Count());
        }
    }
}