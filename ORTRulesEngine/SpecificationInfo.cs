using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORTRulesEngine.Entities;

namespace ORTRulesEngine
{
    public class SpecificationInfo<T>
    {
        public int ProcessingRuleId { get; set; }
        public ISpecification<T> Specification {get;set;}
        public string MainJoin { get; set; }
        public string SubJoin { get; set; }
        public int MainGroup { get; set; }
        public int SubGroup { get; set; }
        public string RuleProperty { get; set; }
        public string EvalProperty { get; set; }
        public string RuleValue { get; set; }
        public string DefaultValue { get; set; }

        public object SpecificationResult { get; set; }

        public bool SatisfiedBy { get; set; }

        //public BaseRule SpecifcationRule { get; set; }

    }
}
