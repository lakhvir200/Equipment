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
    public class AppUserService : IAppUserService
    {
        private readonly string strConnectionString;
        public AppUserService()
        {
           //strConnectionString = "server=SQL5098.site4now.net;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=db_a83b98_emsadmin001_admin;Password=kingPin007@#;";
            strConnectionString = "server=COMP-038\\SQLSERVER2019;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=sa;Password=123$abc;";
        }
        public async Task<IEnumerable<AppUser>> GetAllAppUser()
        {
            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var equipments = await con.QueryAsync<AppUser>("sp_Get_All_AppUser");
                return equipments;
            }
        }

        public async Task<AppUser> GetLoginAppUser(string UserId, string Password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserID", UserId);
            parameters.Add("@Password", Password);

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var user = await con.QueryFirstOrDefaultAsync<AppUser>("Sp_Get_AppUserLogin", parameters, commandType: CommandType.StoredProcedure);
                return user;

            }

        }
    }
}
