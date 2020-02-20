using System.Data.Entity.ModelConfiguration;
using UnitOfWorkRuleSpecificationRepository.Models;

namespace UnitOfWorkRuleSpecificationRepository.Mappings
{
    public class GroupSpecificationMapping : EntityTypeConfiguration<GroupSpecification>
    {
        public GroupSpecificationMapping()
        {
            // Primary Key
            HasKey(t => t.GroupSpecificationId);

            // Properties
            Property(t => t.MainJoin).HasMaxLength(50);

            Property(t => t.SubJoin).HasMaxLength(50);

            // Table & Column Mappings
            ToTable("GroupSpecification");
            Property(t => t.GroupSpecificationId).HasColumnName("GroupSpecificationId");
            Property(t => t.SpecificationId).HasColumnName("SpecificationId");
            Property(t => t.MainGroup).HasColumnName("MainGroup");
            Property(t => t.MainJoin).HasColumnName("MainJoin");
            Property(t => t.SubGroup).HasColumnName("SubGroup");
            Property(t => t.SubJoin).HasColumnName("SubJoin");
        }


    }
}
