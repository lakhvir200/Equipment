using Microsoft.AspNetCore.Http;
using Equipment.Data.Infrastructure.Services.Get;
using Equipment.Get.Core.Helpers.Out;
using Equipment.Get.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Equipment.Get.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentParamIDController : ControllerBase
    {
        IDocumentParamIDService _documentsParamIDServices;
        public DocumentParamIDController(IDocumentParamIDService documentsParamIDServices)
        {
            _documentsParamIDServices = documentsParamIDServices;
        }
        [HttpPost]
        public async Task<int> AddNewEquipment(DocumentsParamID documentsParamID)
        {
            var isAdded = await _documentsParamIDServices.AddDocumentsParamID(documentsParamID);
            return isAdded;
        }
        [HttpGet]
        public async Task<IEnumerable<DocumentsParamID>> GetDocumentsParamIDAsync(int ModuleParamID)
        {
            return await _documentsParamIDServices.GetDocumentsParamIDAsync(ModuleParamID);
        }



    }
}
