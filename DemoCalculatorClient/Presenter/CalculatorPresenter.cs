using System;
using System.Configuration;

using DemoCalculatorClient.Business;
using DemoCalculatorClient.Model;
using DemoCalculatorClient.View;
using DemoCalculatorClient.Common;

namespace DemoCalculatorClient.Presenter
{

    /// <summary>
    /// Presenter for Calculator view
    /// </summary>
    public class CalculatorPresenter
    {
        ICalculatorView _view;
        ICalculatorRepository _calRepo;
        IHttpRepository _httpRepo;
        ILogger _logger;
        string _serviceUrl = string.Empty;
        bool _isDev = true;

        public CalculatorPresenter(ICalculatorView view,
            ICalculatorRepository repo,
            IHttpRepository httpRepo,
            ILogger logger,
            string ServiceUrl,
            bool IsDev)
        {
            _view = view;
            _calRepo = repo;
            _view.SubmitClick += SubmitClick;
            _httpRepo = httpRepo;
            _logger = logger;
            _serviceUrl = ServiceUrl;
            _isDev = IsDev;
        }

        private void SubmitClick(object sender, EventArgs e)
        {
            try
            {
                string response = string.Empty;
                if (!_isDev)
                {
                    response = _httpRepo.InvokeService(_serviceUrl, "GET", string.Empty, "application/json", null);
                }
                else
                {
                    //Modify the path accordingly
                    response = System.IO.File.ReadAllText(@"E:\DemoCalculatorClient\DemoCalculatorClient\Result.json");
                }
                if (!string.IsNullOrEmpty(response))
                {
                    var opModel = JsonUtil.Deserialize<Operation>(response);
                    opModel.Result = _calRepo.Calculate(opModel);
                    _logger.AppendLog(opModel.ToString());
                }
            }
            catch (Exception ex)
            {
                _logger.AppendLog(ex.Message);
            }
        }

    }
}
