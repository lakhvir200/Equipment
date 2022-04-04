using Equipment.Admin.MVC.UI.Services;
using Equipment.Get.Core.Helpers.Out;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Admin.MVC.UI.Controllers
{
    public class DashboardApiServices
    {
        public Dashboard MyDashboard()
        {
            
            try
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(Utilities.GetBaseUrl() + "api/Dashboard")
                };

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get                  
                };

                using (var response =  httpClient.SendAsync(request).Result)
                {
                    response.EnsureSuccessStatusCode();
                    var responseString =  response.Content.ReadAsStringAsync();
                    var _DashboardView = JsonConvert.DeserializeObject<Dashboard>(responseString.Result);
                    return _DashboardView;
                }
               
            }
            catch (Exception ex)
            {

                return null;
            }
        } 
    }
}
