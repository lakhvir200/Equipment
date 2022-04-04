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
    public class AppApiServices
    {
       public AppUser AppLoginService(AppUser appUser)
        {
            try
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(Utilities.GetBaseUrl()+"api/AppUserLogin?UserId="+appUser.UserID+ "&Password="+appUser.Password)
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
                    var _appUser = JsonConvert.DeserializeObject<AppUser>(responseString.Result);
                    return _appUser;
                }

            }
            catch (Exception ex)
            {

                return null;
            }
        }

    }
}
