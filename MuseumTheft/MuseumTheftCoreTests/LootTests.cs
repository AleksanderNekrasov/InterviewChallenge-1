using AutoFixture;
using FluentAssertions;
using MuseumTheftCore;

namespace MuseumTheftCoreTests
{
    public class LootTests
    {
        private Fixture _fixture = new Fixture();

        [Test]
        public void WeightsOfItems_WithStolenItems_GivesResult()
        {
            //Arrange
            var rnd = new Random();
            var stolenItems = 
                _fixture.Build<StolenItem>().CreateMany(rnd.Next(20, 100));

            //Act
            var loot = new Loot(stolenItems);

            //Assert
            Assert.DoesNotThrow(() => loot.WeightsOfItems());
            loot.WeightsOfItems().Should().NotBeNullOrEmpty();
        }

        [TestCase(1, 2, 3, "1kg, 2kg, 3kg")]
        [TestCase(10, 20, 30, "10kg, 20kg, 30kg")]
        [TestCase(222, 333, 444, "222kg, 333kg, 444kg")]
        public void WeightsOfItems_WithStolenItems_GivesCorrectResult(int weight1, int weight2, int weight3, string sum) 
        {
            //Arrange
            var stolenItems = new[]
            {
                new StolenItem(_fixture.Create<int>(), _fixture.Create<int>(), weight1),
                new StolenItem(_fixture.Create<int>(), _fixture.Create<int>(), weight2),
                new StolenItem(_fixture.Create<int>(), _fixture.Create<int>(), weight3)
            };

            //Act
            var loot = new Loot(stolenItems);

            //Assert
            loot.WeightsOfItems().Should().Be(sum);
        }
    }
}
