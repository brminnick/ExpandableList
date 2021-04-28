using System.Collections.Generic;

namespace ExpandableList
{
    public abstract class ExpandableListModel
    {
        public abstract IReadOnlyList<T> GetSubList<T>() where T : ExpandableListModel;
    }
}
