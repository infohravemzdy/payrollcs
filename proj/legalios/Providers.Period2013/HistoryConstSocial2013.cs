using System;
using HraveMzdy.Legalios.Providers.Period2012;

namespace HraveMzdy.Legalios.Providers.Period2013
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
    class HistoryConstSocial2013var02
    {
        public const decimal FACTOR_EMPLOYEE_REDUCE = 3;
        public const decimal FACTOR_EMPLOYEE_GARANT = 5;
    }
    class HistoryConstSocial2013
    {
        public const Int16 VERSION_CODE = 2013;

        public const Int32 MAX_ANNUALS_BASIS = 1242432;
        public const decimal FACTOR_EMPLOYER = HistoryConstSocial2012.FACTOR_EMPLOYER;
        public const decimal FACTOR_EMPLOYER_HIGHER = HistoryConstSocial2012.FACTOR_EMPLOYER_HIGHER;
        public const decimal FACTOR_EMPLOYEE = HistoryConstSocial2012.FACTOR_EMPLOYEE;
        public const decimal FACTOR_EMPLOYEE_REDUCE = HistoryConstSocial2012.FACTOR_EMPLOYEE_REDUCE;
        public const decimal FACTOR_EMPLOYEE_GARANT = HistoryConstSocial2012.FACTOR_EMPLOYEE_GARANT;
        public const Int32 MARGIN_INCOME_EMP = HistoryConstSocial2012.MARGIN_INCOME_EMP;
        public const Int32 MARGIN_INCOME_AGR = HistoryConstSocial2012.MARGIN_INCOME_AGR;
    }

}
