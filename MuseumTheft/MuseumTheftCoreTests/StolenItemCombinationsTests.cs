using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using MuseumTheftCore;

namespace MuseumTheftCoreTests
{
    public class StolenItemCombinationsTests
    {
        private Fixture _fixture = new Fixture();

        [Test]
        public void GetStolenItemCombinations_WithManyStolenItems_ReturnsResult()
        {
            var rnd = new Random();
            //Arrange
            var stolenItems = _fixture.Build<StolenItem>().CreateMany(rnd.Next(20, 100));
            var repo = A.Fake<IStolenItemsRepository>();
            A.CallTo(() => repo.GetAll()).Returns(stolenItems);

            //Act
            var combinations = new StolenItemCombinations(repo);

            //Assert
            Assert.DoesNotThrowAsync(() => combinations.GetStolenItemCombinations());
            combinations.GetStolenItemCombinations()
                .Result.Should().NotBeEmpty();
        }

        [TestCase(1, 1)]
        [TestCase(2, 3)]
        [TestCase(3, 7)]
        [TestCase(4, 15)]
        [TestCase(50, 262143)]
        public void GetStolenItemCombinations_WithNumberOfItems_ReturnCorectNumberOfCombinmations(int numItems, int numPossibleCombinations)
        {
            var rnd = new Random();
            //Arrange
            var stolenItems = _fixture.Build<StolenItem>().CreateMany(numItems);
            var repo = A.Fake<IStolenItemsRepository>();
            A.CallTo(() => repo.GetAll()).Returns(stolenItems);

            //Act
            var combinations = new StolenItemCombinations(repo);

            //Assert
            Assert.DoesNotThrowAsync(() => combinations.GetStolenItemCombinations());
            combinations.GetStolenItemCombinations()
                .Result.Should().HaveCount(numPossibleCombinations);
        }
    }
}
