using Equipment.Get.Core.Helpers.Out;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Admin.MVC.UI.Services
{
    public static class Utilities
    {
        public static string BaseUrl { get; set; }       
        public static string GetBaseUrl()
        {
         // BaseUrl = "http://emsadmin-001-site1.htempurl.com/";
           BaseUrl = "https://localhost:44335/";
            return BaseUrl;
        }
        public static IEnumerable<Master> GetMasterMenu()
        {
            try
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(Utilities.GetBaseUrl() + "api/Master/GetAllMaster")
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
                    var _EquipmentView = JsonConvert.DeserializeObject<IEnumerable<Master>>(responseString.Result);
                    return _EquipmentView;
                }

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static Master GetMenuById(int id)
        {
            try
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(GetBaseUrl() + "api/Master/GetMasterById?MasterID=" + id)
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
                    var _EquipmentView = JsonConvert.DeserializeObject<Master>(responseString.Result);
                    return _EquipmentView;
                }

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            clearText = clearText.Replace("+", "ems");
            return clearText;
        }
        public static string Decrypt(string cipherText)
        {
            cipherText = cipherText.Replace("ems", "+");
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
