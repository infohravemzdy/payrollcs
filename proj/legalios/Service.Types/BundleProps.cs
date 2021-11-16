using System;
using HraveMzdy.Legalios.Props;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Service.Types
{
    public class BundleProps : IBundleProps
    {
        public BundleProps(IPeriod period, 
            IPropsSalary salary, 
            IPropsHealth health, 
            IPropsSocial social, 
            IPropsTaxing taxing)
        {
            PeriodProps = (IPeriod)period.Clone();
            SalaryProps = salary;
            HealthProps = health;
            SocialProps = social;
            TaxingProps = taxing;
        }
        public IPeriod PeriodProps { get; }
        public IPropsSalary SalaryProps { get; }
        public IPropsHealth HealthProps { get; }
        public IPropsSocial SocialProps { get; }
        public IPropsTaxing TaxingProps { get; }
        public static IBundleProps Empty(IPeriod period)
        {
            return new BundleProps(period,
                PropsSalary.Empty(),
                PropsHealth.Empty(),
                PropsSocial.Empty(),
                PropsTaxing.Empty());
        }
    }
}
