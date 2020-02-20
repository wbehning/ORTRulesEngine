using System.Data.Entity.ModelConfiguration;
using UnitOfWorkRuleSpecificationRepository.Models;

namespace UnitOfWorkRuleSpecificationRepository.Mappings
{
    public class RuleSpecificationMapping: EntityTypeConfiguration<RuleSpecification>
    {
        public RuleSpecificationMapping()
        {
            // Primary Key
            HasKey(t => t.RuleSpecificationId);

            // Properties
            Property(t => t.RuleSpecificationName).HasMaxLength(50);
            Property(t => t.DefaultValue).HasMaxLength(50);

            // Table & Column Mappings
            ToTable("RuleSpecification");
            Property(t => t.RuleSpecificationId).HasColumnName("RuleSpecificationId");
            Property(t => t.RuleSpecificationName).HasColumnName("RuleSpecificationName");
            Property(t => t.DefaultValue).HasColumnName("DefaultValue");
            Property(t => t.Domain).HasColumnName("Domain");

            HasMany(o => o.Specifications).WithRequired(o => o.RuleSpecification).HasForeignKey(o => o.RuleSpecificationId);

        }
    }
}
