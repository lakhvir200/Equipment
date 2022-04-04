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
    public class RepairManageApiServices
    {        
        public IEnumerable<RepairMaster> AllRepair()
        {

            try
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(Utilities.GetBaseUrl() + "api/RepairManagement")
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
                    var _EquipmentView = JsonConvert.DeserializeObject<IEnumerable<RepairMaster>>(responseString.Result);
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

        public int AddUpdateRepair(RepairMaster equipment, string type = "I")
        {
            try
            {
                if (type == "I")
                {
                    var httpClient = new HttpClient { };
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    string stringData = JsonConvert.SerializeObject(equipment);
                    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = httpClient.PostAsync(Utilities.GetBaseUrl() + "api/RepairManagement", contentData).Result;
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
                    HttpResponseMessage response = httpClient.PutAsync(Utilities.GetBaseUrl() + "api/RepairManagement", contentData).Result;
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
        public RepairView GetRepairById(int id)
        {
            try
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(Utilities.GetBaseUrl() + "api/RepairDetailByID?id=" + id)
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
                    var _EquipmentView = JsonConvert.DeserializeObject<RepairView>(responseString.Result);
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
