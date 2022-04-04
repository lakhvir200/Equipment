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
    public class EquipmentApiServices
    {

        public IEnumerable<EquipmentView> AllEquipments()
        {
            try
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(Utilities.GetBaseUrl() + "api/Equipment")
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
                    var _EquipmentView = JsonConvert.DeserializeObject<IEnumerable<EquipmentView>>(responseString.Result);
                    return _EquipmentView;
                }

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public MasterLookup AllLookups()
        {
            try
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(Utilities.GetBaseUrl() + "api/MasterLookup")
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
                    var _MasterLookup = JsonConvert.DeserializeObject<MasterLookup>(responseString.Result);
                    return _MasterLookup;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int AddUpdateEquipment(Equipments equipment, string type = "I")
        {
            try
            {
                if (type == "I")
                {
                    var httpClient = new HttpClient { };
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    string stringData = JsonConvert.SerializeObject(equipment);
                    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = httpClient.PostAsync(Utilities.GetBaseUrl() + "api/Equipment", contentData).Result;
                    response.EnsureSuccessStatusCode();
                    var responseString = response.Content.ReadAsStringAsync();
                    var _EquipmentView = JsonConvert.DeserializeObject<int>(responseString.Result);
                    return _EquipmentView;
                }
                else
                {
                    var httpClient = new HttpClient { };
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    string stringData = JsonConvert.SerializeObject(equipment);
                    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = httpClient.PutAsync(Utilities.GetBaseUrl() + "api/Equipment", contentData).Result;
                    response.EnsureSuccessStatusCode();
                    var responseString = response.Content.ReadAsStringAsync();
                    var _EquipmentView = JsonConvert.DeserializeObject<int>(responseString.Result);
                    return _EquipmentView;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public EquipmentView GetEquipmentById(int id)
        {
            try
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(Utilities.GetBaseUrl() + "api/EquipmentDetailByID?id=" + id)
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
                    var _EquipmentView = JsonConvert.DeserializeObject<EquipmentView>(responseString.Result);
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
