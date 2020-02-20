using System.Data.Entity.ModelConfiguration;
using UnitOfWorkRuleSpecificationRepository.Models;

namespace UnitOfWorkRuleSpecificationRepository.Mappings
{
    public class SpecificationMapping : EntityTypeConfiguration<Specification>
    {
        public SpecificationMapping()
        {
            // Primary Key
            HasKey(t => t.SpecificationId);

            // Properties
            Property(t => t.EvaluationProperty).HasMaxLength(50);
            Property(t => t.EvaluationOperator).HasMaxLength(50);
            Property(t => t.EvaluationValue).HasMaxLength(50);
            Property(t => t.SpecificationValue).HasMaxLength(50);

            // Table & Column Mappings
            ToTable("Specification");
            Property(t => t.SpecificationId).HasColumnName("SpecificationId");
            Property(t => t.RuleSpecificationId).HasColumnName("RuleSpecificationId");
            Property(t => t.EvaluationProperty).HasColumnName("EvaluationProperty");
            Property(t => t.EvaluationOperator).HasColumnName("EvaluationOperator");
            Property(t => t.EvaluationValue).HasColumnName("EvaluationValue");
            Property(t => t.SpecificationValue).HasColumnName("SpecificationValue");

            HasMany(o => o.GroupSpecifications).WithRequired(o => o.Specification).HasForeignKey(o => o.SpecificationId);

        }
    }
}
