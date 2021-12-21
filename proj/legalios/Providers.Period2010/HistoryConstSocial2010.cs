using System;

namespace HraveMzdy.Legalios.Providers.Period2010
{
    // MAX_ANNUALS_BASIS            Maximální roční vyměřovací základ na jednoho pracovníka (tzv.strop)
    //
    // FACTOR_EMPLOYER              Sazba - standardní sociálního pojištění - zaměstnavatele
    //
    // FACTOR_EMPLOYER_HIGHER       Sazba - vyší sociálního pojištění - zaměstnavatele
    //
    // FACTOR_EMPLOYEE              Sazba sociálního pojištění - zaměstnance
    //
    // FACTOR_EMPLOYEE_GARANT       Sazba důchodového spoření - zaměstnance - s důchodovým spořením
    //
    // FACTOR_EMPLOYEE_REDUCE       Snížení sazby sociálního pojištění - zaměstnance - s důchodovým spořením
    //
    // MARGIN_INCOME_EMP            hranice příjmu pro vznik účasti na pojištění pro zaměstnace v pracovním poměru
    //
    // MARGIN_INCOME_AGR            hranice příjmu pro vznik účasti na pojištění pro zaměstnace na dohodu
    class HistoryConstSocial2010
    {
        public const Int16 VERSION_CODE = 2010;

        public const Int32 MAX_ANNUALS_BASIS = 1707048;
        public const decimal FACTOR_EMPLOYER = 25m;
        public const decimal FACTOR_EMPLOYER_HIGHER = 0m;
        public const decimal FACTOR_EMPLOYEE = 6.5m;
        public const decimal FACTOR_EMPLOYEE_REDUCE = 0m;
        public const decimal FACTOR_EMPLOYEE_GARANT = 0m;
        public const Int32 MARGIN_INCOME_EMP = 2000;
        public const Int32 MARGIN_INCOME_AGR = 0;
    }
}
