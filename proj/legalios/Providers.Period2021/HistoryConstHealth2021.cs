using System;
using HraveMzdy.Legalios.Providers.Period2020;

namespace HraveMzdy.Legalios.Providers.Period2021
{
    // MIN_MONTHLY_BASIS     Minimální základ zdravotního pojištění na jednoho pracovníka
    //
    // MAX_ANNUALS_BASIS     Maximální roční vyměřovací základ na jednoho pracovníka (tzv.strop)
    //
    // LIM_MONTHLY_STATE     Vyměřovací základ ze kterého platí pojistné stát za státní pojištěnce (mateřská, studenti, důchodci)
    //
    // LIM_MONTHLY_DIS50     Vyměřovací základ ze kterého platí pojistné stát za státní pojištěnce (mateřská, studenti, důchodci)
    //                      u zaměstnavatele zaměstnávajícího více než 50% osob OZP
    // FACTOR_COMPOUND       složená sazba zdravotního pojištění (zaměstnace + zaměstnavatele)
    //
    // FACTOR_EMPLOYEE       podíl sazby zdravotního pojištění připadajícího na zaměstnace (1/FACTOR_EMPLOYEE)
    //
    // MARGIN_INCOME_EMP     hranice příjmu pro vznik účasti na pojištění pro zaměstnace v pracovním poměru
    //
    // MARGIN_INCOME_AGR     hranice příjmu pro vznik účasti na pojištění pro zaměstnace na dohodu
    class HistoryConstHealth2021
    {
        public const Int16 VERSION_CODE = 2021;

        public const Int32 MIN_MONTHLY_BASIS = HistoryConstSalary2021.MIN_MONTHLY_WAGE;
        public const Int32 MAX_ANNUALS_BASIS = HistoryConstHealth2020.MAX_ANNUALS_BASIS;
        public const Int32 LIM_MONTHLY_STATE = HistoryConstHealth2020.LIM_MONTHLY_STATE;
        public const Int32 LIM_MONTHLY_DIS50 = 13088;
        public const decimal FACTOR_COMPOUND = HistoryConstHealth2020.FACTOR_COMPOUND;
        public const decimal FACTOR_EMPLOYEE = HistoryConstHealth2020.FACTOR_EMPLOYEE;
        public const Int32 MARGIN_INCOME_EMP = 3500;
        public const Int32 MARGIN_INCOME_AGR = HistoryConstHealth2020.MARGIN_INCOME_AGR;
    }

}
