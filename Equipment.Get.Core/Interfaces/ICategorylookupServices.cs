using Equipment.Get.Core.Helpers.Out;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Get.Core.Interfaces
{
    public interface ICategorylookupServices
    {
        Task<int> AddCategorylookup(CategoryLookup categoryLookup);
        Task<IEnumerable<CategoryLookup>> GetAllCategoryLookup();
        Task<int> UpdateCategoryLookup(CategoryLookup categoryLookup);
        Task<CategoryLookup> DeleteCategoryLookup(int CategoryID, bool IsActive, bool IsPermanentDelete);
    }
}
