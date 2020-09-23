using System;

namespace addressbook_tests_auto_white
{
    public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
    {
        public string Name { get; set; }
        public int CompareTo(GroupData other)
        {
            return Name.CompareTo(other.Name);
        }

        public bool Equals(GroupData other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name.Equals(other.Name);
        }

        public override string ToString()
        {
            return $"Name = {Name}";
        }
    }
}