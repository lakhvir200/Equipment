using Equipment.Get.Core.Helpers.Out;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Get.Core.Interfaces
{
   public interface ISubMasterService
    {
        Task<int> AddSubMaster(SubMaster subMaster);
        Task<IEnumerable<SubMaster>> GetAllSubMaster(int MasterID);
        Task<int> UpdateSubMaster(SubMaster subMaster);
        public Task<SubMaster> DeleteSubMaster(int MasterID,int SubMasterID);

    }
   }
