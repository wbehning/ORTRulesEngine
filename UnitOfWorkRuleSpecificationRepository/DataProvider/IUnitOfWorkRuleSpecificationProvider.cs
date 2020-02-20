using System.Data.Entity;
using System.Linq;

namespace UnitOfWorkRuleSpecificationRepository.DataProvider
{
    public interface IUnitOfWorkRuleSpecificationProvider
    {
        /// <summary>
        /// Returns an IQueryable list of the entity model
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        IQueryable<TModel> GetTable<TModel>() where TModel : class;


        /// <summary>
        /// Creates the generic IDbSet
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        new IDbSet<TModel> Set<TModel>() where TModel : class;

        /// <summary>
        /// Creates a new Entity object in context
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        TModel Create<TModel>() where TModel : class;

        void Dispose();
    }
}