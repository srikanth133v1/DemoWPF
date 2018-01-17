using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCalculatorClient.Business
{
    public interface IHttpRepository
    {
        string InvokeService(string url,
            string method,
            string body,
            string contentType,
            Dictionary<string, string> headers,
            int timeout = 1000 * 600);
    }
}
