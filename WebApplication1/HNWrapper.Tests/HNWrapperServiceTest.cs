using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HNWrapper.Tests
{
    [TestClass]
    public class HNWrapperServiceTest : HNWrapperServiceTestContext
    {
        private Mock<IHNConverterService> mockHNConverterService;
        private HNWrapperService hnWrapperService;

        [TestInitialize]
        public void TestInit()
        {
            this.mockHNConverterService = new Mock<IHNConverterService>();
            this.mockHNConverterService.Setup(s => s.MapToIds(It.IsAny<string>())).Returns(GetIds());
            this.mockHNConverterService.Setup(s => s.MapToItem(It.IsAny<string>())).Returns(GetStoryItem());

            this.hnWrapperService = new HNWrapperService("");
        }

        [TestMethod]
        public void TestGetBestStories()
        {
            var items = this.hnWrapperService.GetBestStories();

            Assert.IsNotNull(items);
        }
    }
}
