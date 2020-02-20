using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitOfWorkRuleSpecificationRepository;
//using UnitOfWorkRuleSpecificationRepository.Models;
//using UnitOfWorkWCF.Models;
//using UnitOfWorkWCF.RuleSpecifications;

namespace RepositoryTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var connectionString =
                "Data Source=mn-dev-db13;Initial Catalog=ornticcorprulespecification;Integrated Security=True";
            var repository = new UowRuleSpecificationRepository(connectionString);

            var testResult = repository.GetSpecificationRules("CPLAgentDisplay", "CPL");

            Assert.IsNotNull(testResult);
        }

    }
}
