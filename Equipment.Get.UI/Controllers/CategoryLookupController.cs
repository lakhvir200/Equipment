using Equipment.Data.Infrastructure.Services.Get;
using Equipment.Get.Core.Helpers.Out;
using Equipment.Get.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Equipment.Get.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryLookupController : ControllerBase
    {
        ICategorylookupServices _categorylookupService;
        public CategoryLookupController(ICategorylookupServices categorylookupService)
        {
            _categorylookupService = categorylookupService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryLookup>> GetAllCategoryLookup()
        {
            ICategorylookupServices categorylookupService = new CategoryLookUpService();// Object

            var result = await categorylookupService.GetAllCategoryLookup();// method calling 
            return result;
        }

        [HttpPost]
        public async Task<int> AddCategorylookup(CategoryLookup categoryLookup)
        {
            var isAdded = await _categorylookupService.AddCategorylookup(categoryLookup);
            return isAdded;
        }
        [HttpPut]
        public async Task<int> UpdateCategoryLookup(CategoryLookup categoryLookup)
        {
            var isUpdate = await _categorylookupService.UpdateCategoryLookup(categoryLookup);
            return isUpdate;
        }
        [HttpDelete]
        public async Task<CategoryLookup> DeleteCategoryLookup(int CategoryID, bool IsActive, bool IsPermanentDelete)
        {
            var isDelete = await _categorylookupService.DeleteCategoryLookup(CategoryID, IsActive, IsPermanentDelete);
            return isDelete;
        }
    }
}

