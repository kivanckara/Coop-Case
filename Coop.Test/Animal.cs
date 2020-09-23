using Coop.Entity;
using Xunit;

namespace Coop.Test
{
    public class Animal
    {
        private readonly Entity.Animal animal;

        public Animal()
        {
            animal = new Entity.Animal();
        }

        [Fact]
        public void AnimalNameReadByConfig()
        {
            Assert.NotEmpty(animal.Name);
        }

        [Fact]
        public void IsMinAgeForFertilityInMonthsGreaterThanZero()
        {
            Assert.True(animal.MinAgeForFertilityInMonths > 0);
        }

        [Fact]
        public void IsNewBornCountGreaterThanZero()
        {
            Assert.True(animal.NewBornCount > 0);
        }

        [Fact]
        public void IsLifeTimeGreaterThanZero()
        {
            Assert.True(animal.LifeTimeInMonths > 0);
        }

        [Fact]
        public void IsNewBornFemalePercentageGreaterThanOrEqualZero()
        {
            Assert.True(animal.NewBornFemalePercantage >= 0);
        }

        [Fact]
        public void IsChildCountGreaterThanZero()
        {
            Assert.True((animal.NewBornMaleCount() + animal.NewBornFemaleCount()) > 0);
        }

        [Fact]
        public void CanMaleGetPregnant()
        {
            animal.Gender = Gender.Male;
            Assert.False(animal.IsReadyForPregnancy());
        }
    }
}