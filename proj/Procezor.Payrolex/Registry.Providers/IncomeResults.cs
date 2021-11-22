using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Service.Interfaces;
using Procezor.Payrolex.Registry.Constants;

namespace Procezor.Payrolex.Registry.Providers
{
    // IncomeGross		INCOME_GROSS
    class IncomeGrossResult : PayrolexTermResult
    {
        public IncomeGrossResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // IncomeNetto		INCOME_NETTO
    class IncomeNettoResult : PayrolexTermResult
    {
        public IncomeNettoResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }
    // EmployerCosts		EMPLOYER_COSTS
    public class EmployerCostsResult : PayrolexTermResult
    {
        public EmployerCostsResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }
}
