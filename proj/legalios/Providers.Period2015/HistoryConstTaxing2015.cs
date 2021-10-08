using System;
using HraveMzdy.Legalios.Providers.Period2014;

namespace HraveMzdy.Legalios.Providers.Period2015
{
    // ALLOWANCE_PAYER                  Částka slevy na poplatníka
    //
    // ALLOWANCE_DISAB_1ST              Částka slevy na invaliditu 1.stupně poplatníka
    //
    // ALLOWANCE_DISAB_2ND              Částka slevy na invaliditu 2.stupně poplatníka
    //
    // ALLOWANCE_DISAB_3RD              Částka slevy na invaliditu 3.stupně poplatníka
    //
    // ALLOWANCE_STUDY                  Částka slevy na poplatníka studenta
    //
    // ALLOWANCE_CHILD_1ST              Částka slevy na dítě 1.pořadí
    //
    // ALLOWANCE_CHILD_2ND              Částka slevy na dítě 2.pořadí
    //
    // ALLOWANCE_CHILD_3RD              Částka slevy na dítě 3.pořadí
    //
    // FACTOR_ADVANCES                  Sazba daně na zálohový příjem
    //
    // FACTOR_WITHHOLD                  Sazba daně na srážkový příjem
    //
    // FACTOR_SOLITARY                  Sazba daně na solidární zvýšení
    //
    // MIN_AMOUNT_OF_TAXBONUS           Minimální částka pro daňový bonus
    //
    // MAX_AMOUNT_OF_TAXBONUS           Maximální částka pro daňový bonus
    //
    // MARGIN_INCOME_OF_TAXBONUS        Minimální výše příjmu pro nároku na daňový bonus
    //
    // MARGIN_INCOME_OF_ROUNDING        Maximální výše příjmu pro zaokrouhlování
    //
    // MARGIN_INCOME_OF_WITHHOLD        Maximální výše příjmu pro srážkový příjem
    //
    // MARGIN_INCOME_OF_SOLITARY        Minimální výše příjmu pro solidární zvýšení daně
    //
    // MARGIN_INCOME_OF_WHT_AGR         hranice příjmu pro srážkovou daň pro zaměstnace v pracovním poměru (nepodepsal prohlášení)
    //
    // MARGIN_INCOME_OF_WHT_EMP         hranice příjmu pro srážkovou daň pro zaměstnace na dohodu (nepodepsal prohlášení)
    class HistoryConstTaxing2015
    {
        public const Int16 VERSION_CODE = 2015;

        public const Int32 ALLOWANCE_PAYER = HistoryConstTaxing2014.ALLOWANCE_PAYER;
        public const Int32 ALLOWANCE_DISAB_1ST = HistoryConstTaxing2014.ALLOWANCE_DISAB_1ST;
        public const Int32 ALLOWANCE_DISAB_2ND = HistoryConstTaxing2014.ALLOWANCE_DISAB_2ND;
        public const Int32 ALLOWANCE_DISAB_3RD = HistoryConstTaxing2014.ALLOWANCE_DISAB_3RD;
        public const Int32 ALLOWANCE_STUDY = HistoryConstTaxing2014.ALLOWANCE_STUDY;
        public const Int32 ALLOWANCE_CHILD_1ST = HistoryConstTaxing2014.ALLOWANCE_CHILD_1ST;
        public const Int32 ALLOWANCE_CHILD_2ND = 1317;
        public const Int32 ALLOWANCE_CHILD_3RD = 1417;
        public const decimal FACTOR_ADVANCES = HistoryConstTaxing2014.FACTOR_ADVANCES;
        public const decimal FACTOR_WITHHOLD = HistoryConstTaxing2014.FACTOR_WITHHOLD;
        public const decimal FACTOR_SOLITARY = HistoryConstTaxing2014.FACTOR_SOLITARY;
        public const Int32 MIN_AMOUNT_OF_TAXBONUS = HistoryConstTaxing2014.MIN_AMOUNT_OF_TAXBONUS;
        public const Int32 MAX_AMOUNT_OF_TAXBONUS = HistoryConstTaxing2014.MAX_AMOUNT_OF_TAXBONUS;
        public const Int32 MARGIN_INCOME_OF_TAXBONUS = (HistoryConstSalary2015.MIN_MONTHLY_WAGE / 2);
        public const Int32 MARGIN_INCOME_OF_ROUNDING = HistoryConstTaxing2014.MARGIN_INCOME_OF_ROUNDING;
        public const Int32 MARGIN_INCOME_OF_WITHHOLD = HistoryConstTaxing2014.MARGIN_INCOME_OF_WITHHOLD;
        public const Int32 MARGIN_INCOME_OF_SOLITARY = (4 * 26611);
        public const Int32 MARGIN_INCOME_OF_WHT_EMP = HistoryConstTaxing2014.MARGIN_INCOME_OF_WHT_EMP;
        public const Int32 MARGIN_INCOME_OF_WHT_AGR = HistoryConstTaxing2014.MARGIN_INCOME_OF_WHT_AGR;
    }

}
