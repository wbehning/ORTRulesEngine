using System;

namespace RulesFakes
{
    public class LetterRequestTransactionParty
    {
        public bool Is(TransactionPartyType partyType)
        {
            return partyType != null
                   && PartyTypeName != null
                   && String.Equals(PartyTypeName, partyType.Name, StringComparison.OrdinalIgnoreCase);
        }

        public string PartyTypeName { get; set; }
        public string NameLine1 { get; set; }
        public string FullName { get; set; }
        public bool DeliverLetterViaEmail { get; set; }
        public bool DeliverLetterViaFax { get; set; }
    }
}