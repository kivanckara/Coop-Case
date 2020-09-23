using Coop.Business.Event;
using Coop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coop.Business
{
    public class Coop
    {
        public event EventHandler<KindEventArgs> BreedProcess;

        private const int animalCountForThread = 100;

        public void Simulate(int cycles)
        {
            List<Animal> animals = StartCoop();

            var totalNewBornMale = 0;
            var totalNewBornFemale = 0;
            var totaldeaths = 0;

            new Log().Subscribe(this);

            for (int cycle = 1; cycle <= cycles; cycle++)
            {
                var newBornMaleCount = 0;
                var newBornFemaleCount = 0;
                var deaths = new List<int>();

                var threadLimit = (double)animals.Count / animalCountForThread;
                if (threadLimit == 0)
                    threadLimit = 1;

                var taskList = new List<Task<(int newBornMale, int newBornFemale, List<int> deaths)>>();
                for (int i = 0; i < threadLimit; i++)
                {
                    var animalList = animals.Skip(i * animalCountForThread).Take(animalCountForThread).ToList();

                    taskList.Add(Task.Run(() => ProcessAnimalGroup(animalList, cycle > 1)));
                }

                Task.WaitAll(taskList.ToArray());

                foreach (var task in taskList)
                {
                    (int taskNewBornMale, int taskNewBornFemale, List<int> taskdeaths) = task.Result;
                    newBornMaleCount += taskNewBornMale;
                    newBornFemaleCount += taskNewBornFemale;
                    deaths.AddRange(taskdeaths);
                }

                totalNewBornMale += newBornMaleCount;
                totalNewBornFemale += newBornFemaleCount;
                totaldeaths += deaths.Count;

                Console.WriteLine($"---- Cycle {cycle} Results Start----");

                AddChildren(Gender.Female, newBornFemaleCount, ref animals);
                AddChildren(Gender.Male, newBornMaleCount, ref animals);
                RemoveDeaths(deaths, ref animals);

                Console.WriteLine($"---- Cycle {cycle} Results End----\r\n");
            }
            Console.WriteLine($"*** End of the {cycles} result ***");
            Console.WriteLine($"{totalNewBornFemale} females, {totalNewBornMale} males borned and {totaldeaths} member death. \r\n Current Population: {animals.Count}");
        }

        public (int newBornMale, int newBornFemale, List<int> deaths) ProcessAnimalGroup(List<Animal> animals, bool increaseAge)
        {
            var newBornMaleCount = 0;
            var newBornFemaleCount = 0;
            var deaths = new List<int>();

            foreach (var animal in animals)
            {
                if (animal.Age > animal.LifeTimeInMonths)
                {
                    deaths.Add(animal.Id);
                    continue;
                }
                if (increaseAge)
                {
                    animal.Age++;
                }
                if (animal.IsFemale())
                {
                    if (animal.IsReadyForPregnancy())
                    {
                        animal.MonthOfPregnancy++;
                    }
                    else if (animal.IsPregnant() && animal.MonthOfPregnancy >= animal.DurationOfPregnancy)
                    {
                        newBornMaleCount += animal.NewBornMaleCount();
                        newBornFemaleCount += animal.NewBornFemaleCount();

                        animal.MonthOfPregnancy = 0;
                    }
                }
            }

            return (newBornMaleCount, newBornFemaleCount, deaths);
        }

        public List<Animal> StartCoop()
        {
            var startAge = new Animal().MinAgeForFertilityInMonths;

            var list = new List<Animal>()
            {
              new Animal{Id = 1, Age = startAge, Gender = Gender.Female},
              new Animal{Id = 2, Age = startAge, Gender = Gender.Male}
            };

            return list;
        }

        public void AddChildren(Gender gender, int childCount, ref List<Animal> list)
        {
            for (int i = 0; i < childCount; i++)
            {
                list.Add(new Animal
                {
                    Id = list.LastOrDefault()?.Id + 1 ?? 1,
                    Gender = gender
                });
            }

            BreedProcess?.Invoke(this, new KindEventArgs(new Animal().Name, gender, childCount));
        }

        public void RemoveDeaths(List<int> Ids, ref List<Animal> list) => list = list.Except(list.Where(q => Ids.Any(a => a == q.Id))).ToList();
    }
}