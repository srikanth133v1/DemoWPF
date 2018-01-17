using DemoCalculatorClient.Common;
using DemoCalculatorClient.View;
using System;
using System.Windows.Forms;
using System.Windows.Threading;

namespace DemoCalculatorClient
{
    /// <summary>
    /// Calculator view
    /// </summary>
    public partial class Calculator : Form, ICalculatorView, ILogger
    {
        public event EventHandler SubmitClick;
        public DispatcherTimer dt = new DispatcherTimer();
        const string START = "Start";
        const string STOP = "Stop";
        public Calculator()
        {
            InitializeComponent();
            dt.Tick += Dt_Tick; ;
            dt.Interval = new TimeSpan(0, 0, 1);
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            if (null != SubmitClick)
            {
                SubmitClick(sender, e);
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text.Equals(START))
            {
                btnSubmit.Text = STOP;
                dt.Start();
            }
            else
            {
                btnSubmit.Text = START;
                dt.Stop();
            }

        }

        public void AppendLog(string info)
        {
            txtLog.Text = info + System.Environment.NewLine + txtLog.Text;
        }


    }
}
