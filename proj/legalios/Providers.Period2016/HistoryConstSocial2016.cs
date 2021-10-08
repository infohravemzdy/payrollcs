using System;
using HraveMzdy.Legalios.Providers.Period2015;

namespace HraveMzdy.Legalios.Providers.Period2016
{
    // MAX_ANNUALS_BASIS            Maximální roční vyměřovací základ na jednoho pracovníka (tzv.strop)
    //
    // FACTOR_EMPLOYER              Sazba - standardní sociálního pojištění - zaměstnavatele
    //
    // FACTOR_EMPLOYER_HIGHER       Sazba - vyší sociálního pojištění - zaměstnavatele
    //
    // FACTOR_EMPLOYEE              Sazba sociálního pojištění - zaměstnance
    //
    // FACTOR_EMPLOYEE_REDUCE       Snížení sazby sociálního pojištění - zaměstnance - s důchodovým spořením
    //
    // FACTOR_EMPLOYEE_GARANT       Sazba důchodového spoření - zaměstnance - s důchodovým spořením
    //
    // MARGIN_INCOME_EMP            hranice příjmu pro vznik účasti na pojištění pro zaměstnace v pracovním poměru
    //
    // MARGIN_INCOME_AGR            hranice příjmu pro vznik účasti na pojištění pro zaměstnace na dohodu
    class HistoryConstSocial2016
    {
        public const Int16 VERSION_CODE = 2016;

        public const Int32 MAX_ANNUALS_BASIS = 1296288;
        public const decimal FACTOR_EMPLOYER = HistoryConstSocial2015.FACTOR_EMPLOYER;
        public const decimal FACTOR_EMPLOYER_HIGHER = HistoryConstSocial2015.FACTOR_EMPLOYER_HIGHER;
        public const decimal FACTOR_EMPLOYEE = HistoryConstSocial2015.FACTOR_EMPLOYEE;
        public const decimal FACTOR_EMPLOYEE_REDUCE = 0;
        public const decimal FACTOR_EMPLOYEE_GARANT = 0;
        public const Int32 MARGIN_INCOME_EMP = HistoryConstSocial2015.MARGIN_INCOME_EMP;
        public const Int32 MARGIN_INCOME_AGR = HistoryConstSocial2015.MARGIN_INCOME_AGR;
    }

}
