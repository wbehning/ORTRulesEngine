using System;
using System.Collections.Generic;

namespace RulesFakes
{
    public class LetterTransactionType
    {
        private static readonly IDictionary<string, LetterTransactionType> ValidTransactionTypes = new Dictionary<string, LetterTransactionType>(StringComparer.OrdinalIgnoreCase);
        private LetterTransactionType(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public LetterTransactionType GetByName(object letterTransactionTypeName)
        {
            throw new NotImplementedException();
        }

        public static LetterTransactionType GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || !ValidTransactionTypes.ContainsKey(name))
            {
                return null;
            }

            return ValidTransactionTypes[name.Trim()];
        }

        public static LetterTransactionType Unknown = new LetterTransactionType(string.Empty, "Unknown Transaction Letter");
        public static LetterTransactionType Single = new LetterTransactionType("Single", "Single Transaction Letter");
        public static LetterTransactionType Blanket = new LetterTransactionType("Blanket", "Blanket Letter");
        public static LetterTransactionType Cash = new LetterTransactionType("Cash", "Cash Transaction Letter");

        public override bool Equals(object obj)
        {
            LetterTransactionType o = obj as LetterTransactionType;

            return o != null && string.Equals(o.Name, Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}