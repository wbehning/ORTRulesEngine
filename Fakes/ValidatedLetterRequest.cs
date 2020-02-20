using System;
using System.Collections.Generic;
using System.Linq;

namespace RulesFakes
{
    public class ValidatedLetterRequest
    {
        private readonly LetterRequest _originalLetterRequest;

        public ValidatedLetterRequest(LetterRequest letterRequest, Agent agent, LetterType letterType
            , LetterRequestTransactionParty addressee, BranchInformation branchInformation
            , IEnumerable<BranchInformation> agentBranchOffices
            , DisbursingAgent disbursingAgent
            , ClosingAttorneyInformation closingAttorney, IEnumerable<CCState> coveredStates
            , LetterRequestProcessingType processingType
            , IEnumerable<string> arbitrationStates)
        {
            _originalLetterRequest = letterRequest;

            Agent = agent;
            Addressee = addressee;
            LetterType = letterType;
            BranchInformation = branchInformation;
            AgentBranchOffices = agentBranchOffices;
            ClosingAttorney = closingAttorney;
            CoveredStates = coveredStates;
            ProcessingType = processingType;
            DisbursingAgent = disbursingAgent;
            LetterTransactionType = LetterTransactionType.GetByName(letterRequest.LetterTransactionTypeName);
            ArbitrationStates = arbitrationStates;
        }

        public ValidatedLetterRequest()
        {
        }

        public string ReferenceNumberOfLetterToUpdate
        {
            get { return _originalLetterRequest.ReferenceNumberOfLetterToUpdate; }
        }

        public string AgentAuthorizationCodeSuffix
        {
            get { return _originalLetterRequest.AgentAuthorizationCodeSuffix; }
        }

        public string AgentContactName
        {
            get { return _originalLetterRequest.AgentContactName; }
        }

        public int SelectedAgentContactInfoId
        {
            get { return _originalLetterRequest.SelectedAgentContactInfoId; }
        }

        public string AgentEmailAddress
        {
            get { return _originalLetterRequest.AgentEmailAddress; }
        }

        public string AgentFaxNumber
        {
            get { return _originalLetterRequest.AgentFaxNumber; }
        }

        public Agent Agent { get; set; }

        public string AgentGroupEmailAddresses
        {
            get { return _originalLetterRequest.AgentGroupEmailAddresses; }
        }

        public bool HideAgentInfoOnLetter { get; set; }

        public string BinderOrRequestorOrderId
        {
            get { return _originalLetterRequest.AgentOrderNumber; }
        }


        public IEnumerable<LetterRequestTransactionParty> AdditionalTransactionParties
        {
            get
            {
                return
                    _originalLetterRequest.AdditionalTransactionParties.Where(
                        p =>
                            p != null && !string.IsNullOrWhiteSpace(p.PartyTypeName) &&
                            !string.IsNullOrWhiteSpace(p.NameLine1));
            }
        }

        public string GetAdditionalPartyFullName(TransactionPartyType transPartyType)
        {
            if (transPartyType == null)
            {
                return null;
            }

            var transParty = AdditionalTransactionParties.FirstOrDefault(p => p != null && p.Is(transPartyType));

            return transParty == null ? null : transParty.FullName;
        }

        public BranchInformation BranchInformation { get; private set; }

        public IEnumerable<BranchInformation> AgentBranchOffices { get; private set; }

        public DisbursingAgent DisbursingAgent { get; private set; }

        public ClosingAttorneyInformation ClosingAttorney { get; set; }

        public bool DeliverLetterToAgentViaEmail
        {
            get { return _originalLetterRequest.DeliverToAgentViaEmail; }
        }

        public bool DeliverLetterToAgentViaFax
        {
            get { return _originalLetterRequest.DeliverToAgentViaFax; }
        }

        public bool DeliverLetterToClosingAttorneyViaEmail
        {
            get { return _originalLetterRequest.DeliverToClosingAttorneyViaEmail; }
        }

        public bool DeliverLetterToClosingAttorneyViaFax
        {
            get { return _originalLetterRequest.DeliverToClosingAttorneyViaFax; }
        }

        public bool DeliverLetterToAddresseeViaEmail
        {
            get { return _originalLetterRequest.Addressee.DeliverLetterViaEmail; }
        }

        public bool DeliverLetterToAddresseeViaFax
        {
            get { return _originalLetterRequest.Addressee.DeliverLetterViaFax; }
        }

        public bool DeliverLetterToDisbursingAgentViaEmail
        {
            get { return _originalLetterRequest.DeliverToDisbursingAgentViaEmail; }
        }

        public bool DeliverLetterToDisbursingAgentViaFax
        {
            get { return _originalLetterRequest.DeliverToClosingAttorneyViaFax; }
        }

        public bool IncludeAllAgentBranchOfficesOnTheLetter
        {
            get { return _originalLetterRequest.IncludeAllAgentBranchOfficesOnTheLetter; }
        }

        public LetterTransactionType LetterTransactionType { get; set; }

        public LetterRequestTransactionParty Addressee { get; private set; }

        public LetterType LetterType { get; set; }

        public string LetterCategoryId
        {
            get { return LetterType.LetterCategoryId; }
        }

        public string PertainsToLine1
        {
            get { return _originalLetterRequest.PertainsToLine1; }
        }

        public string PertainsToLine2
        {
            get { return _originalLetterRequest.PertainsToLine2; }
        }

        public Address PropertyAddress
        {
            get { return _originalLetterRequest.PropertyAddress; }
        }

        public string RequestorMachineIPAddress
        {
            get { return _originalLetterRequest.RequestorMachineIPAddress; }
        }

        public ApplicationType CreatorApplicationType
        {
            get { return _originalLetterRequest.ByApplicationType; }
        }

        public double? TransactionFundsAmount
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_originalLetterRequest.SingleTransactionFundsAmount))
                {
                    return null;
                }

                return double.Parse(_originalLetterRequest.SingleTransactionFundsAmount);
            }
        }

        public string LoanNumber
        {
            get { return _originalLetterRequest.LoanNumber; }
        }

        public string AttorneyContactName
        {
            get { return _originalLetterRequest.ClosingAttorneyContactName; }
        }

        public IEnumerable<CCState> CoveredStates { get; private set; }

        public bool IsForLetterType(string letterTypeCode)
        {
            return _originalLetterRequest.IsForLetterType(letterTypeCode);
        }

        public IEnumerable<string> EmailSubscribers
        {
            get { return GetEmailSubscriberList(); }
        }

        private IEnumerable<string> GetEmailSubscriberList()
        {
            return new List<string>();
        }


        private IList<LetterRequestTransactionParty> _coveredParties = new List<LetterRequestTransactionParty>();

        public IList<LetterRequestTransactionParty> CoveredParties { get; set; }

        public LetterRequestProcessingType ProcessingType { get; private set; }

        public IEnumerable<string> ArbitrationStates { get; private set; }
    }
}