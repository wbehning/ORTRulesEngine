using System;

namespace RulesFakes
{
    public partial class BranchInformation
    {
        public const int UnknownId = 0;
        private string _bPhone;

        public BranchInformation()
        {
            Id = UnknownId;
        }

        public int Id { get; set; }
        public string NameLine1 { get; set; }
        public string NameLine2 { get; set; }
        public string AgentNumber { get; set; }

        public Address Address { get; set; }

        public string PhoneNumber
        {
            get { return _bPhone; }
            set { _bPhone = value.GetDigits(); }
        }

        public DateTime? CreateDateTime { get; set; }

        public string FullName
        {
            get
            {
                return
                    string.Format("{0} {1}", (NameLine1 ?? string.Empty).Trim(), (NameLine2 ?? string.Empty).Trim())
                        .Trim();
            }
        }

    }
}