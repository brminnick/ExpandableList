using System;
using System.Collections.Generic;

namespace ExpandableList.Shared
{
    public class ChoreModel : ExpandableListModel
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
        List<ChoreModel> ChoreSubList { get; set; }
        #endregion

        #region Constructors
        private ChoreModel()
        {
            
        }
        #endregion

        #region Methods
        public static List<ChoreModel> CreateChoreList()
        {
            var groceriesDetails = new List<ChoreModel>
            {
                new ChoreModel{ Name = "Buy Milk" },
                new ChoreModel{ Name = "Buy Bread" }
            };

            var groceryChore = new ChoreModel
            {
                Name = "Grocery Shopping",
                Done = false,
                ChoreSubList = groceriesDetails
            };

            var carWashChore = new ChoreModel
            {
                Name = "Car Wash"
            };

            return new List<ChoreModel> { groceryChore, carWashChore };
        }

        public override List<ChoreModel> GetSubList<ChoreModel>()
        {
            return ChoreSubList as List<ChoreModel>;
        }
        #endregion
    }

}

