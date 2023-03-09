using AutoFixture;
using FluentAssertions;
using MuseumTheftCore;

namespace MuseumTheftCoreTests
{
    public class BagTests
    {
        private Fixture _fixture = new Fixture();

        [Test]
        public void MaxProfitToString_WithManyLoots_GivesResult()
        {
            //Arrange
            var rnd = new Random();
            var loots = new List<Loot>();
            for (int i = 0; i < rnd.Next(20, 100); i++) 
            {
                loots.Add(new Loot(_fixture.Build<StolenItem>().CreateMany(rnd.Next(20, 100))));
            }
            
            //Act
            var bag = Bag.CreateBagWithCapacity(int.MaxValue);
            bag.AddCombinations(loots);

            //Assert
            Assert.DoesNotThrow(() => bag.MaxProfitToString());
            bag.MaxProfitToString().Should().NotBeNullOrEmpty();
        }

        [Test]
        public void MaxProfitToString_WithLoots_ReturnsMaximumValueLoot()
        {
            //Arrange
            var loots = new []
            {
                //Both loots are within capacity so value 20 will be selected
                new Loot(_fixture.Build<StolenItem>()
                    .With(x => x.Value, 10)
                    .With(x => x.Weight, 10)
                    .CreateMany(5)),
                new Loot(_fixture.Build<StolenItem>()
                    .With(x => x.Value, 20)
                    .With(x => x.Weight, 10)
                    .CreateMany(5))
            };

            //Act
            var bag = Bag.CreateBagWithCapacity(50);
            bag.AddCombinations(loots);

            //Assert
            bag.MaxProfitToString().Should()
                .Be("Maximum profit is 100, the weights of items are: 10kg, 10kg, 10kg, 10kg, 10kg.");
        }

        [Test]
        public void MaxProfitToString_WithLoots_ReturnsLootWithinBagCapacity()
        {
            //Arrange
            var loots = new[]
            {
                new Loot(_fixture.Build<StolenItem>()
                    .With(x => x.Value, 30)
                    .With(x => x.Weight, 30) //this combination will exceed bag capacity of 50
                    .CreateMany(5)),
                new Loot(_fixture.Build<StolenItem>()
                    .With(x => x.Value, 20)
                    .With(x => x.Weight, 10)
                    .CreateMany(5))
            };

            //Act
            var bag = Bag.CreateBagWithCapacity(50);
            bag.AddCombinations(loots);

            //Assert
            bag.MaxProfitToString().Should()
                .Be("Maximum profit is 100, the weights of items are: 10kg, 10kg, 10kg, 10kg, 10kg.");
        }
     }
}