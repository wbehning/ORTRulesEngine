using System;

namespace RulesFakes
{
    public class CCState
    {
        // cannot use string.Empty to initialize a constant
        public const string UnknownStateAbbrAlpha = "";

        public DateTime? LastUpdated { get; set; }
        public string StateAbbrAlpha { get; set; }
        public string StateDesc { get; set; }
        public string StateNumb { get; set; }

    }
}