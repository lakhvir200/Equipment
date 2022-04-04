using Equipment.Get.Core.Helpers.Out;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Get.Core.Interfaces
{
    public interface IRepairMasterServices
    {
        public Task<IEnumerable<RepairMaster>> GetAllRepairMaster();
        public Task<int> AddRepairMaster(RepairMaster repairMaster);
        public Task<int> UpdateRepairMaster(RepairMaster repairMaster);
        public Task<RepairMaster> DeleteRepairMaster(int RID, bool STATUS, bool IsPermanentDelete);
        public Task<RepairView> GetAllRepairDetailByIDAsync(int id);

    }
}
