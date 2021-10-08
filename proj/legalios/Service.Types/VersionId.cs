using System;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Service.Types
{
    public sealed record VersionId(Int16 Value) : IVersionId<Int16>, IComparable<VersionId>
    {
        public static VersionId New() => new(0);

        public static VersionId Get(Int16 value) => new(value);


        public int CompareTo(VersionId other)
        {
            return this.Value.CompareTo(other.Value);
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
