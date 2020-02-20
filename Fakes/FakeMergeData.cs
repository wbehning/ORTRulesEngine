using System;
using System.Collections.Generic;
using System.Linq;

namespace RulesFakes
{
    public class FakeMergeData
    {
        public LetterType LetterType
        {
            get { return ValidatedLetterRequest.LetterType; }
            set { ValidatedLetterRequest.LetterType = value; }
        }

        public string LetterTypeCode
        {
            get { return ValidatedLetterRequest.LetterType.Code.ToUpperInvariant(); }
        }

        public LetterRequestTransactionParty Addressee
        {
            get { return ValidatedLetterRequest.Addressee; }
        }

        public IList<LetterRequestTransactionParty> CoveredParties
        {
            get { return ValidatedLetterRequest.CoveredParties; }
        }

        public LetterRequestTransactionParty GetCoveredParty(TransactionPartyType partyType)
        {
            return ValidatedLetterRequest.CoveredParties.FirstOrDefault(cp => cp.Is(partyType));
        }

        public DateTime LetterDate { get; protected set; }

        public string ReferenceNumber { get; protected set; }

        public Agent Agent
        {
            get { return ValidatedLetterRequest.Agent; }
            set { ValidatedLetterRequest.Agent = value; }
        }

        private ValidatedLetterRequest _validatedLetterRequest;

        public ValidatedLetterRequest ValidatedLetterRequest
        {
            get
            {
                if (_validatedLetterRequest == null)
                {
                    _validatedLetterRequest = new ValidatedLetterRequest();
                }
                return _validatedLetterRequest;
            }
            set { _validatedLetterRequest = value; }
        }

        public ClosingAttorneyInformation ClosingAttorney
        {
            get { return ValidatedLetterRequest.ClosingAttorney; }
            set { ValidatedLetterRequest.ClosingAttorney = value; }
        }

        public BranchInformation SelectedBranchOffice
        {
            get { return ValidatedLetterRequest.BranchInformation; }
        }

        public IEnumerable<BranchInformation> BranchOffices
        {
            get { return ValidatedLetterRequest.AgentBranchOffices; }
        }

        public DisbursingAgent DisbursingAgent
        {
            get { return ValidatedLetterRequest.DisbursingAgent; }
        }

        public IEnumerable<CCState> StatesCovered
        {
            get { return ValidatedLetterRequest.CoveredStates; }
        }

        /// <summary>
        /// Concat states covered by the letter and return the result as a string.
        /// </summary>
        /// <returns>A comma-separated list of the states covered in one string.</returns>
        public string CoveredStatesAsString { get; protected set; }

        public string LetterReturnAddressTemplate { get; protected set; }

        public string LetterBodyTemplate { get; protected set; }

        public string LetterSignatureTemplate { get; protected set; }

        public string LetterTemplateFullFileName { get; protected set; }

        public bool LetterTransactionTypeIs(LetterTransactionType letterTransactionType)
        {
            var result = ValidatedLetterRequest.LetterTransactionType.Equals(letterTransactionType);
            return result;
        }

        public bool IsForBlanketLetter
        {
            get
            {
                return LetterTransactionTypeIs(LetterTransactionType.Blanket);
            }
        }

        public bool LetterTypeIs(string letterTypeCode)
        {
            return ValidatedLetterRequest.IsForLetterType(letterTypeCode);
        }

        public bool LetterTypeIsOneOf(params string[] letterTypes)
        {
            return !letterTypes.IsNullOrEmpty() && letterTypes.Any(LetterTypeIs);
        }

        public bool IsForArizonaLetter { get; protected set; }

        public bool IsForNevadaLetter { get; protected set; }


        public string LogoFullPath { get; protected set; }

        public string CompanyName { get; protected set; }

        public bool AgentCompanyIs(AgentCompany company)
        {
            return company != null && Agent != null && Agent.Company.Equals(company);
        }

        public string TransactionPropertyState { get; set; }

        public LetterRequestProcessingType RequestProcessingType
        {
            get { return ValidatedLetterRequest.ProcessingType; }
        }

        public IEnumerable<string> ArbitrationStates
        {
            get { return ValidatedLetterRequest.ArbitrationStates; }
        }

        public bool IsSouthCarolinaSingleTransaction { get; protected set; }

        // Filed-form states that use Alta8 letter body but may not change at the same time as the other ALTA8 states.
        public bool IsForAlta8FiledFormState { get; protected set; }
    }
}