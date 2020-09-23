using Coop.Entity.Interface;
using Coop.Global;
using Microsoft.Extensions.Configuration;

namespace Coop.Entity
{
    public class Animal : IAnimal
    {
        public string Name => animal ?? "";
        public int Id { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int MinAgeForFertilityInMonths => _configuration[$"{animal}:MinAgeForFertilityInMonths"].ToInt32().KeepPositive();
        public int DurationOfPregnancy => _configuration[$"{animal}:DurationOfPregnancy"].ToInt32().KeepPositive();
        public int NewBornCount => _configuration[$"{animal}:NewBornCount"].ToInt32().KeepPositive();
        public int NewBornFemalePercantage => _configuration[$"{animal}:NewBornFemalePercentage"].ToInt32().KeepPositive();
        public int LifeTimeInMonths => _configuration[$"{animal}:LifeTimeInMonths"].ToInt32().KeepPositive();
        public int MonthOfPregnancy { get; set; }

        private readonly IConfiguration _configuration;
        private readonly string animal;
        private readonly string settingsFile = "appsettings.json";

        public Animal()
        {
            _configuration = new ConfigurationBuilder()
                   .AddJsonFile(settingsFile, true, true)
                   .Build();

            animal = _configuration["Animal"];
        }

        public int NewBornFemaleCount() => (NewBornCount * ((double)NewBornFemalePercantage / 100).ToDouble()).ToInt32();

        public int NewBornMaleCount() => (NewBornCount * ((double)(100 - NewBornFemalePercantage) / 100).ToDouble()).ToInt32();

        public bool IsReadyForPregnancy() => Gender == Gender.Female && (Age >= MinAgeForFertilityInMonths) && !IsPregnant();

        public bool IsPregnant() => MonthOfPregnancy > 0;

        public bool IsFemale() => Gender == Gender.Female;

        public bool IsMale() => Gender == Gender.Male;
    }
}