using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDemo;

namespace UnitTests
{
    [TestClass]
    public class TaxConverterTests
    {
        [TestMethod]
        public void GrossFromNetCalculatesProperly()
        {
            double result = TaxConverter.GrossFromNet(100, 27);
            Assert.AreEqual(127, result);
        }

        [TestMethod]
        public void NetFromGrossCalculatesProperly()
        {
            double result = TaxConverter.NetFromGross(127, 27);
            Assert.AreEqual(100, result);
        }
    }
}
