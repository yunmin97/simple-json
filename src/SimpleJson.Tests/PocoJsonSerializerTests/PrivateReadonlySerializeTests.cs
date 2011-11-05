namespace SimpleJsonTests.PocoJsonSerializerTests
{
#if NUNIT
    using TestClass = NUnit.Framework.TestFixtureAttribute;
    using TestMethod = NUnit.Framework.TestAttribute;
    using TestCleanup = NUnit.Framework.TearDownAttribute;
    using TestInitialize = NUnit.Framework.SetUpAttribute;
    using ClassCleanup = NUnit.Framework.TestFixtureTearDownAttribute;
    using ClassInitialize = NUnit.Framework.TestFixtureSetUpAttribute;
    using NUnit.Framework;
#else
    using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

    using SimpleJson;
    using SimpleJsonTests.DataContractTests;

    [TestClass]
    public class PrivateReadonlySerializeTests
    {
        private DataContractPrivateReadOnlyFields _dataContractPrivateReadOnlyFields;

        public PrivateReadonlySerializeTests()
        {
            _dataContractPrivateReadOnlyFields = new DataContractPrivateReadOnlyFields();
        }

        [TestMethod]
        public void SerializesCorrectly()
        {
            var result = SimpleJson.SerializeObject(_dataContractPrivateReadOnlyFields,
                                                    SimpleJson.PocoJsonSerializerStrategy);

            Assert.AreEqual("{}", result);
        }
    }
}