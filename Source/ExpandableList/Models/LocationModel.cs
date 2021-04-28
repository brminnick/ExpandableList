using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using RandomNameGeneratorLibrary;

namespace ExpandableList
{
    public class LocationModel : ExpandableListModel
    {
        public string Id { get; } = new Guid().ToString();
        public string Name { get; init; } = string.Empty;
        public ContinentType Continent { get; init; } = ContinentType.Unknown;

        IReadOnlyList<LocationModel> LocationSubList { get; set; } = Array.Empty<LocationModel>();

        public static IReadOnlyList<LocationModel> CreateLocationList()
        {
            var random = new Random((int)DateTime.Now.Ticks);
            var taskModelList = new List<LocationModel>();

            for (int i = 0; i < 20; i++)
            {
                var continent = (ContinentType)random.Next(0, Enum.GetNames(typeof(ContinentType)).Length);

                var taskSubList = new List<LocationModel>();

                for (int j = 0; j < random.Next(0, 10); j++)
                    taskSubList.Add(GenerateRandomLocation(continent));

                var taskModel = GenerateRandomLocation(continent);
                taskModel.LocationSubList = taskSubList;

                taskModelList.Add(taskModel);
            }

            return taskModelList;
        }

        public override IReadOnlyList<LocationModel> GetSubList<LocationModel>() => LocationSubList.Cast<LocationModel>().ToList();

        static LocationModel GenerateRandomLocation(ContinentType continent)
        {
            var random = new Random((int)DateTime.Now.Ticks);

            return new LocationModel
            {
                Name = new PlaceNameGenerator(random).GenerateRandomPlaceName(),
                Continent = continent
            };
        }
    }

    public enum ContinentType
    {
        Asia,
        Australia,
        Antarctica,
        Africa,
        Europe,
        NorthAmerica,
        SouthAmerica,
        Unknown
    }
}

namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public record IsExternalInit;
}
