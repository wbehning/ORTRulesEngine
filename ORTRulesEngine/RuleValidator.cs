using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORTRulesEngine
{
    public class RuleValidator
    {
        public bool ValidateRulesAll<T>(T value, Func<T, bool>[] rules)
        {
            foreach (var rule in rules)
            {
                if (!rule(value))
                    return false;
            }
            return true;
        }

        public bool ValidateRulesAny<T>(T value, Func<T, bool>[] rules)
        {
            foreach (var rule in rules)
            {
                if (rule(value))
                    return true;
            }
            return false;
        }

        public bool ValidateRulesAll<T>(T[] values, Func<T, bool>[] rules)
        {
            foreach (var value in values)
            {
                foreach (var rule in rules)
                {
                    if (!rule(value))
                        return false;
                }
            }
            return true;
        }

        public bool ValidateRulesAny<T>(T[] values, Func<T, bool>[] rules)
        {
            foreach (var value in values)
            {
                bool validated = false;
                foreach (var rule in rules)
                {
                    if (rule(value))
                    {
                        validated = true;
                        break;
                    }
                }
                if (!validated)
                    return false;
            }
            return true;
        }
    }
}
