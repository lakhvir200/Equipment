using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Admin.MVC.UI.Controllers
{
    public class Gateway
    {
        /// <summary>
        /// CallgatewayRequest
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <returns></returns>

        protected HttpWebRequest CallgatewayRequest<T>(string url, string token, T data, string method)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            /* ***************************************************************** */
            /* add HEADER to the created request  */
            /* ***************************************************************** */
            if (!string.IsNullOrEmpty(token))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                                      SecurityProtocolType.Tls11 |
                                                      SecurityProtocolType.Tls12;
                request.Headers.Add("Authorization", "Bearer " + token);
            }
            string jsonData = data.ToString();
            /* Convert the jsonData to a byteArray */
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonData);
            /* Set the VALUES for the REQUEST */
            request.Method = "post";
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            return request;
        }
    }
}
