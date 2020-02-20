using System;
using System.Collections.Generic;

namespace UnitOfWorkRuleSpecificationRepository.Models
{
    public class RuleSpecification
    {
        public int RuleSpecificationId { get; set; }
        public string RuleSpecificationName { get; set; }
        public string DefaultValue { get; set; }
        public string Domain { get; set; }
        //Navigation
        public virtual ICollection<Specification> Specifications { get; set; } = new List<Specification>();
    }
}
