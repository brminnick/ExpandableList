using System.Collections.Generic;

namespace ExpandableList.Shared
{
    public abstract class ExpandableListModel
    {
        public abstract List<T> GetSubList<T>() where T : ExpandableListModel;
    }
}
