
using System;

namespace ORTRulesEngine.Entities
{
    public class CPLAgentDisplayRule : BaseRule<CPLAgentDisplayRule>
    {

        #region Rule Defined Properties

        private string _cplAgentDisplay;
        public string CPLAgentDisplay
        {
            get
            {
                if (string.IsNullOrEmpty(_cplAgentDisplay))
                {
                    RulesEngine.ExecuteSpecifications(this, nameof(CPLAgentDisplay), "CPL");
                }

                return _cplAgentDisplay;
            }

            protected set { _cplAgentDisplay = value; }
        }

        private string _isOrtrisParentOrNational;
        public string IsOrtrisParentOrNational
        {
            get
            {
                if (string.IsNullOrEmpty(_isOrtrisParentOrNational))
                {
                    RulesEngine.ExecuteSpecifications(this, nameof(IsOrtrisParentOrNational), "CPL");
                }
                return _isOrtrisParentOrNational;
            }
            protected set { _isOrtrisParentOrNational = value; }
        }

        private string _hideAgentInfoForNJLetter;
        public string HideAgentInfoForNJLetter
        {
            get
            {
                if (string.IsNullOrEmpty(_hideAgentInfoForNJLetter))
                {
                    RulesEngine.ExecuteSpecifications(this, nameof(HideAgentInfoForNJLetter), "CPL");
                }

                return _hideAgentInfoForNJLetter;
            }

            protected set { _hideAgentInfoForNJLetter = value; }
        }

        #endregion Rule Defined Properties


        #region CPL Properties

        public string HideAgentInfoOnLetter { get; set; }

        public string TransactionPropertyState { get; set; }

        public string IsAgentSelected { get; set; }

        public string IsForBlanketLetter { get; set; }

        public string IsParent { get; set; }

        public string IsOrtris { get; set; }

        public string IsNational { get; set; }

        public string HasClosingAttorney { get; set; }
        
        public string LetterType { get; set; }

        #endregion CPL Properties
    }
}

