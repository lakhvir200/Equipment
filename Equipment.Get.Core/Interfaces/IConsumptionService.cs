using Equipment.Get.Core.Helpers.Out;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Get.Core.Interfaces
{
   public interface IConsumptionService
    {
        public Task<IEnumerable<Consumption>> GetAllConsumption();
    }
}
