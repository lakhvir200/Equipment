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
    public class ConsumptionApiServices
    {

        public IEnumerable<Consumption> AllConsumption()
        {
            try
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(Utilities.GetBaseUrl() + "api/Consumption")
                };

                httpClient.DefaultRequestHeaders.Add("User-Agent", "Equipments");
                string basicValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"" + "" + ":" + "" + ""));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicValue);


                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get
                };

                using (var response = httpClient.SendAsync(request).Result)
                {
                    response.EnsureSuccessStatusCode();
                    var responseString = response.Content.ReadAsStringAsync();
                    var _EquipmentView = JsonConvert.DeserializeObject<IEnumerable<Consumption>>(responseString.Result);
                    return _EquipmentView;
                }

            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
