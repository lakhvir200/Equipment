using Equipment.Get.Core.Helpers.Out;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Get.Core.Interfaces
{
    public interface IAppUserService
    {
        public Task<IEnumerable<AppUser>> GetAllAppUser();
        public Task<AppUser> GetLoginAppUser(string UserId, string Password);

    }
}

    

