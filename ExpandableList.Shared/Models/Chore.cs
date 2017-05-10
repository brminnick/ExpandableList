using System.Collections.Generic;

namespace ExpandableList.Shared
{
	public class Chore
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool Done { get; set; }

		public List<Chore> Subchore { get; set; }
	}
}

