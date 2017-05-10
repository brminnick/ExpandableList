using System.Collections.Generic;

namespace ExpandableList.Shared
{
    public class Chore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }

        public List<Chore> SubchoreList { get; set; }

        public static List<Chore> CreateChoreList()
        {
            var groceriesDetails = new List<Chore>
            {
                new Chore{ Name = "Buy Milk" },
                new Chore{ Name = "Buy Bread" }
            };

            var groceryChore = new Chore
            {
                Name = "Grocery Shopping",
                Done = false,
                SubchoreList = groceriesDetails
            };

            var carWashChore = new Chore
            {
                Name = "Car Wash"
            };

            return new List<Chore> { groceryChore, carWashChore };
        }
    }
}

