using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using UnitOfWorkRuleSpecificationRepository.Mappings;
using UnitOfWorkRuleSpecificationRepository.Models;

namespace UnitOfWorkRuleSpecificationRepository.DataProvider
{
    public class UnitOfWorkRuleSpecificationProvider : DbContext, IUnitOfWorkRuleSpecificationProvider
    {
        public UnitOfWorkRuleSpecificationProvider()
        {
            Database.SetInitializer<UnitOfWorkRuleSpecificationProvider>(null);
        }

        public UnitOfWorkRuleSpecificationProvider(DbConnection existingConnection)
            : base(existingConnection, true)
        {
            Database.SetInitializer<UnitOfWorkRuleSpecificationProvider>(null);

            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 600 * 5;

            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = true;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<Specification> Specifications { get; set; }
        public DbSet<GroupSpecification> SpecificationGroups { get; set; }
        public DbSet<RuleSpecification> SpecificationRules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SpecificationMapping());
            modelBuilder.Configurations.Add(new GroupSpecificationMapping());
            modelBuilder.Configurations.Add(new RuleSpecificationMapping());
            modelBuilder.Configurations.Add(new RuleSpecificationCompositeMapping());
        }

        public IQueryable<TModel> GetTable<TModel>() where TModel : class
        {
            return Set<TModel>().AsQueryable();
        }

        /// <summary>
        /// Creates the generic IDbSet
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        public new IDbSet<TModel> Set<TModel>() where TModel : class
        {
            ChangeTracker.DetectChanges();
            return base.Set<TModel>();
        }

        /// <summary>
        /// Creates a new Entity object in context
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        public TModel Create<TModel>() where TModel : class
        {
            var model = Set<TModel>().Create<TModel>();
            Set<TModel>().Add(model);
            return model;
        }

        /// <summary>
        /// saves changes to all entities in context
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="entityModel"></param>
        /// <returns></returns>
        public int SaveChanges<TModel>(TModel entityModel) where TModel : class
        {
            var result = base.SaveChanges();
            return result;
        }
    }
}
