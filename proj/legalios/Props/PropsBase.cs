using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Props
{
    public abstract class PropsBase : IProps
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

        public Tuple<Int32, Int32, IEnumerable<T>> MaximResultCut<T>(IEnumerable<T> particyList, IEnumerable<T> incomeList, Int32 annuityBasis, Int32 annualyMaxim) 
            where T : IParticyResult
        {
            Int32 annualsBasis = Math.Max(0, annualyMaxim - annuityBasis);
            var resultInit = new Tuple<Int32, Int32, IEnumerable<T>>(
                annualyMaxim, annualsBasis, particyList);

            var resultList = incomeList.Aggregate(resultInit,
                (agr, x) => {
                    Int32 cutAnnualsBasis = 0;
                    Int32 rawAnnualsBasis = x.ResultBasis;
                    Int32 remAnnualsBasis = agr.Item2;

                    if (x.ParticyCode != 0)
                    {
                        cutAnnualsBasis = rawAnnualsBasis;
                        if (agr.Item1 > 0)
                        {
                            var ovrAnnualsBasis = Math.Max(0, rawAnnualsBasis - agr.Item2);
                            cutAnnualsBasis = (rawAnnualsBasis - ovrAnnualsBasis);
                        }
                        remAnnualsBasis = Math.Max(0, (agr.Item2 - cutAnnualsBasis));
                    }

                    x.SetResultValue(Math.Max(0, cutAnnualsBasis));
                    return new Tuple<Int32, Int32, IEnumerable<T>>(
                        agr.Item1, remAnnualsBasis, agr.Item3.Concat(new T[] { x }).ToArray());
                });

            return resultList;
        }
    }
}
