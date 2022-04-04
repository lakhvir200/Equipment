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
    public class MasterLookupServices : IMasterLookupService
    {
        private readonly string strConnectionString;
        public MasterLookupServices()
        {
           // strConnectionString = "server=SQL5098.site4now.net;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=db_a83b98_emsadmin001_admin;Password=kingPin007@#;";
            strConnectionString = "server=COMP-038\\SQLSERVER2019;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=sa;Password=123$abc;";
        }
        public async Task<MasterLookup> GetAllMasterlookup()
        {
            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                MasterLookup masterLookup = new MasterLookup();
                var _MasterLookups = await con.QueryMultipleAsync("sp_Get_MasterLookup");

                var resultAction = await _MasterLookups.ReadAsync<ActionLookup>();
                masterLookup.ActionLookup = resultAction;

                var resultEquipments = await _MasterLookups.ReadAsync<EquipNameLookup>();                
                masterLookup.EquipNameLookup = resultEquipments;

                var resultStatus = await _MasterLookups.ReadAsync<StatusLookup>();
                masterLookup.StatusLookup = resultStatus;

                var resultCategory = await _MasterLookups.ReadAsync<CategoryLookup>();
                masterLookup.CategoryLookup = resultCategory;

                var resultSubCategory = await _MasterLookups.ReadAsync<SubCategoryLookup>();
                masterLookup.SubCategoryLookup = resultSubCategory;

                var resultSupplier = await _MasterLookups.ReadAsync<SupplierLookup>();
                masterLookup.SupplierLookup = resultSupplier;

                var resultBudget = await _MasterLookups.ReadAsync<BudgetLookup>();
                masterLookup.BudgetLookup = resultBudget;


                var resultMaintenancePeriod = await _MasterLookups.ReadAsync<DepartmentLookup>();
                masterLookup.DepartmentLookup = resultMaintenancePeriod;

                var resultDepartment = await _MasterLookups.ReadAsync<MaintenancePeriodLookup>();
                masterLookup.MaintenancePeriodLookup = resultDepartment;

                var resultHospital = await _MasterLookups.ReadAsync<HospitalLookup>();
                masterLookup.HospitalLookup = resultHospital;

                return masterLookup;

            }
        }
    }
}


