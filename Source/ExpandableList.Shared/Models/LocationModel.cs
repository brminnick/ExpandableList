using System;
using System.Collections.Generic;

using RandomNameGeneratorLibrary;

namespace ExpandableList.Shared
{
    public class LocationModel : ExpandableListModel
    {
        #region Properties
        public string Id { get; private set; }
        public string Name { get; private set; }
        public ContinentType Continent { get; private set; }

        List<LocationModel> LocationSubList { get; set; }
        #endregion

        #region Constructors
        private LocationModel()
        {
            Id = new Guid().ToString();
            Name = string.Empty;
            Continent = ContinentType.Unknown;
        }
        #endregion

        #region Methods
        public static List<LocationModel> CreateLocationList()
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

        public override List<LocationModel> GetSubList<LocationModel>()
        {
            return LocationSubList as List<LocationModel>;
        }

        static LocationModel GenerateRandomLocation(ContinentType continent)
        {
            var random = new Random((int)DateTime.Now.Ticks);

            return new LocationModel
            {
                Name = new PlaceNameGenerator(random).GenerateRandomPlaceName(),
                Continent = continent
            };
        }
        #endregion
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

