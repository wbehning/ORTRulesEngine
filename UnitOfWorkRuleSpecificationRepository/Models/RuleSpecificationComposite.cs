using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkRuleSpecificationRepository.Models
{
    public class RuleSpecificationComposite
    {
        public Int64 Id { get; set; }
        public string RuleSpecificationName { get; set; }
        public string EvaluationProperty { get; set; }
        public string EvaluationOperator { get; set; }
        public string EvaluationValue { get; set; }
        public int MainGroup { get; set; }
        public string MainJoin { get; set; }
        public int SubGroup { get; set; }
        public string SubJoin { get; set; }
        public string SpecificationValue { get; set; }
        public string DefaultValue { get; set; }

        public string Domain { get; set; }
    }
}
