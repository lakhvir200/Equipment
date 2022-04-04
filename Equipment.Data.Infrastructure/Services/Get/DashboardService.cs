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
    public class DashboardService : IDashboardService
    {
        private readonly string strConnectionString;
        public DashboardService()
        {
            //strConnectionString = "server=SQL5098.site4now.net;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=db_a83b98_emsadmin001_admin;Password=kingPin007@#;";
            strConnectionString = "server=COMP-038\\SQLSERVER2019;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=sa;Password=123$abc;";
        }
        public async Task<Dashboard> GetAllDashboard()
        {
            Dashboard dashboard = new Dashboard();
            try
            {
                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var _Dashboard = await con.QueryMultipleAsync("Sp_Get_Dashboard_Count");
                    var result = await _Dashboard.ReadFirstAsync<Dashboard>();
                    var resultEquipments = await _Dashboard.ReadAsync<Equipments>();
                    var resultRepairOrders = await _Dashboard.ReadAsync<RepairMaster>();

                    result.Equipments = resultEquipments;
                    result.RepairOrders = resultRepairOrders;
                    return result;
                }
            }
            catch(Exception ex)
            {
                return dashboard;
            }
        }
    }
}

