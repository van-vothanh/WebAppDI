using Xunit;
namespace CasCap.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            var svc = new DITestService();
            Assert.True(svc.GetIntValues().Count > 0);
        }
    }
}