using FluentAssertions;
using HraveMzdy.Legalios.Service.Errors;
using HraveMzdy.Legalios.Service.Interfaces;

namespace LegaliosTest.Service
{
    public class Service_Legalios_Example_SocialTest : Service_Legalios_Example_BaseTest
    {
        protected void ShoulBeValidBundle(ResultMonad.Result<IBundleProps, IHistoryResultError> testResult, short resultYear, short resultMonth)
        {
            testResult.IsSuccess.Should().BeTrue();
            testResult.Value.Should().NotBeNull();
            testResult.Value.Should().BeAssignableTo<IBundleProps>();
            testResult.Value.PeriodProps.Year.Should().Be(resultYear);
            testResult.Value.PeriodProps.Month.Should().Be(resultMonth);
            testResult.Value.SocialProps.Should().NotBeNull();
        }
    }
}