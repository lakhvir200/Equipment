using Equipment.Get.Core.Helpers.Out;
using Equipment.Get.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equipment.Get.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserLoginController : ControllerBase
    {
        IAppUserService _aapUserLoginService;
        public AppUserLoginController(IAppUserService aapUserLoginService)
        {
            _aapUserLoginService = aapUserLoginService;
        }

        [HttpGet]
        public async Task<AppUser> GetUserLogin(string UserId, string Password)
        {
            return await _aapUserLoginService.GetLoginAppUser(UserId, Password);
        }
    }
}
