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
    public class EquipmentService : IEquipmentService
    {
        private readonly string strConnectionString;
        public EquipmentService()
        {
          //strConnectionString = "server=SQL5098.site4now.net;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=db_a83b98_emsadmin001_admin;Password=kingPin007@#;";
            strConnectionString = "server=COMP-038\\SQLSERVER2019;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=sa;Password=123$abc;";
        }

        /// <summary>
        /// AddEquipment
        /// </summary>
        /// <param name="equipments"></param>
        /// <returns></returns>
        public async Task<int> AddEquipment(Equipments equipments)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EquipmentID", equipments.EquipmentID);
                parameters.Add("@EquipNameID", equipments.EquipNameID);
                parameters.Add("@EquipModelID", equipments.EquipModelID);
                parameters.Add("@CategoryID", equipments.CategoryID);
                parameters.Add("@SubCategoryID", equipments.SubCategoryID);
                parameters.Add("@MaintPeriodicityID", equipments.@MaintPeriodicityID);
                parameters.Add("@UnitLookupID", equipments.UnitLookupID);
                parameters.Add("@Specifications", equipments.Specifications);
                parameters.Add("@DepartmentID", equipments.DepartmentID);
                parameters.Add("@BillDate", Convert.ToDateTime(equipments.BillDate));
                parameters.Add("@DateOfInstallation", Convert.ToDateTime(equipments.DateOfInstallation));
                parameters.Add("@CostOfEquipment", equipments.CostOfEquipment);
                parameters.Add("@SupplierID", equipments.SupplierID);
                parameters.Add("@StatusID", equipments.StatusID);
                parameters.Add("@IsActive", equipments.IsActive);
                parameters.Add("@Remarks", equipments.Remarks);
                parameters.Add("@UpdatedDate", DateTime.Now);
                parameters.Add("@BillDetail", equipments.BillDeatils);
                parameters.Add("@BudgetYearId", equipments.BudgetYearId);

                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var val = await con.QueryFirstOrDefaultAsync<int>("Sp_Insert_Equipments", parameters, commandType: CommandType.StoredProcedure);
                    return val;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        /// <summary>
        /// DeleteMaster
        /// </summary>
        /// <param name="MasterID"></param>
        /// <param name="IsActive"></param>
        /// <param name="IsPermanentDelete"></param>
        /// <returns></returns>
        
        public async Task<Equipments> DeleteEquipments(int ID, bool IsActive, bool IsPermanentDelete)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ID", ID);
            parameters.Add("@IsActive", IsActive);
            parameters.Add("@IsPermanentDelete", IsPermanentDelete);



            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var equipments = await con.QueryFirstOrDefaultAsync<Equipments>("Sp_StatusUpdate_Equipments", parameters, commandType: CommandType.StoredProcedure);
                return equipments;
            }
        }

        /// <summary>
        /// GetAllEquipmentAsync
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EquipmentView>> GetAllEquipmentAsync()
        {
            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var equipments = await con.QueryAsync<EquipmentView>("sp_Get_All_Equipments");
                return equipments;
            }

        }

        public async Task<int> UpdateEquipment(Equipments equipments)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ID",equipments.ID);
                parameters.Add("@EquipmentID", equipments.EquipmentID);
                parameters.Add("@EquipNameID", equipments.EquipNameID);
                parameters.Add("@EquipModelID", equipments.EquipModelID);
                parameters.Add("@CategoryID", equipments.CategoryID);
                parameters.Add("@SubCategoryID", equipments.SubCategoryID);
                parameters.Add("@MaintPeriodicityID", equipments.@MaintPeriodicityID);
                parameters.Add("@UnitLookupID", equipments.UnitLookupID);
                parameters.Add("@Specifications", equipments.Specifications);
                parameters.Add("@DepartmentID", equipments.DepartmentID);
                parameters.Add("@BillDate", equipments.BillDate);
                parameters.Add("@DateOfInstallation", equipments.DateOfInstallation);
                parameters.Add("@CostOfEquipment", equipments.CostOfEquipment);
                parameters.Add("@SupplierID", equipments.SupplierID);
                parameters.Add("@StatusID", equipments.StatusID);
                parameters.Add("@IsActive", equipments.IsActive);
                parameters.Add("@Remarks", equipments.Remarks);              
                parameters.Add("@BillDetail", equipments.BillDeatils);
                parameters.Add("@BudgetYearId", equipments.BudgetYearId);

                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var val = await con.QueryFirstOrDefaultAsync<int>("Sp_Update_Equipments", parameters, commandType: CommandType.StoredProcedure);
                    return val;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> CloneEquipment(Equipments equipments)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ID", equipments.ID);
                parameters.Add("@EquipmentID", equipments.EquipmentID);
                parameters.Add("@EquipNameID", equipments.EquipNameID);
                parameters.Add("@EquipModelID", equipments.EquipModelID);
                parameters.Add("@CategoryID", equipments.CategoryID);
                parameters.Add("@SubCategoryID", equipments.SubCategoryID);
                parameters.Add("@MaintPeriodicityID", equipments.@MaintPeriodicityID);
                parameters.Add("@UnitLookupID", equipments.UnitLookupID);
                parameters.Add("@Specifications", equipments.Specifications);
                parameters.Add("@DepartmentID", equipments.DepartmentID);
                parameters.Add("@BillDate", equipments.BillDate);
                parameters.Add("@DateOfInstallation", equipments.DateOfInstallation);
                parameters.Add("@CostOfEquipment", equipments.CostOfEquipment);
                parameters.Add("@SupplierID", equipments.SupplierID);
                parameters.Add("@StatusID", equipments.StatusID);
                parameters.Add("@IsActive", equipments.IsActive);
                parameters.Add("@Remarks", equipments.Remarks);
                parameters.Add("@BillDetail", equipments.BillDeatils);
                parameters.Add("@BudgetYearId", equipments.BudgetYearId);

                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var val = await con.QueryFirstOrDefaultAsync<int>("Sp_Update_Equipments", parameters, commandType: CommandType.StoredProcedure);
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
    

