using System.Data.Entity.ModelConfiguration;
using UnitOfWorkRuleSpecificationRepository.Models;

namespace UnitOfWorkRuleSpecificationRepository.Mappings
{
    public class RuleSpecificationCompositeMapping: EntityTypeConfiguration<RuleSpecificationComposite>
    {
        public RuleSpecificationCompositeMapping()
        {
            // Table & Column Mappings
            ToTable("vwRuleSpecifications");
            HasKey(o => o.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.RuleSpecificationName).HasColumnName("RuleSpecificationName");
            Property(t => t.EvaluationProperty).HasColumnName("EvaluationProperty");
            Property(t => t.EvaluationOperator).HasColumnName("EvaluationOperator");
            Property(t => t.EvaluationValue).HasColumnName("EvaluationValue");
            Property(t => t.MainGroup).HasColumnName("MainGroup");
            Property(t => t.MainJoin).HasColumnName("MainJoin");
            Property(t => t.SubGroup).HasColumnName("SubGroup");
            Property(t => t.SubJoin).HasColumnName("SubJoin");
            Property(t => t.SpecificationValue).HasColumnName("SpecificationValue");
            Property(t => t.DefaultValue).HasColumnName("DefaultValue");
            Property(t => t.Domain).HasColumnName("Domain");
        }
    }
}
