using Equipment.Get.Core.Helpers.Out;
using Equipment.Get.Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace Equipment.Data.Infrastructure.Services.Get
{
    public class DocumentsParamIDServices : IDocumentParamIDService
    {
        private readonly string strConnectionString;
        public DocumentsParamIDServices()
        {
            //strConnectionString = "server=SQL5098.site4now.net;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=db_a83b98_emsadmin001_admin;Password=kingPin007@#;";
            strConnectionString = "server=COMP-038\\SQLSERVER2019;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=sa;Password=123$abc;";
        }

        /// <summary>
        /// AddDocumentsParamID
        /// </summary>
        /// <param name="documentsParamID"></param>
        /// <returns></returns>
        public async Task<int> AddDocumentsParamID(DocumentsParamID documentsParamID)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DocumentTypeID", documentsParamID.DocumentTypeID);
                parameters.Add("@DocumentName", documentsParamID.DocumentName);
                parameters.Add("@Location", documentsParamID.Location);
                parameters.Add("@ModuleTypeID", documentsParamID.ModuleTypeID);
                parameters.Add("@ModuleParamID", documentsParamID.ModuleParamID);
                parameters.Add("@CreatedDate", documentsParamID.CreatedDate);
                parameters.Add("@UpdatedDate", documentsParamID.Updatedtime);

                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var val = await con.QueryFirstOrDefaultAsync<int>("Sp_Insert_DocumentsByParamID", parameters, commandType: CommandType.StoredProcedure);
                    return val;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }


        }
        /// <summary>
        /// GetDocumentsParamIDAsync
        /// </summary>
        /// <param name="ModuleParamID"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DocumentsParamID>> GetDocumentsParamIDAsync(int ModuleParamID)
        {
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ModuleParamID", ModuleParamID);

                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var equipments = await con.QueryAsync<DocumentsParamID>("Sp_Get_DocumentsByParamID", parameters, commandType: CommandType.StoredProcedure);
                    return equipments;
                }
            }

        }    
    }
}
            
    
    


