using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkRuleSpecificationRepository.DataProvider;
using UnitOfWorkRuleSpecificationRepository.Models;

namespace UnitOfWorkRuleSpecificationRepository
{
    public class UowRuleSpecificationRepository : IUowRuleSpecificationRepository, IDisposable
    {
        private readonly string _connectionString;
        //private IMapper _mapper;

        public UowRuleSpecificationRepository(string connectionString)
        {
            _connectionString = connectionString;
            //var config = new MapperConfiguration(
            //    cfg =>
            //    {
            //        cfg.CreateMap<ClosingTransactionDto, ClosingTransaction>()
            //            .ForMember(dest => dest.Id, opt => opt.Ignore())
            //            .ForMember(o => o.Letters, opt => opt.Ignore());

            //        cfg.CreateMap<ClosingTransactionFeeDto, ClosingTransactionFee>()
            //            .ForMember(dest => dest.ClosingTransactionId, opt => opt.Ignore());

            //        cfg.CreateMap<ClosingTransactionFeeDto, ClosingTransactionFee>();

            //        cfg.CreateMap<CplFeeCaptureDto, CplFeeCapture>().ForMember(dest => dest.Id, opt => opt.Ignore());
            //    });

            //_mapper = config.CreateMapper();
        }

        public ICollection<RuleSpecificationComposite> GetSpecificationRules(string property, string domain)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var dataProvider = new UnitOfWorkRuleSpecificationProvider(connection))
            {
                //var retVal = dataProvider.GetTable<RuleSpecification>()
                //    .Include(o=>o.Specifications)
                //    .Include(o=>o.Specifications.Select(t=>t.GroupSpecifications));

                var retVal = dataProvider.GetTable<RuleSpecificationComposite>()
                    .Where(o => o.Domain.Equals(domain, StringComparison.InvariantCultureIgnoreCase))
                    .Where(o => o.RuleSpecificationName.Equals(property, StringComparison.InvariantCultureIgnoreCase));


 
                return retVal.ToList();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UowRuleSpecificationRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}

