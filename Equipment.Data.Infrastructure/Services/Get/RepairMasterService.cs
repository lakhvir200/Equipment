using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Equipment.Get.Core.Helpers.Out;
using Equipment.Get.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace Equipment.Data.Infrastructure.Services.Get
{
    public class RepairMasterService : IRepairMasterServices
    {
        private readonly string strConnectionString;
        public RepairMasterService()
        {
           // strConnectionString = "server=SQL5098.site4now.net;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=db_a83b98_emsadmin001_admin;Password=kingPin007@#;";
            strConnectionString = "server=COMP-038\\SQLSERVER2019;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=sa;Password=123$abc;";
        }
        /// <summary>
        /// AddRepairMaster
        /// </summary>
        /// <param name="repairMaster"></param>
        /// <returns></returns>
        public async Task<int> AddRepairMaster(RepairMaster repairMaster)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RDATE", repairMaster.RDATE);
                parameters.Add("@EQ_ID", repairMaster.EQ_ID);
                parameters.Add("@DEPT", repairMaster.DEPT);
                parameters.Add("@REPAIR_MAINT", repairMaster.REPAIR_MAINT);
                parameters.Add("@ACTION_TAKEN", repairMaster.ACTION_TAKEN);
                parameters.Add("@SPARES", repairMaster.SPARES);
                parameters.Add("@ATT_BY", repairMaster.ATT_BY);
                parameters.Add("@STATUS", repairMaster.STATUS);
                parameters.Add("@RNO", repairMaster.RNO);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       

                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var val = await con.QueryFirstOrDefaultAsync<int>("Sp_Insert_Register_RepairMaster", parameters, commandType: CommandType.StoredProcedure);
                    return val;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        /// <summary>
        /// DeleteRepairMaster
        /// </summary>
        /// <param name="RID"></param>
        /// <param name="STATUS"></param>
        /// <param name="IsPermanentDelete"></param>
        /// <returns></returns>
        public async Task<RepairMaster> DeleteRepairMaster(int RID, bool STATUS, bool IsPermanentDelete)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RID", RID);
            parameters.Add("@STATUS", STATUS);
            parameters.Add("@IsPermanentDelete", IsPermanentDelete);


            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var repairMaster = await con.QueryFirstOrDefaultAsync<RepairMaster>("Sp_Delete_RepairMaster", parameters, commandType: CommandType.StoredProcedure);
                return repairMaster;
            }
        
    }
        /// <summary>
        /// GetAllRepairMaster
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RepairMaster>> GetAllRepairMaster()
        {

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                IEnumerable<RepairMaster> equipments = await con.QueryAsync<RepairMaster>("sp_Get_All_Repair_Details");
                return equipments;

            }
        }
        /// <summary>
        /// UpdateRepairMaster
        /// </summary>
        /// <param name="repairMaster"></param>
        /// <returns></returns>
        public async Task<int> UpdateRepairMaster(RepairMaster repairMaster)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RID", repairMaster.RID);
                parameters.Add("@RDATE", repairMaster.RDATE);
                parameters.Add("@EQ_ID", repairMaster.EQ_ID);
                parameters.Add("@DEPT", repairMaster.DEPT);
                parameters.Add("@REPAIR_MAINT", repairMaster.REPAIR_MAINT);
                parameters.Add("@ACTION_TAKEN", repairMaster.ACTION_TAKEN);
                parameters.Add("@SPARES", repairMaster.SPARES);
                parameters.Add("@ATT_BY", repairMaster.ATT_BY);
                parameters.Add("@STATUS", repairMaster.STATUS);
                parameters.Add("@RNO", repairMaster.RNO);


                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var val = await con.QueryFirstOrDefaultAsync<int>("Sp_update_RepairMaster", parameters, commandType: CommandType.StoredProcedure);
                    return val;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<RepairView> GetAllRepairDetailByIDAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RID", id);

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var equipments = await con.QueryFirstOrDefaultAsync<RepairView>("Sp_Get_RepairMasterByID", parameters, commandType: CommandType.StoredProcedure);
                return equipments;
            }
        }
    }
}
