
using System;

namespace ORTRulesEngine.Entities
{
    public abstract class BaseRule<T>
    {
        public RuleEngine<T> RulesEngine;

        public BaseRule()
        {
            RulesEngine = new RuleEngine<T>();
        }
    }
}