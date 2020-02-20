using System;

namespace RulesFakes
{
    public class LetterType
    {
        // cannot use string.Empty to initialize a constant
        public const string Unknown = "";

        public bool CanBeUsedAsBlanketLetter { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string LetterCategoryId { get; set; }

        public override bool Equals(object obj)
        {
            LetterType o = (LetterType) obj;

            return o != null
                   && string.Equals(o.Code, Code, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Code.Trim().ToLower().GetHashCode();
        }
    }
}