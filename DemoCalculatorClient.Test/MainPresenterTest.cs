using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using Moq;

using DemoCalculatorClient.Business;
using DemoCalculatorClient.Presenter;
using DemoCalculatorClient.View;
using DemoCalculatorClient.Common;

namespace DemoCalculatorClient.Test
{
    [TestClass]
    public class MainPresenterTest
    {
        /// <summary>
        /// Test presenter submit click event
        /// </summary>
        [TestMethod]
        public void TestPresenter_SubmitClick()
        {
            string response = "{\r\n  \"parm1\": 3,\r\n  \"parm2\": 5,\r\n  \"op\": \"*\"\r\n}";
            var httpRepo = new Mock<IHttpRepository>();
            httpRepo.Setup(h => h.InvokeService(It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<Dictionary<string, string>>(), It.IsAny<int>()))
                .Returns(() => response).Verifiable();

            var view = new Mock<ICalculatorView>();
            var logger = new Mock<ILogger>();

            var calPresnter = new CalculatorPresenter(view.Object,
                new CalculatorRepository(), httpRepo.Object, logger.Object, string.Empty, false);
            string log = string.Empty;
            logger.Setup(v => v.AppendLog(It.IsAny<string>())).Callback<string>(r => log = r);
            view.Raise(v => v.SubmitClick += null, null, null);
            Assert.AreEqual("3 * 5 = 15", log);
        }
    }
}

