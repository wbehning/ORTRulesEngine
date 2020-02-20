using System;
using System.Text;

namespace RulesFakes
{
    public class FakeAgentDisplayRule
    {
        public FakeRuleEngine<FakeAgentDisplayRule> RulesEngine;

        public FakeAgentDisplayRule(FakeMergeData mergeData)
        {
            this.mergeData = mergeData;
            RulesEngine = new FakeRuleEngine<FakeAgentDisplayRule>();
        }

        private FakeMergeData mergeData { get; set; }

    #region Rule Defined Fields

        private string _cPLAgentDisplay;
        public string CPLAgentDisplay
        {
            get
            {
                if (string.IsNullOrEmpty(_cPLAgentDisplay))
                {
                    RulesEngine.ExecuteCPLSpecifications(this, "CPLAgentDisplay");
                }

                return _cPLAgentDisplay;
            }

            set { _cPLAgentDisplay = value; }
        }

        private string _isOrtisParentOrNational;
        public string IsOrtisParentOrNational
        {
            get
            {
                if (string.IsNullOrEmpty(_isOrtisParentOrNational))
                {
                    RulesEngine.ExecuteCPLSpecifications(this, "IsOrtisParentOrNational");
                }
                return _isOrtisParentOrNational;
            }
            set { _isOrtisParentOrNational = value; }
        }

        

        private string _hideAgentInfoForNJLetter;
        public string HideAgentInfoForNJLetter
        {
            get
            {
                if (string.IsNullOrEmpty(_hideAgentInfoForNJLetter))
                {
                    RulesEngine.ExecuteCPLSpecifications(this, "HideAgentInfoForNJLetter");
                }

                return _hideAgentInfoForNJLetter;
            }

            set { _hideAgentInfoForNJLetter = value; }
        }

        #endregion Rule Defined Fields


        #region CPL Properties

        public string HideAgentInfoOnLetter {
            get { return mergeData.ValidatedLetterRequest.HideAgentInfoOnLetter.ToString().ToLower(); }

        }

        public string TransactionPropertyState
        {
            get
            {
                return mergeData.TransactionPropertyState;
            }
        }

        public string IsAgentSelected
        {
            get
            {
                if (!mergeData.IsForBlanketLetter && mergeData.ClosingAttorney != null &&
                    !string.IsNullOrWhiteSpace(mergeData.ClosingAttorney.NameLine1))
                {
                    return true.ToString();
                }
                return false.ToString();
            }
        }

        public string IsForBlanketLetter
        {
            get { return mergeData.IsForBlanketLetter.ToString().ToLower(); }
        }

        public string IsParent {
            get { return mergeData.Agent.IsParent.ToString().ToLower(); }
        }

        public string IsOrtris
        {
            get { return mergeData.Agent.IsORTRIS.ToString().ToLower(); }
        }
        
        public string IsNational
        {
            get { return mergeData.Agent.isNational.ToString().ToLower(); }
        }

        public string HasClosingAttorney
        {
            get
            {
                return
                    (mergeData.ClosingAttorney != null && !string.IsNullOrEmpty(mergeData.ClosingAttorney.NameLine1))
                        .ToString().ToLower();
            }
        }

        public string TransactionType { get; set; }
        public string Underwriter { get; }

        public string LetterType
        {
            get { return mergeData.LetterType.Code; }
        }

        #endregion CPL Properties

        public override bool Equals(object obj)
        {
            var cpl = obj as FakeAgentDisplayRule;
            if (cpl == null)
            {
                return false;
            }

            return LetterType.Equals(cpl.LetterType)
                   && TransactionPropertyState.Equals(cpl.TransactionPropertyState)
                   && TransactionType.Equals(cpl.TransactionType)
                   && Underwriter.Equals(cpl.Underwriter);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // Choose large primes to avoid hashing collisions
                const int hashingBase = (int) 2166136261;
                const int hashingMultiplier = 16777619;

                int hash = hashingBase;
                hash = (hash * hashingMultiplier) ^ (!ReferenceEquals(null, LetterType) ? LetterType.GetHashCode() : 0);
                hash = (hash * hashingMultiplier) ^ (!ReferenceEquals(null, TransactionPropertyState) ? TransactionPropertyState.GetHashCode() : 0);
                hash = (hash * hashingMultiplier) ^ (!ReferenceEquals(null, TransactionType) ? TransactionType.GetHashCode() : 0);
                hash = (hash * hashingMultiplier) ^ (!ReferenceEquals(null, Underwriter) ? Underwriter.GetHashCode() : 0);
                return hash;
            }
        }
    }
}