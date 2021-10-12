using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Props
{
    public class PropsBase : IProps
    {
        public const Int16 VERSION_ZERO = 0;
        public PropsBase(Int16 version)
        {
            this.Version = new VersionId(version);
        }
        public PropsBase(VersionId version)
        {
            this.Version = new VersionId(version.Value);
        }
        public VersionId Version { get; }

        public bool IsValid() { return Version.Value != VERSION_ZERO; }
    }
}
