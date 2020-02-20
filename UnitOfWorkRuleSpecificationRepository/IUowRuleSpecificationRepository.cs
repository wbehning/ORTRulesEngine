using System.Collections.Generic;
using UnitOfWorkRuleSpecificationRepository.Models;

namespace UnitOfWorkRuleSpecificationRepository
{
    public interface IUowRuleSpecificationRepository
    {
        ICollection<RuleSpecificationComposite> GetSpecificationRules(string property, string domain);
    }
}