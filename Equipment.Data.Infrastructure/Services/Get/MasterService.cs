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
    public class MasterService : IMasterService
    {
        private readonly string strConnectionString;
        public MasterService()
        {
      // strConnectionString = "server=SQL5098.site4now.net;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=db_a83b98_emsadmin001_admin;Password=kingPin007@#;";
            strConnectionString = "server=COMP-038\\SQLSERVER2019;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=sa;Password=123$abc;";
        }
        /// <summary>
        /// AddMaster
        /// </summary>
        /// <param name="master"></param>
        /// <returns></returns>
        public async Task<int> AddMaster(Master master)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", master.Name);
                parameters.Add("@ModuleUrl", master.ModuleUrl);
                parameters.Add("@IsActive", master.IsActive);
                parameters.Add("@Position", master.Position);


                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var val = await con.QueryFirstOrDefaultAsync<int>("Sp_Insert_Master", parameters, commandType: CommandType.StoredProcedure);
                    return val;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }


        }

        public Task GetAllAppUser()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DeleteMaster
        /// </summary>
        /// <param name="MasterID"></param>
        /// <returns></returns>
        public async Task<Master> DeleteMaster(int MasterID,bool IsActive, bool IsPermanentDelete)
        {
            
            var parameters = new DynamicParameters();
            parameters.Add("@MasterID", MasterID);
            parameters.Add("@IsActive", IsActive);
            parameters.Add("@IsPermanentDelete", IsPermanentDelete);




            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var master = await con.QueryFirstOrDefaultAsync<Master>("Sp_StatusUpdate_Master", parameters, commandType: CommandType.StoredProcedure);
                return master;
            }
        }
        /// <summary>
        /// GetAllMaster
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Master>> GetAllMaster()
        {
            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var master = await con.QueryAsync<Master>("Sp_GetAll_Master");
                return master;
            }
        }

        /// <summary>
        /// GetMasterByID
        /// </summary>
        /// <param name="MasterID"></param>
        /// <returns></returns>
        public async Task<Master> GetMasterByID(int MasterID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@MasterID", MasterID);

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var master = await con.QueryFirstOrDefaultAsync<Master>("Sp_Get_Master", parameters, commandType: CommandType.StoredProcedure);
                return master;

            }
        }


        /// <summary>
        /// UpdateMaster
        /// </summary>
        /// <param name="master"></param>
        /// <param name="MasterID"></param>
        /// <returns></returns>
        public async Task<int> UpdateMaster(Master master)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MasterID",master.MasterID);
                parameters.Add("@Name", master.Name);
                parameters.Add("@ModuleUrl", master.ModuleUrl);
                parameters.Add("@IsActive", master.IsActive);
                parameters.Add("@Position", master.Position);


                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var val = await con.QueryFirstOrDefaultAsync<int>("Sp_Update_Master", parameters, commandType: CommandType.StoredProcedure);
                    return val;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
