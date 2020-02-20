using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakes
{
    public static class LetterTypeValue
    {
        /*      
         * These values are defined in the database but are hardcoded here 
         * to make it easy for the application to reference one by a constant name
         * and to avoid magic strings in the code. So we consolidated them here.
		 * This is not an exhaustive/historic list; rather limited to only those with special formatting rules (CplHtmlBuilder)
         * 
         * Note that the right hand string MUST be uppercase for some code paths to work
		 * 
        */
        public const string ALTA8 = "ALTA8";
        public const string ALTA8_MortgageNetwork = "ALTA8-MORTGAGENETWORK";

        public const string AL00 = "AL00";
        public const string AR01 = "AR01";
        public const string CA01 = "CA01";
        public const string DC4507 = "4507DC";
        public const string DC4670 = "4670DC";
        public const string FLA01 = "FLA01";
        public const string GA00 = "GA00";
        public const string LA02 = "LA02";
        public const string LA02_ORNTIC = "LA02_ORNTIC";
        public const string OH24 = "OH24";
        public const string NC01 = "NC01";
        public const string NJ00 = "NJ00";
        public const string PA00 = "PA00";
        public const string TX50 = "TX50";
        public const string TX51 = "TX51";

        public const string NM81 = "NM81";
        public const string NM81_1 = "NM81.1";

        public const string NV00_LENDER = "NV00 LENDER";
        public const string NV01_BORROWER_PURCHASER = "NV01 BORROWER/PURCHASER";
        public const string NV02_SELLER = "NV02 SELLER";

        public const string AZ00_LENDER = "AZ00-LENDER";
        public const string AZ01_BORROWER_PURCHASER = "AZ01-BORROWER/PURCHASER";
        public const string AZ02_SELLER = "AZ02-SELLER";

        public const string KY01 = "KY01";

        #region [MO]

        // MO Lender/Buyer/Borrower
        public const string MOCPL = "MOCPL";
        public const string MOCPLC = "MOCPLC";

        // MO Sellers
        public const string MOSCPL = "MOSCPL";
        public const string MOSCPLC = "MOSCPLC";

        #endregion

        public const string IN4597 = "IN4597";

        public const string THIRD_PARTY_DISBURSAL_WV = "THIRD PARTY DISBURSAL WV";

        public const string UT01_SELLER = "UT01 SELLER";

        private static bool LetterTypeIsIn(string value, IEnumerable<string> collection)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            value = value.Trim();

            return collection.Any(i => string.Equals(i, value, StringComparison.OrdinalIgnoreCase));
        }
    }
}
