using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Equipment.Get.Core;
using Equipment.Get.Core.Helpers.Out;
using Equipment.Get.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace Equipment.Data.Infrastructure.Services.Get
{
    public class SubMasterService : ISubMasterService
    {
        private readonly string strConnectionString;
        public SubMasterService()
        {
           // strConnectionString = "server=SQL5098.site4now.net;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=db_a83b98_emsadmin001_admin;Password=kingPin007@#;";
            strConnectionString = "server=COMP-038\\SQLSERVER2019;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=sa;Password=123$abc;";
        }
        /// <summary>
        /// AddEquipmentNamelookupService 
        /// </summary>
        /// <param name="equipmentNamelookup"></param>
        /// <returns></returns>
        /// 

        public async Task<int> AddEquipmentNamelookup(EquipmentNamelookup equipmentNamelookup)
        {
            try{ 
            var parameters = new DynamicParameters();
            parameters.Add("@EquipmentName", equipmentNamelookup.EquipmentName);
            parameters.Add("@IsActive", equipmentNamelookup.IsActive);
            parameters.Add("@CreatedDate", equipmentNamelookup.CreatedDate);
            parameters.Add("@UpdatedDate", equipmentNamelookup.updatedtime);
            parameters.Add("@CreatedBy", equipmentNamelookup.CreatedBy);
            parameters.Add("@Updatedby", equipmentNamelookup.Updatedby);

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var val = await con.QueryFirstOrDefaultAsync<int>("Sp_Insert_EquipmentNamelookup", parameters, commandType: CommandType.StoredProcedure);
                return val;
            }
        }
            catch (Exception ex)
            {
                return 0;
            }


}
        /// <summary>
        /// AddSubMaster
        /// </summary>
        /// <param name="subMaster"></param>
        /// <returns></returns>

        public async Task<int> AddSubMaster(SubMaster subMaster)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", subMaster.Name);
                parameters.Add("@IsActive", subMaster.IsActive);
                parameters.Add("@CreatedDate", subMaster.CreatedDate);
                parameters.Add("@UpdatedDate", subMaster.updatedtime);
                parameters.Add("@CreatedBy", subMaster.CreatedBy);
                parameters.Add("@UpdatedBy", subMaster.UpdatedBy);
                parameters.Add("@MasterID", subMaster.MasterId);

                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var val = await con.QueryFirstOrDefaultAsync<int>("Sp_Insert_SubMaster", parameters, commandType: CommandType.StoredProcedure);
                    return val;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// DeleteEquipmentNamelookup
        /// </summary>
        /// <returns></returns>
        public async Task<EquipmentNamelookup> DeleteEquipmentNamelookup(int EquipNameID, bool IsActive, bool IsPermanentDelete)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EquipNameID", EquipNameID);
            parameters.Add("@IsActive", IsActive);
            parameters.Add("@IsPermanentDelete", IsPermanentDelete);




            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var isDelete = await con.QueryFirstOrDefaultAsync<EquipmentNamelookup>("Sp_Delete_EquipmentNameLookup", parameters, commandType: CommandType.StoredProcedure);
                return isDelete;
            }
        }
        /// <summary>
        /// DeleteSubMaster
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="IsActive"></param>
        /// <param name="IsPermanentDelete"></param>
        /// <returns></returns>
        public async Task<SubMaster> DeleteSubMaster(int MasterID,int SubMasterID)
        {
            {

                var parameters = new DynamicParameters();
                parameters.Add("@MasterID", MasterID);
                parameters.Add("@SubMasterID", SubMasterID);




                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var master = await con.QueryFirstOrDefaultAsync<SubMaster>("Sp_Delete_SubMaster", parameters, commandType: CommandType.StoredProcedure);
                    return master;
                }
            }
        }


        /// <summary>
        /// GetAllEquipmentNamelookupAsync
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EquipmentNamelookup>> GetAllEquipmentNamelookupAsync()
        {
            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var equipments = await con.QueryAsync<EquipmentNamelookup>("Sp_Get_All_EquipmentNameLookup");
                return equipments;

            }
        }
        /// <summary>
        /// GetAllSubMaster
        /// </summary>
        /// <param name="MasterID"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SubMaster>> GetAllSubMaster(int MasterID)
        {            
            var parameters = new DynamicParameters();
            parameters.Add("@MasterID", MasterID);

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var master = await con.QueryAsync<SubMaster>("Sp_Get_All_SubMaster", parameters, commandType: CommandType.StoredProcedure);
                return master;

            }

        }
        /// <summary>
        /// UpdateSubMaster
        /// </summary>
        /// <param name="subMaster"></param>
        /// <returns></returns>
        public Task<int> UpdateSubMaster(SubMaster subMaster)
        {
            throw new NotImplementedException();
        }
    }
}

 