
using System;

namespace ORTRulesEngine.Entities
{
    public class CPLLetterBodyRule : BaseRule<CPLLetterBodyRule>
    {
        private string _cPL_Letter_File_Name;

        public CPLLetterBodyRule(string state, string transactionType, string underwriter, string letterType)
        {
            State = state;
            TransactionType = transactionType;
            Underwriter = underwriter;
            LetterType = letterType;
        }

        private string _isOrntic;
        public string Is_Orntic
        {
            get
            {
                if (string.IsNullOrEmpty(_isOrntic))
                {
                    RulesEngine.ExecuteSpecifications(this, "Is_Orntic", "Agency");
                }

                return _isOrntic;
            }

            set { _isOrntic = value; }
        }

        public string CPL_Letter_File_Name
        {
            get
            {
                if (string.IsNullOrEmpty(_cPL_Letter_File_Name))
                {
                    RulesEngine.ExecuteSpecifications(this, "CPLLetterFileName", "CPL");
                }

                return _cPL_Letter_File_Name;
            }

            set { _cPL_Letter_File_Name = value; }
        }

        public string State { get; set; }
        public string TransactionType { get; set; }
        public string Underwriter { get; set; }
        public string LetterType { get; set; }

        public string HideAgentInfoForNJLetter { get; set; }

        public string HideAgentInfoOnLetter { get; set; }

        public string TransactionPropertyState { get; set; }

        public string AddresseeType { get; set; }
        public string HasClosingAttorney { get; set; }

        public string IsForBlanketLetter { get; set; }
        public string IsNational { get; set; }
        public string IsOrtris { get; set; }
        public string IsOrtrisParentOrNational { get; set; }
        public string IsParent { get; set; }


        //    public override bool Equals(object obj)
        //    {
        //        var cpl = obj as CPLLetterBodyRule;
        //        if (cpl == null)
        //        {
        //            return false;
        //        }

        //        return LetterType.Equals(cpl.LetterType, StringComparison.InvariantCultureIgnoreCase)
        //               && State.Equals(cpl.State, StringComparison.InvariantCultureIgnoreCase)
        //               && TransactionType.Equals(cpl.TransactionType, StringComparison.InvariantCultureIgnoreCase)
        //               && Underwriter.Equals(cpl.Underwriter, StringComparison.InvariantCultureIgnoreCase);
        //    }

        //    public override int GetHashCode()
        //    {
        //        unchecked
        //        {
        //            // Choose large primes to avoid hashing collisions
        //            const int hashingBase = (int)2166136261;
        //            const int hashingMultiplier = 16777619;

        //            int hash = hashingBase;
        //            hash = (hash * hashingMultiplier) ^ (!ReferenceEquals(null, LetterType) ? LetterType.GetHashCode() : 0);
        //            hash = (hash * hashingMultiplier) ^ (!ReferenceEquals(null, State) ? State.GetHashCode() : 0);
        //            hash = (hash * hashingMultiplier) ^ (!ReferenceEquals(null, TransactionType) ? TransactionType.GetHashCode() : 0);
        //            hash = (hash * hashingMultiplier) ^ (!ReferenceEquals(null, Underwriter) ? Underwriter.GetHashCode() : 0);
        //            return hash;
        //        }
        //    }
    }
}
