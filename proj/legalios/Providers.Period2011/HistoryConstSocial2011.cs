using HraveMzdy.Legalios.Providers.Period2010;
using System;

namespace HraveMzdy.Legalios.Providers.Period2011
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
    class HistoryConstSocial2011
    {
        public const Int16 VERSION_CODE = 2011;

        public const Int32 MAX_ANNUALS_BASIS = 1781280;
        public const decimal FACTOR_EMPLOYER = HistoryConstSocial2010.FACTOR_EMPLOYER;
        public const decimal FACTOR_EMPLOYER_HIGHER = 26m;
        public const decimal FACTOR_EMPLOYEE = HistoryConstSocial2010.FACTOR_EMPLOYEE;
        public const decimal FACTOR_EMPLOYEE_REDUCE = HistoryConstSocial2010.FACTOR_EMPLOYEE_REDUCE;
        public const decimal FACTOR_EMPLOYEE_GARANT = HistoryConstSocial2010.FACTOR_EMPLOYEE_GARANT;
        public const Int32 MARGIN_INCOME_EMP = HistoryConstSocial2010.MARGIN_INCOME_EMP;
        public const Int32 MARGIN_INCOME_AGR = HistoryConstSocial2010.MARGIN_INCOME_AGR;
    }
}
