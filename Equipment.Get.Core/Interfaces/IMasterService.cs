using Equipment.Get.Core.Helpers.Out;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equipment.Get.Core.Interfaces
{
    public interface IMasterService
    {
        public Task<Master> GetMasterByID(int MasterID);
        Task<int> AddMaster(Master master);
        Task<int> UpdateMaster(Master master);
        public Task<Master> DeleteMaster(int MasterID,bool IsActive, bool IsPermanentDelete);
        public Task<IEnumerable<Master>> GetAllMaster();








    }
}
