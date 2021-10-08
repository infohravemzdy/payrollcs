namespace HraveMzdy.Legalios.Service.Interfaces
{
    public interface IBundleProps
    {
        IPeriod PeriodProps { get; }
        IPropsSalary SalaryProps { get; }
        IPropsHealth HealthProps { get; }
        IPropsSocial SocialProps { get; }
        IPropsTaxing TaxingProps { get; }
    }
}
