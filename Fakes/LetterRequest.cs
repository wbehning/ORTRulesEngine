using System;
using System.Collections.Generic;

namespace RulesFakes
{
    public class LetterRequest



    {
        public string ClosingAttorneyContactName { get; set; }
        public object LetterTransactionTypeName { get; set; }
        public string ReferenceNumberOfLetterToUpdate { get; set; }
        public string AgentAuthorizationCodeSuffix { get; set; }
        public string AgentContactName { get; set; }
        public int SelectedAgentContactInfoId { get; set; }
        public string AgentEmailAddress { get; set; }
        public string AgentFaxNumber { get; set; }
        public string AgentGroupEmailAddresses { get; set; }
        public bool HideAgentInfoOnLetter { get; set; }
        public string AgentOrderNumber { get; set; }
        public IEnumerable<LetterRequestTransactionParty> AdditionalTransactionParties { get; set; }
        public bool IsForLetterType(string letterTypeCode)
        {
            return string.Equals(LetterTypeCode, letterTypeCode, StringComparison.OrdinalIgnoreCase);
        }


        private string _letterTypeCode;

        public string LetterTypeCode
        {
            get { return _letterTypeCode; }
            set { _letterTypeCode = value ?? LetterType.Unknown; }
        }

        public bool DeliverToAgentViaEmail { get; set; }
        public bool DeliverToAgentViaFax { get; set; }
        public bool DeliverToClosingAttorneyViaEmail { get; set; }
        public bool DeliverToClosingAttorneyViaFax { get; set; }
        public LetterRequestTransactionParty Addressee { get; set; }
        public bool DeliverToDisbursingAgentViaEmail { get; set; }
        public bool IncludeAllAgentBranchOfficesOnTheLetter { get; set; }
        public string PertainsToLine1 { get; set; }
        public string PertainsToLine2 { get; set; }
        public Address PropertyAddress { get; set; }
        public string RequestorMachineIPAddress { get; set; }
        public ApplicationType ByApplicationType { get; set; }
        public string SingleTransactionFundsAmount { get; set; }
        public string LoanNumber { get; set; }
    }
}