# Coop Simulator

The simulation is generically prepared to calculate the population of coop of different animals at the end of a certain period.

# Project Requirements

- .NET Core 3.1

# Use of

The project is located in the CoopCase folder.
*To run the project while in this directory*
```
dotnet build -c Release
dotnet run
```
*If you want to start from the directory where the .sln file is*
```
cd CoopCase
dotnet build -c Release
dotnet run
```
# Configuration
The `appSettings.json` structure that is currently added to the project is as follows. If you wish, you can create a new object (for example, open a Chicken object with the same properties under the Rabbit object), change the value of the 'Animal' variable at the top of the json file, and change the structure of the project for another type and its properties.
```
{
  "Animal": "Rabbit",
  "Rabbit": {
    "NewBornCount": "8",
    "NewBornFemalePercentage": "75",
    "DurationOfPregnancy": "1",
    "MinAgeForFertilityInMonths": "6",
    "LifeTimeInMonths": "12"
  }
}
```
## Benchmark Results
~~Not Provided~~

## Maximum Values

**Cycle**: 30

**Total Population**: 88128

## Current Hardware Information
**CPU**: i7-8750H 2.20GHz

**Memory**: 16GB
