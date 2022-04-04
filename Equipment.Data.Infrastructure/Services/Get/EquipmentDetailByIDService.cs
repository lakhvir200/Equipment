using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using Equipment.Get.Core.Interfaces;
using Equipment.Get.Core.Helpers.Out;
using Microsoft.Data.SqlClient;

namespace Equipment.Data.Infrastructure.Services.Get
{
    public class EquipmentDetailByIDService : IEquipmentDetailByIDService
    {
        private readonly string strConnectionString;
        public EquipmentDetailByIDService()
        {
           // strConnectionString = "server=SQL5098.site4now.net;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=db_a83b98_emsadmin001_admin;Password=kingPin007@#;";
            strConnectionString = "server=COMP-038\\SQLSERVER2019;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=sa;Password=123$abc;";
        }

        public async Task<EquipmentView> GetAllEquipmentDetailByIDAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ID", id);

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var equipments = await con.QueryFirstOrDefaultAsync<EquipmentView>("Sp_Get_EquipmentsByID", parameters, commandType: CommandType.StoredProcedure);
                return equipments;
            }
        }
    }
}