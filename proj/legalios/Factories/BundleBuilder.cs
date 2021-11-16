using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;
using HraveMzdy.Legalios.Interfaces;
using HraveMzdy.Legalios.Providers;

namespace HraveMzdy.Legalios.Factories
{
    class BundleBuilder : IBundleBuilder
    {
        private Int16 MIN_VERSION = 2011;
        private IProviderFactory<IProviderSalary, IPropsSalary> SalaryFactory { get; }
        private IProviderFactory<IProviderHealth, IPropsHealth> HealthFactory { get; }
        private IProviderFactory<IProviderSocial, IPropsSocial> SocialFactory { get; }
        private IProviderFactory<IProviderTaxing, IPropsTaxing> TaxingFactory { get; }

        public BundleBuilder()
        {
            SalaryFactory = new FactorySalary();
            HealthFactory = new FactoryHealth();
            SocialFactory = new FactorySocial();
            TaxingFactory = new FactoryTaxing();
        }
        private bool IsNullOrEmpty(IProps props)
        {
            return (props is null || props.Version.Value < MIN_VERSION);
        }
        private bool IsValidBundle(IProps salary, IProps health, IProps social, IProps taxing)
        {
            if (IsNullOrEmpty(salary))
            {
                return false;
            }
            if (IsNullOrEmpty(health))
            {
                return false;
            }
            if (IsNullOrEmpty(social))
            {
                return false;
            }
            if (IsNullOrEmpty(taxing))
            {
                return false;
            }
            return true;
        }
        public IBundleProps GetBundle(IPeriod period)
        {
            IPropsSalary salary = GetSalaryProps(period);
            IPropsHealth health = GetHealthProps(period);
            IPropsSocial social = GetSocialProps(period);
            IPropsTaxing taxing = GetTaxingProps(period);

            if (IsValidBundle(salary, health, social, taxing))
            {
                return new BundleProps(period, salary, health, social, taxing);
            }
            return null;
        }
        private IPropsSalary GetSalaryProps(IPeriod period)
        {
            return SalaryFactory.GetProps(period);
        }
        private IPropsHealth GetHealthProps(IPeriod period)
        {
            return HealthFactory.GetProps(period);
        }
        private IPropsSocial GetSocialProps(IPeriod period)
        {
            return SocialFactory.GetProps(period);
        }
        private IPropsTaxing GetTaxingProps(IPeriod period)
        {
            return TaxingFactory.GetProps(period);
        }
    }
}
