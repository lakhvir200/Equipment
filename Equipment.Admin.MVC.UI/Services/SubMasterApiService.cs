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

namespace Equipment.Admin.MVC.UI.Services
{
    public class SubMasterApiService
    {

        public IEnumerable<SubMaster> GetAllSubMasterById(int id)
        {
            try
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(Utilities.GetBaseUrl() + "api/SubMaster?masterid=" + id)
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
                    var _EquipmentView = JsonConvert.DeserializeObject<IEnumerable<SubMaster>>(responseString.Result);
                    return _EquipmentView;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int AddNewSubMaster(SubMaster subMaster)
        {
            try
            {
                var httpClient = new HttpClient { };
                httpClient.DefaultRequestHeaders.Accept.Clear();
                string stringData = JsonConvert.SerializeObject(subMaster);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync(Utilities.BaseUrl+"api/SubMaster", contentData).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync();
                var _EquipmentView = JsonConvert.DeserializeObject<int>(responseString.Result);
                return _EquipmentView;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
