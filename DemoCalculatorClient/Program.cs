using System;
using System.Windows.Forms;

using DemoCalculatorClient.Business;
using DemoCalculatorClient.Presenter;
using System.Configuration;

namespace DemoCalculatorClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var calForm = new Calculator();
            var calPresenter = new CalculatorPresenter(calForm, new CalculatorRepository(),
                new HttpRepository(), calForm, ServiceUrl, IsDev);
            Application.Run(calForm);
        }
        public static string ServiceUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["ServiceUrl"];
            }
        }

        public static bool IsDev
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["IsDev"]);
            }
        }
    }
}
