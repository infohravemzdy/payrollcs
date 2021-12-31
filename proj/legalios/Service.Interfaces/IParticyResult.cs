using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HraveMzdy.Legalios.Service.Interfaces
{
    public interface IParticyResult
    {
        Int16 ParticyCode { get; }
        Int32 ResultBasis { get; }
        Int32 ResultValue { get; }
        Int32 SetResultValue(Int32 value);
    }
}
