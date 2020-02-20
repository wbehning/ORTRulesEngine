using System;
using System.Collections.Generic;

namespace UnitOfWorkRuleSpecificationRepository.Models
{
    public partial class Specification
    {
        public int SpecificationId { get; set; }
        public int RuleSpecificationId { get; set; }
        public string EvaluationProperty { get; set; }
        public string EvaluationOperator { get; set; }
        public string EvaluationValue { get; set; }
        public string SpecificationValue { get; set; }

        // Navigation
        public virtual RuleSpecification RuleSpecification { get; set; }

        public virtual ICollection<GroupSpecification> GroupSpecifications { get; set; }
    }
}
