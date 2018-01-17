using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DemoCalculatorClient.Business
{
    /// <summary>
    /// Http repository class to invoke external services
    /// </summary>
    public class HttpRepository :IHttpRepository
    {
        public string InvokeService(string url,
            string method,
            string body,
            string contentType,
            Dictionary<string, string> headers,
            int timeout = 1000 * 600)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.UseDefaultCredentials = true;

            request.ContentType = contentType;
            request.Method = method;
            request.Timeout = timeout;

            if (null != headers)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
            if (method == "POST")
            {
                request.ContentLength = 0;
            }

            if (!string.IsNullOrEmpty(body))
            {
                byte[] bodyBinary = Encoding.UTF8.GetBytes(body);
                request.ContentLength = bodyBinary.Length;

                using (Stream reqStm = request.GetRequestStream())
                {
                    reqStm.Write(bodyBinary, 0, bodyBinary.Length);
                }
            }

            string result = string.Empty;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream resStream = response.GetResponseStream())
                    {
                        Encoding enc = Encoding.GetEncoding("utf-8");

                        if (null != resStream)
                        {
                            using (var reader = new StreamReader(resStream, enc))
                            {
                                result = reader.ReadToEnd();
                            }
                        }
                    }
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception(response.StatusDescription);
                    }
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }
            return result;

        }
    }
}
