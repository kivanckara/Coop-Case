using Coop.Business;
using Coop.Entity;
using System.Collections.Generic;
using Xunit;

namespace Coop.Test
{
    public class Coop
    {
        private readonly Business.Coop coop;

        public Coop()
        {
            coop = new Business.Coop();
        }

        [Fact]
        public void IsStartCoopReturnListNotEqualToNull()
        {
            Assert.NotNull(coop.StartCoop());
        }

        [Fact]
        public void IsAddChildrenMethodWorking()
        {
            var list = new List<Entity.Animal>()
            {
              new Entity.Animal{Gender = Gender.Female},
              new Entity.Animal{Gender = Gender.Male}
            };
            int oldItemCount = list.Count;

            coop.AddChildren(Gender.Male, 1, ref list);

            int newItemCount = list.Count;
            Assert.True(newItemCount > oldItemCount);
        }

        [Fact]
        public void IsRemoveDeathsMethodWorking()
        {
            var list = new List<Entity.Animal>()
            {
              new Entity.Animal{Id = 1, Gender = Gender.Female},
              new Entity.Animal{Id = 2, Gender = Gender.Male},
              new Entity.Animal{Id = 22, Gender = Gender.Female},
              new Entity.Animal{Id = 55, Gender = Gender.Male},
              new Entity.Animal{Id = 5, Gender = Gender.Female},
              new Entity.Animal{Id = 6, Gender = Gender.Male}
            };
            var deathList = new List<int> { 2, 5 };

            coop.RemoveDeaths(deathList, ref list);

            int newItemCount = list.Count;
            Assert.Equal(4, newItemCount);
        }

        [Fact]
        public void IsProcessAnimalGroupGivingResults()
        {
            var animal = new Entity.Animal();

            #region test data

            var list = new List<Entity.Animal>()
            {
              new Entity.Animal{Id = 1,Age=animal.MinAgeForFertilityInMonths,MonthOfPregnancy =1, Gender = Gender.Female},
              new Entity.Animal{Id = 2,Age=animal.MinAgeForFertilityInMonths, Gender = Gender.Male},
              new Entity.Animal{Id = 3, Gender = Gender.Female},
              new Entity.Animal{Id = 4, Gender = Gender.Male},
              new Entity.Animal{Id = 5, Gender = Gender.Female},
              new Entity.Animal{Id = 6,Age=animal.MinAgeForFertilityInMonths, Gender = Gender.Male},
              new Entity.Animal{Id = 7, Gender = Gender.Female},
              new Entity.Animal{Id = 8, Gender = Gender.Male},
              new Entity.Animal{Id = 9,Age=animal.MinAgeForFertilityInMonths,MonthOfPregnancy =1, Gender = Gender.Female},
              new Entity.Animal{Id = 10, Gender = Gender.Male}
            };

            #endregion test data

            var (newBornMale, newBornFemale, _) = coop.ProcessAnimalGroup(list, true);
            Assert.True(newBornFemale > 0 || newBornMale > 0);
        }
        [Fact]
        public void DoLogAfterChildrenAppend()
        {
            var list = coop.StartCoop();
            new Log().Subscribe(coop);
            coop.AddChildren(Gender.Female, 2,ref list);
        }
        [Fact]
        public void SimulationCompleteWithNoException()
        {
            coop.Simulate(6);
        }
    }
}